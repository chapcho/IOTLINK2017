USE [DYPFTOP]
GO
/****** Object:  UserDefinedFunction [dbo].[usf_DateStringFormatter]    Script Date: 2016-10-28 오후 5:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Function [dbo].[usf_DateStringFormatter]
(
@dateString nvarchar(50)
)
returns nvarchar(50)
BEGIN

Declare @returnVal nvarchar(50);

IF LEN(@dateString) <> 17
BEGIN
	SELECT @returnVal = CONVERT(varchar(50), GetDate(), 21)
END 
ELSE
BEGIN
	SELECT @returnVal = SUBSTRING(@dateString,1,4) + '-' + SUBSTRING(@dateString,5,2) + '-' + SUBSTRING(@dateString,7,2) + ' ' + SUBSTRING(@dateString,9,2) + ':' + SUBSTRING(@dateString,11,2) + ':' + SUBSTRING(@dateString,13,2) + '.' + SUBSTRING(@dateString,15,3)
END

return @returnVal;

END

GO
/****** Object:  Table [dbo].[FTOP100]    Script Date: 2016-10-28 오후 5:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTOP100](
	[CORP_CD] [nvarchar](4) NOT NULL,
	[GTR_ID] [nvarchar](17) NOT NULL,
	[EQM_CD] [nvarchar](8) NULL,
	[ITEM_CD] [nvarchar](8) NULL,
	[ITEM_DETAIL_CD] [nvarchar](8) NULL,
	[EQM_NM] [nvarchar](200) NULL,
	[PLANT_CD] [nvarchar](8) NULL,
	[PLANT_NM] [nvarchar](50) NULL,
	[LINE_CD] [nvarchar](8) NULL,
	[LINE_NM] [nvarchar](50) NULL,
	[OP_CD] [nvarchar](8) NULL,
	[OP_NM] [nvarchar](50) NULL,
	[DESCR] [nvarchar](200) NULL,
	[REG_USER] [nvarchar](50) NOT NULL,
	[REG_DATE] [datetime] NOT NULL,
	[UPD_USER] [nvarchar](50) NOT NULL,
	[UPD_DATE] [datetime] NOT NULL,
	[USE_YN] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_FTOP100] PRIMARY KEY CLUSTERED 
(
	[CORP_CD] ASC,
	[GTR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FTOP110]    Script Date: 2016-10-28 오후 5:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTOP110](
	[CORP_CD] [nvarchar](4) NOT NULL,
	[GTR_ID] [nvarchar](17) NOT NULL,
	[PLC_NM] [nvarchar](50) NULL,
	[PLC_CHNL] [nvarchar](50) NULL,
	[PLC_ADDR] [nvarchar](50) NULL,
	[PLC_TYPE] [nvarchar](50) NULL,
	[EQM_IP_ADDR] [nvarchar](50) NULL,
	[EQM_IP_PORT] [int] NULL,
	[DATA_TYPE] [nvarchar](50) NULL,
	[IF_TARGET] [nvarchar](50) NULL,
	[ADDR_TAG] [nvarchar](200) NULL,
	[DESCR] [nvarchar](200) NULL,
	[REG_USER] [nvarchar](50) NULL,
	[REG_DATE] [datetime] NULL,
	[UPD_USER] [nvarchar](50) NULL,
	[UPD_DATE] [datetime] NULL,
	[USE_YN] [nvarchar](1) NULL,
 CONSTRAINT [PK_FTOP110] PRIMARY KEY CLUSTERED 
(
	[CORP_CD] ASC,
	[GTR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FTOP200]    Script Date: 2016-10-28 오후 5:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTOP200](
	[CORP_CD] [nvarchar](4) NOT NULL,
	[GTR_ID] [nvarchar](17) NOT NULL,
	[MAKE_TIME] [nvarchar](17) NULL,
	[VALUE_DATA] [nvarchar](8) NULL,
	[IF_MES_YN] [nvarchar](1) NULL,
	[IF_MES_RSLT] [nvarchar](50) NULL,
	[IF_MES_TIME] [datetime] NULL,
	[IF_CPS_YN] [nvarchar](1) NULL,
	[IF_CPS_RSLT] [nvarchar](50) NULL,
	[IF_CPS_TIME] [datetime] NULL,
	[REG_USER] [nvarchar](50) NULL,
	[REG_DATE] [datetime] NULL,
	[UPD_USER] [nvarchar](50) NULL,
	[UPD_DATE] [datetime] NULL,
 CONSTRAINT [PK_FTOP200] PRIMARY KEY CLUSTERED 
(
	[CORP_CD] ASC,
	[GTR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FTOP300]    Script Date: 2016-10-28 오후 5:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTOP300](
	[CORP_CD] [nvarchar](4) NOT NULL,
	[GTR_ID] [nvarchar](17) NOT NULL,
	[MAKE_TIME] [nvarchar](17) NOT NULL,
	[VALUE_DATA] [nvarchar](8) NULL,
	[IF_MES_YN] [nvarchar](1) NULL,
	[IF_MES_RSLT] [nvarchar](50) NULL,
	[IF_MES_TIME] [datetime] NULL,
	[IF_CPS_YN] [nvarchar](1) NULL,
	[IF_CPS_RSLT] [nvarchar](50) NULL,
	[IF_CPS_TIME] [datetime] NULL,
	[REG_USER] [nvarchar](50) NULL,
	[REG_DATE] [datetime] NULL,
	[UPD_USER] [nvarchar](50) NULL,
	[UPD_DATE] [datetime] NULL,
 CONSTRAINT [PK_FTOP300] PRIMARY KEY CLUSTERED 
(
	[CORP_CD] ASC,
	[GTR_ID] ASC,
	[MAKE_TIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vwFtopDeviceList]    Script Date: 2016-10-28 오후 5:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwFtopDeviceList]
AS
SELECT  dbo.FTOP100.EQM_CD, dbo.FTOP100.EQM_NM, dbo.FTOP100.ITEM_CD, dbo.FTOP100.ITEM_DETAIL_CD, 
               dbo.FTOP100.DESCR AS DEVICE_DTL, dbo.FTOP100.CORP_CD, dbo.FTOP100.PLANT_CD, 
               dbo.FTOP100.PLANT_NM, dbo.FTOP100.LINE_CD, dbo.FTOP100.LINE_NM, dbo.FTOP100.OP_CD, 
               dbo.FTOP100.OP_NM, dbo.FTOP110.PLC_ADDR, dbo.FTOP110.PLC_TYPE, dbo.FTOP110.EQM_IP_ADDR, 
               dbo.FTOP110.EQM_IP_PORT, dbo.FTOP110.DATA_TYPE, dbo.FTOP110.IF_TARGET, dbo.FTOP110.ADDR_TAG, 
               dbo.FTOP110.DESCR AS OPC_SVR
FROM     dbo.FTOP100 INNER JOIN
               dbo.FTOP110 ON dbo.FTOP100.EQM_CD = dbo.FTOP110.EQM_CD AND 
               dbo.FTOP100.ITEM_CD = dbo.FTOP110.ITEM_CD AND 
               dbo.FTOP100.ITEM_DETAIL_CD = dbo.FTOP110.ITEM_DETAIL_CD AND 
               dbo.FTOP100.OP_NM = dbo.FTOP110.UPD_DATE
WHERE  (dbo.FTOP100.USE_YN = 'Y') AND (dbo.FTOP110.USE_YN = 'Y')

GO
/****** Object:  StoredProcedure [dbo].[usp_FTOP200_CU_001]    Script Date: 2016-10-28 오후 5:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_FTOP200_CU_001]
(
	@eqmCd nvarchar(8),
	@itemCd nvarchar(8),
	@itemDetailCd nvarchar(8),
	@makeTime nvarchar(17),
	@valueData nvarchar(8),
	@ifMesYn nvarchar(1),
	@ifCpsYn nvarchar(1)
)
-- FTOP200 테이블에 데이터 생성 과 수정
-- 데이터 수신시 추가,수정
AS
BEGIN

	UPDATE dbo.FTOP200 
		SET 
			VALUE_DATA = @valueData, 
			MAKE_TIME = @makeTime,
			IF_MES_TIME = NULL,
			IF_MES_RSLT = NULL,
			IF_CPS_TIME = NULL,
			IF_CPS_RSLT = NULL,
			REG_DATE = GETDATE()
	WHERE EQM_CD = @eqmCd AND ITEM_CD = @itemCd AND ITEM_DETAIL_CD = @itemDetailCd;
	
	-- Update 문장의 @@RowCount는 바로 다음라인까지 유효합니다.
	IF @@ROWCOUNT = 0
	BEGIN
		IF @ifMesYn = 'N' AND @ifCpsYn = 'N'
		BEGIN
			INSERT dbo.FTOP200(EQM_CD,ITEM_CD,ITEM_DETAIL_CD,MAKE_TIME,VALUE_DATA,IF_MES_YN,IF_MES_TIME,IF_CPS_YN,IF_CPS_TIME,REG_DATE) 
			SELECT @eqmCd, @itemCd, @itemDetailCd, @makeTime, @valueData, @ifMesYn, GetDate(), @ifCpsYn, GetDate(), GETDATE();		
		END
		ELSE
		BEGIN
			INSERT dbo.FTOP200(EQM_CD,ITEM_CD,ITEM_DETAIL_CD,MAKE_TIME,VALUE_DATA,IF_MES_YN,IF_CPS_YN,REG_DATE) 
			SELECT @eqmCd, @itemCd, @itemDetailCd, @makeTime, @valueData, @ifMesYn, @ifCpsYn, GETDATE();
		END
	END

	IF @@ERROR <> 0
	BEGIN
		SELECT ERROR_NUMBER() as ErrorNumber, ERROR_SEVERITY() as ErrorSeverity ,ERROR_STATE() as ErrorState ,ERROR_PROCEDURE() as ErrorProcedure , ERROR_LINE() as ErrorLine , ERROR_MESSAGE() as ErrorMessage;
		RETURN -1;
	END
	ELSE
	BEGIN
		SELECT 0 as ErrorNumber, 0 as ErrorSeverity ,0 as ErrorState ,0 as ErrorProcedure , 0 as ErrorLine , 0 as ErrorMessage;
		RETURN 0;	
	END
END

GO
/****** Object:  StoredProcedure [dbo].[usp_FTOP300_C_001]    Script Date: 2016-10-28 오후 5:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_FTOP300_C_001]
(
	@eqmCd nvarchar(8),
	@itemCd nvarchar(8),
	@itemDetailCd nvarchar(8),
	@makeTime nvarchar(17),
	@valueData nvarchar(8),
	@ifMesYn nvarchar(1),
	@ifMesRslt nvarchar(50),
	@ifMesTime nvarchar(17), 
	@ifCpsYn nvarchar(1),
	@ifCpsRslt nvarchar(50),
	@ifCpsTime nvarchar(17)	
)
AS
BEGIN
	-- 처리결과 도메인 체크(전송성공=0, 타켓시스템처리거부=1, 전송대기=8, 재전송필요시=9) 
	-- 송수신 이력을 기록하고..
	INSERT dbo.FTOP300(EQM_CD, ITEM_CD, ITEM_DETAIL_CD, MAKE_TIME, VALUE_DATA, IF_MES_YN, IF_MES_RSLT, IF_MES_TIME, IF_CPS_YN, IF_CPS_RSLT, IF_CPS_TIME, REG_DATE, REG_USER,UPD_USER,UPD_DATE) 
	SELECT @eqmCd, @itemCd, @itemDetailCd, @makeTime, @valueData, @ifMesYn, CASE WHEN @ifMesYn = 'Y' THEN '8' ELSE '0' END, NULL, @ifCpsYn, CASE WHEN @ifCpsYn = 'Y' THEN '8' ELSE '0' END, NULL, GETDATE() ,'FTOPCLIENT','FTOPCLIENT',GETDATE();
	
	IF @@ERROR <> 0
	BEGIN
		SELECT ERROR_NUMBER() as ErrorNumber, ERROR_SEVERITY() as ErrorSeverity ,ERROR_STATE() as ErrorState ,ERROR_PROCEDURE() as ErrorProcedure , ERROR_LINE() as ErrorLine , ERROR_MESSAGE() as ErrorMessage;
		-- 에러 이력을 시스템 로그에 남기고 저장 실패한 데이터는 버려야 합니다.
		RETURN -1;
	END
		
	UPDATE dbo.FTOP200 
		SET 
			VALUE_DATA = @valueData, 
			MAKE_TIME = @makeTime,
			IF_MES_TIME = NULL,
			IF_MES_RSLT = NULL,
			IF_CPS_TIME = NULL,
			IF_CPS_RSLT = NULL,
			UPD_USER = 'FTOPCLIENT',
			UPD_DATE = GETDATE()
	WHERE EQM_CD = @eqmCd AND ITEM_CD = @itemCd AND ITEM_DETAIL_CD = @itemDetailCd;
	
	-- Update 문장의 @@RowCount는 바로 다음라인까지 유효합니다.
	IF @@ROWCOUNT = 0
	BEGIN
		INSERT dbo.FTOP200(EQM_CD,ITEM_CD,ITEM_DETAIL_CD,MAKE_TIME,VALUE_DATA,IF_MES_YN,IF_CPS_YN,REG_DATE,REG_USER,UPD_USER,UPD_DATE) 
		SELECT @eqmCd, @itemCd, @itemDetailCd, @makeTime, @valueData, @ifMesYn, @ifCpsYn, GETDATE(),'FTOPCLIENT','FTOPCLIENT',GETDATE();
	END

	IF @@ERROR <> 0
	BEGIN
		SELECT ERROR_NUMBER() as ErrorNumber, ERROR_SEVERITY() as ErrorSeverity ,ERROR_STATE() as ErrorState ,ERROR_PROCEDURE() as ErrorProcedure , ERROR_LINE() as ErrorLine , ERROR_MESSAGE() as ErrorMessage;
		-- 에러 이력을 시스템 로그에 남기고 저장 실패한 데이터는 버려야 합니다.
		RETURN -2;
	END
	ELSE
	BEGIN
		SELECT 0 as ErrorNumber, 0 as ErrorSeverity ,0 as ErrorState ,0 as ErrorProcedure , 0 as ErrorLine , 0 as ErrorMessage;
		-- 에러 이력을 시스템 로그에 남기고 저장 실패한 데이터는 버려야 합니다.
		RETURN 0;	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FTOP300_U_001]    Script Date: 2016-10-28 오후 5:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_FTOP300_U_001]
(
	@eqmCd nvarchar(8),
	@itemCd nvarchar(8),
	@itemDetailCd nvarchar(8),
	@makeTime nvarchar(17),
	@valueData nvarchar(8),
	@ifMesYn nvarchar(1),
	@ifMesRslt nvarchar(50),
	@ifMesTime nvarchar(17), 
	@ifCpsYn nvarchar(1),
	@ifCpsRslt nvarchar(50),
	@ifCpsTime nvarchar(17)	
)
-- FTOP300 테이블에 전송 결과 데이터
AS
BEGIN
-- 처리결과 도메인 체크(전송성공=0, 타켓시스템처리거부=1, 전송대기=8, 재전송필요시=9) 
-- 전송 처리 결과가 데이터 정의 기준정보에 없다면, 처리 거부

	-- 300 테이블에 전송이력을 업데이트 한다.
	UPDATE dbo.FTOP300
		SET 
			IF_MES_TIME = CASE WHEN @ifMesYn = 'Y' THEN dbo.usf_DateStringFormatter(@ifMesTime) END,
			IF_MES_RSLT = CASE WHEN @ifMesYn = 'Y' THEN @ifMesRslt ELSE '0' END,
			IF_CPS_TIME = CASE WHEN @ifCpsYn = 'Y' THEN dbo.usf_DateStringFormatter(@ifCpsTime) END,
			IF_CPS_RSLT = CASE WHEN @ifCpsYn = 'Y' THEN @ifCpsRslt ELSE '0' END,
			UPD_DATE = GETDATE(),
			UPD_USER = 'FTOPSERVER'
	WHERE EQM_CD = @eqmCd AND ITEM_CD = @itemCd AND ITEM_DETAIL_CD = @itemDetailCd AND MAKE_TIME = @makeTime;

	UPDATE dbo.FTOP200 
		SET 
			VALUE_DATA = @valueData, 
			MAKE_TIME = @makeTime,
			IF_MES_TIME = CASE WHEN @ifMesYn = 'Y' THEN dbo.usf_DateStringFormatter(@ifMesTime) END,
			IF_MES_RSLT = CASE WHEN @ifMesYn = 'Y' THEN @ifMesRslt ELSE '0' END,
			IF_CPS_TIME = CASE WHEN @ifCpsYn = 'Y' THEN dbo.usf_DateStringFormatter(@ifCpsTime) END,
			IF_CPS_RSLT = CASE WHEN @ifCpsYn = 'Y' THEN @ifCpsRslt ELSE '0' END,
			UPD_DATE = GETDATE(),
			UPD_USER = 'FTOPSERVER'
	WHERE EQM_CD = @eqmCd AND ITEM_CD = @itemCd AND ITEM_DETAIL_CD = @itemDetailCd AND MAKE_TIME = @makeTime;
	
	IF @@ERROR <> 0
	BEGIN
		SELECT ERROR_NUMBER() as ErrorNumber, ERROR_SEVERITY() as ErrorSeverity ,ERROR_STATE() as ErrorState ,ERROR_PROCEDURE() as ErrorProcedure , ERROR_LINE() as ErrorLine , ERROR_MESSAGE() as ErrorMessage;
		RETURN -1;
	END
	ELSE
	BEGIN
		SELECT 0 as ErrorNumber, 0 as ErrorSeverity ,0 as ErrorState ,0 as ErrorProcedure , 0 as ErrorLine , 0 as ErrorMessage;
		RETURN 0;	
	END
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'회사코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'CORP_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'설비코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'EQM_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'항목코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'ITEM_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'세부항목코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'ITEM_DETAIL_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'설비명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'EQM_NM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사업장코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'PLANT_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사업장명칭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'PLANT_NM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'라인코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'LINE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'라인명칭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'LINE_NM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공정코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'OP_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공정명칭' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'OP_NM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'설명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'DESCR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록사용자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'REG_USER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'REG_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수정자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'UPD_USER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수정일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'UPD_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100', @level2type=N'COLUMN',@level2name=N'USE_YN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FTOP설비기준정보' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP100'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLC 주소' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'PLC_ADDR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLC 타입' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'PLC_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLC IP 주소' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'EQM_IP_ADDR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLC IP PORT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'EQM_IP_PORT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLC ADDR 데이터 타입' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'DATA_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLC 정보 전달 시스템' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'IF_TARGET'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'주소TAG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'ADDR_TAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'설명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'DESCR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록사용자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'REG_USER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'REG_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수정일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'UPD_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110', @level2type=N'COLUMN',@level2name=N'USE_YN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'설비_PLC_수집정보' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP110'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수집시각' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200', @level2type=N'COLUMN',@level2name=N'MAKE_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수집값' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200', @level2type=N'COLUMN',@level2name=N'VALUE_DATA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MES IF여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200', @level2type=N'COLUMN',@level2name=N'IF_MES_YN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MES송신결과' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200', @level2type=N'COLUMN',@level2name=N'IF_MES_RSLT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MES전송시각' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200', @level2type=N'COLUMN',@level2name=N'IF_MES_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CPS전송여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200', @level2type=N'COLUMN',@level2name=N'IF_CPS_YN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CPS전송결과' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200', @level2type=N'COLUMN',@level2name=N'IF_CPS_RSLT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CPS전송시각' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200', @level2type=N'COLUMN',@level2name=N'IF_CPS_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200', @level2type=N'COLUMN',@level2name=N'REG_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FTOP설비상태정보' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP200'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수집시각' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300', @level2type=N'COLUMN',@level2name=N'MAKE_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'수집값' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300', @level2type=N'COLUMN',@level2name=N'VALUE_DATA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MES IF여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300', @level2type=N'COLUMN',@level2name=N'IF_MES_YN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MES송신결과' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300', @level2type=N'COLUMN',@level2name=N'IF_MES_RSLT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MES전송시각' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300', @level2type=N'COLUMN',@level2name=N'IF_MES_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CPS전송여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300', @level2type=N'COLUMN',@level2name=N'IF_CPS_YN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CPS전송결과' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300', @level2type=N'COLUMN',@level2name=N'IF_CPS_RSLT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CPS전송시각' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300', @level2type=N'COLUMN',@level2name=N'IF_CPS_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일시' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300', @level2type=N'COLUMN',@level2name=N'REG_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FTOP설비상태이력정보' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTOP300'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[10] 2[30] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "FTOP100"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 291
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FTOP110"
            Begin Extent = 
               Top = 6
               Left = 256
               Bottom = 284
               Right = 531
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1890
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwFtopDeviceList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwFtopDeviceList'
GO
