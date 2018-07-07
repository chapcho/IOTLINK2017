DELIMITER //

Create or Replace Procedure usp_GetControlMessage_A0
(
     IN V_COMP_ID VARCHAR(20)
   , OUT V_RESULT INT
   , OUT V_SENDMESSAGE VARCHAR(200)
)
	LANGUAGE SQL
	NOT DETERMINISTIC
	CONTAINS SQL
	SQL SECURITY DEFINER
	COMMENT 'COMP_ID로 전송할 메시지중, HP번호가 없는 또는 있는 메시지를 읽어내고, 전송 완료 처리 한다.'
Begin
/*
@description

-- 에어벨브 제어를 위한 Control 메시지 조회
@param
@return : 정보가 있다면 1, 없다면 0 , Error : -1
*/
DECLARE recordCnt INT DEFAULT 0;
DECLARE sendMessage VARCHAR(200) DEFAULT '0';
DECLARE msgSeq INT DEFAULT 0;

DECLARE exit handler for SQLEXCEPTION
BEGIN
	GET DIAGNOSTICS CONDITION 1 @p2 = MESSAGE_TEXT;
	SELECT @p2 as Result;
	
	ROLLBACK;
	SET V_RESULT = -1;
END;
	-- 인증된 단말인지..
	SELECT 
		Count(*) INTO recordCnt
	FROM TBM_COMPRESSOR
	WHERE COMP_ID = V_COMP_ID AND REGIST_YN = 'Y';

	-- 해당하는 값이 없다면 RETURN
	IF recordCnt < 1 THEN
		SET V_RESULT = 0;
	ELSE
	BEGIN
		-- 세션으로 제어 메시지를 보내는 경우, shortMessage 테이블에 기록되는 모바일 폰번호를 0000000으로 설정해야 합니다.
		-- 그리고 SENDER가 IOTLINK(즉:폰번호가아니어야 합니다.)
		SELECT 
			Count(*) INTO recordCnt 
		FROM 
			compData.tbm_shortmessage 
		WHERE COMP_ID = V_COMP_ID AND SEND_TIME IS NULL  
		AND LENGTH(TRIM(REPLACE(MOBILE_PHONE_NO,'0',' '))) < 2
		AND LENGTH(TRIM(REPLACE(SENDER,'0',' '))) < 2;
	
		IF recordCnt > 0 Then
		Begin
			SELECT A.MSG_SEQ INTO msgSeq FROM
			(
				SELECT MSG_SEQ, MOBILE_PHONE_NO, COMP_ID, SEND_MESSAGE, SEND_TIME, SENDER, CREATER FROM compdata.tbm_shortmessage
				WHERE COMP_ID = V_COMP_ID AND SEND_TIME IS NULL 
					AND LENGTH(TRIM(REPLACE(MOBILE_PHONE_NO,'0',' '))) < 2
					AND LENGTH(TRIM(REPLACE(SENDER,'0',' '))) < 2
					LIMIT 1
			) A
			WHERE A.COMP_ID = V_COMP_ID;

			SELECT 
				SEND_MESSAGE INTO V_SENDMESSAGE  
			FROM compdata.tbm_shortmessage 
				WHERE MSG_SEQ = msgSeq;

			UPDATE compdata.tbm_shortmessage
				SET SEND_TIME = DATE_FORMAT(NOW(),'%Y%m%d%H%i%s') 
				, SEND_CNT = IFNULL(SEND_CNT,0) + 1
				, UPDATER = 'IOTLINKDataManager'
				WHERE MSG_SEQ = msgSeq;
			
			INSERT INTO compdata.tbp_shortmessage(MOBILE_PHONE_NO, COMP_ID, SEND_MESSAGE,CREATE_TIME,SEND_TIME,RESULT_TIME,SEND_RESULT,SEND_CNT,CREATER,SENDER,UPDATER)
			SELECT 
				MOBILE_PHONE_NO, COMP_ID, SEND_MESSAGE,CREATE_TIME,SEND_TIME,RESULT_TIME,SEND_RESULT,SEND_CNT,CREATER,SENDER,UPDATER 
			FROM compdata.tbm_shortmessage
			WHERE MSG_SEQ = msgSeq;

			DELETE FROM compdata.tbm_shortmessage 
			WHERE MSG_SEQ = msgSeq;

			SET V_RESULT = 1;
		End;
		Else
		Begin
			SET V_RESULT = 0;
			SET V_SENDMESSAGE = '0';
		End;
		END IF;

	END;	
	END IF;

COMMIT;
END
//

DELIMITER ;