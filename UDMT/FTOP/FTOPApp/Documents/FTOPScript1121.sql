USE [master]
GO
/****** Object:  Database [DYPFTOP]    Script Date: 2016-11-21 오후 1:33:49 ******/
CREATE DATABASE [DYPFTOP] ON  PRIMARY 
( NAME = N'DYPFTOP', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\DYPFTOP.mdf' , SIZE = 265216KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DYPFTOP_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\DYPFTOP_log.ldf' , SIZE = 1623488KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DYPFTOP] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DYPFTOP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DYPFTOP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DYPFTOP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DYPFTOP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DYPFTOP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DYPFTOP] SET ARITHABORT OFF 
GO
ALTER DATABASE [DYPFTOP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DYPFTOP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DYPFTOP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DYPFTOP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DYPFTOP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DYPFTOP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DYPFTOP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DYPFTOP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DYPFTOP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DYPFTOP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DYPFTOP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DYPFTOP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DYPFTOP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DYPFTOP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DYPFTOP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DYPFTOP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DYPFTOP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DYPFTOP] SET  MULTI_USER 
GO
ALTER DATABASE [DYPFTOP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DYPFTOP] SET DB_CHAINING OFF 
GO
USE [DYPFTOP]
GO
/****** Object:  User [root]    Script Date: 2016-11-21 오후 1:33:49 ******/
CREATE USER [root] FOR LOGIN [root] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [root]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [root]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [root]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [root]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [root]
GO
ALTER ROLE [db_datareader] ADD MEMBER [root]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [root]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [root]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [root]
GO
/****** Object:  UserDefinedFunction [dbo].[GetClient]    Script Date: 2016-11-21 오후 1:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[GetClient](@EQM_IP_ADDR nVarChar(50))
 Returns @temp_table Table(
  IP  nVarChar(50)
 )
 As
 Begin
  Declare @Return_Value Int;
  
  Set @Return_Value = @EQM_IP_ADDR;
  
  Insert Into @temp_table
  Select DepartmentID, Name, GroupName
  From HumanResources.Department
  Where DepartmentID = @Return_Value;
  
  Return;
 End
GO
/****** Object:  UserDefinedFunction [dbo].[usf_DateStringFormatter]    Script Date: 2016-11-21 오후 1:33:49 ******/
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
/****** Object:  Table [dbo].[A]    Script Date: 2016-11-21 오후 1:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A](
	[F1] [nvarchar](255) NULL,
	[F2] [nvarchar](255) NULL,
	[F3] [nvarchar](255) NULL,
	[F4] [nvarchar](255) NULL,
	[F5] [nvarchar](255) NULL,
	[F6] [float] NULL,
	[F7] [nvarchar](255) NULL,
	[F8] [float] NULL,
	[F9] [nvarchar](255) NULL,
	[F10] [nvarchar](255) NULL,
	[F11] [nvarchar](255) NULL,
	[F12] [nvarchar](255) NULL,
	[F13] [nvarchar](255) NULL,
	[F14] [nvarchar](255) NULL,
	[F15] [nvarchar](255) NULL,
	[F16] [nvarchar](255) NULL,
	[F17] [nvarchar](255) NULL,
	[F18] [nvarchar](255) NULL,
	[F19] [nvarchar](255) NULL,
	[F20] [nvarchar](255) NULL,
	[F21] [nvarchar](255) NULL,
	[F22] [nvarchar](255) NULL,
	[F23] [nvarchar](255) NULL,
	[F24] [nvarchar](255) NULL,
	[F25] [nvarchar](255) NULL,
	[F26] [nvarchar](255) NULL,
	[F27] [nvarchar](255) NULL,
	[F28] [nvarchar](255) NULL,
	[F29] [nvarchar](255) NULL,
	[F30] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FTOP100]    Script Date: 2016-11-21 오후 1:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTOP100](
	[CORP_CD] [nvarchar](4) NOT NULL,
	[GTR_ID] [nvarchar](10) NOT NULL,
	[EQM_CD] [nvarchar](8) NULL,
	[ITEM_CD] [nvarchar](8) NULL,
	[ITEM_DETAIL_CD] [nvarchar](8) NULL,
	[ITEM_DETAIL_NM] [nvarchar](50) NULL,
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
/****** Object:  Table [dbo].[FTOP110]    Script Date: 2016-11-21 오후 1:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTOP110](
	[CORP_CD] [nvarchar](10) NOT NULL,
	[GTR_ID] [nvarchar](10) NOT NULL,
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
/****** Object:  Table [dbo].[FTOP200]    Script Date: 2016-11-21 오후 1:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTOP200](
	[GTR_ID] [nvarchar](10) NOT NULL,
	[MAKE_TIME] [nvarchar](30) NULL,
	[VALUE_DATA] [nvarchar](8) NULL,
	[UPD_USER] [nvarchar](50) NULL,
	[UPD_DATE] [datetime] NULL,
 CONSTRAINT [PK_FTOP200_1] PRIMARY KEY CLUSTERED 
(
	[GTR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FTOP300]    Script Date: 2016-11-21 오후 1:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTOP300](
	[CORP_CD] [nvarchar](10) NULL,
	[GTR_ID] [nvarchar](10) NOT NULL,
	[MAKE_TIME] [nvarchar](30) NOT NULL,
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
 CONSTRAINT [PK_FTOP300_1] PRIMARY KEY CLUSTERED 
(
	[GTR_ID] ASC,
	[MAKE_TIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vwFtopDeviceList]    Script Date: 2016-11-21 오후 1:33:49 ******/
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
               dbo.FTOP110.DESCR AS OPC_SVR, dbo.FTOP100.GTR_ID, dbo.FTOP110.PLC_NM, 
               dbo.FTOP110.PLC_CHNL
FROM     dbo.FTOP100 INNER JOIN
               dbo.FTOP110 ON dbo.FTOP100.CORP_CD = dbo.FTOP110.CORP_CD AND 
               dbo.FTOP100.GTR_ID = dbo.FTOP110.GTR_ID
WHERE  (dbo.FTOP100.USE_YN = 'Y') AND (dbo.FTOP110.USE_YN = 'Y')


GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idxFTOP300_CpsRslt]    Script Date: 2016-11-21 오후 1:33:49 ******/
CREATE NONCLUSTERED INDEX [idxFTOP300_CpsRslt] ON [dbo].[FTOP300]
(
	[IF_CPS_RSLT] ASC,
	[MAKE_TIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idxFTOP300_MesRslt]    Script Date: 2016-11-21 오후 1:33:49 ******/
CREATE NONCLUSTERED INDEX [idxFTOP300_MesRslt] ON [dbo].[FTOP300]
(
	[IF_MES_RSLT] ASC,
	[MAKE_TIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_FTOP200_CU_001]    Script Date: 2016-11-21 오후 1:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_FTOP200_CU_001]
(
	@corpCd nvarchar(4),
	@gtrId nvarchar(10),
	@makeTime nvarchar(30),
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
	WHERE CORP_CD = @corpCd AND GTR_ID = @gtrId;
	
	-- Update 문장의 @@RowCount는 바로 다음라인까지 유효합니다.
	IF @@ROWCOUNT = 0
	BEGIN
		IF @ifMesYn = 'N' AND @ifCpsYn = 'N'
		BEGIN
			INSERT dbo.FTOP200(CORP_CD, GTR_ID,MAKE_TIME,VALUE_DATA,IF_MES_YN,IF_MES_TIME,IF_CPS_YN,IF_CPS_TIME,REG_DATE) 
			SELECT @corpCd, @gtrId, @makeTime, @valueData, @ifMesYn, GetDate(), @ifCpsYn, GetDate(), GETDATE();		
		END
		ELSE
		BEGIN
			INSERT dbo.FTOP200(CORP_CD, GTR_ID, MAKE_TIME,VALUE_DATA,IF_MES_YN,IF_CPS_YN,REG_DATE) 
			SELECT @corpCd, @gtrId, @makeTime, @valueData, @ifMesYn, @ifCpsYn, GETDATE();
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
/****** Object:  StoredProcedure [dbo].[usp_FTOP300_C_001]    Script Date: 2016-11-21 오후 1:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_FTOP300_C_001]
(
	@gtrId nvarchar(10),
	@makeTime nvarchar(30),
	@valueData nvarchar(8)
)
AS

BEGIN
 -- 처리결과 도메인 체크(전송성공=0, 타켓시스템처리거부=1, 전송대기=8, 재전송필요시=9) 

 -- MakeTime Key 기준으로 중복된 키를 체크하여 FTOP300 Write...
 --IF NOT EXISTS (SELECT * FROM dbo.FTOP300 WHERE MAKE_TIME = @makeTime AND GTR_ID != @gtrId)
   --BEGIN
	INSERT dbo.FTOP300(CORP_CD, GTR_ID, MAKE_TIME, VALUE_DATA, IF_MES_YN, IF_MES_RSLT, IF_MES_TIME, IF_CPS_YN, IF_CPS_RSLT, IF_CPS_TIME, REG_USER, REG_DATE,UPD_USER,UPD_DATE) 
	SELECT CORP_CD, GTR_ID, @makeTime, @valueData,
	 CASE WHEN IF_TARGET = 'MES' OR IF_TARGET = 'ALL' THEN 'Y' ELSE 'N' END,'8', null ,
	 CASE WHEN IF_TARGET = 'CPS' OR IF_TARGET = 'ALL' THEN 'Y' ELSE 'N' END,'8', null , 
	 'FTOPCLIENT',GETDATE(),'FTOPCLIENT',GETDATE()
	FROM dbo.FTOP110 WHERE GTR_ID = @gtrId;
   --END

   -- GRT ID Key 기준으로 중복키 확인 후 업데이트 또는 생성
	IF EXISTS(SELECT * FROM dbo.FTOP200 WHERE GTR_ID = @gtrId)
		UPDATE dbo.FTOP200
		SET MAKE_TIME = @makeTime , VALUE_DATA = @valueData , UPD_USER ='FTOPCLIENT' , UPD_DATE = GETDATE()
		WHERE GTR_ID = @gtrId
	ELSE
		INSERT dbo.FTOP200(GTR_ID, MAKE_TIME, VALUE_DATA,UPD_USER,UPD_DATE)
		VALUES (@gtrId , @makeTime, @valueData ,'FTOPCLIENT' , GETDATE());

	IF @@ERROR <> 0
	BEGIN
		SELECT ERROR_NUMBER() as ErrorNumber, ERROR_SEVERITY() as ErrorSeverity ,ERROR_STATE() as ErrorState ,ERROR_PROCEDURE() as ErrorProcedure , ERROR_LINE() as ErrorLine , ERROR_MESSAGE() as ErrorMessage;
		RETURN -1;
	END
	ELSE
	BEGIN
		SELECT 0 as ErrorNumber, 0 as ErrorSeverity ,0 as ErrorState ,0 as ErrorProcedure , 0 as ErrorLine , 0 as ErrorMessage;
		RETURN -1;	
	END
END

GO
/****** Object:  StoredProcedure [dbo].[usp_FTOP300_U_001]    Script Date: 2016-11-21 오후 1:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_FTOP300_U_001]
(
 @gtrId nvarchar(10),
 @makeTime nvarchar(50),
 @ifMesRslt nvarchar(50),
 @ifCpsRslt nvarchar(50)
)
AS

BEGIN
 -- 처리결과 도메인 체크(전송성공=0, 타켓시스템처리거부=1, 전송대기=8, 재전송필요시=9) 
 -- 송수신 이력을 기록하고..
 UPDATE dbo.FTOP300
 SET IF_MES_RSLT = @ifMesRslt , IF_MES_TIME = GETDATE() , IF_CPS_RSLT = @ifCpsRslt , IF_CPS_TIME = GETDATE()
 FROM dbo.FTOP300 WHERE MAKE_TIME = @makeTime;
END

 IF @@ERROR <> 0
 BEGIN
  SELECT ERROR_NUMBER() as ErrorNumber, ERROR_SEVERITY() as ErrorSeverity ,ERROR_STATE() as ErrorState ,ERROR_PROCEDURE() as ErrorProcedure , ERROR_LINE() as ErrorLine , ERROR_MESSAGE() as ErrorMessage;
  -- 에러 이력을 시스템 로그에 남기고 저장 실패한 데이터는 버려야 합니다.
  RETURN -1;
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
         Configuration = "(H (1[36] 4[12] 2[34] 3) )"
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
USE [master]
GO
ALTER DATABASE [DYPFTOP] SET  READ_WRITE 
GO
