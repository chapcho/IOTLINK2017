-- MySqlBackup.NET 2.0.9.2
-- Dump Time: 2017-12-12 05:45:11
-- --------------------------------------
-- Server version 10.1.16-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of enumdef
-- 

DROP TABLE IF EXISTS `enumdef`;
CREATE TABLE IF NOT EXISTS `enumdef` (
  `EnumName` varchar(50) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `AccessType` varchar(10) DEFAULT NULL,
  `Purpose` varchar(100) DEFAULT NULL,
  `ConstantFlag` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`EnumName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table enumdef
-- 

/*!40000 ALTER TABLE `enumdef` DISABLE KEYS */;

/*!40000 ALTER TABLE `enumdef` ENABLE KEYS */;

-- 
-- Definition of enumdefvalue
-- 

DROP TABLE IF EXISTS `enumdefvalue`;
CREATE TABLE IF NOT EXISTS `enumdefvalue` (
  `EnumName` varchar(50) NOT NULL,
  `EnumValue` varchar(50) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `DisplayOrder` int(11) DEFAULT NULL,
  `DefaultValue` varchar(100) DEFAULT NULL,
  `DisplayColor` varchar(20) DEFAULT NULL,
  `AdditionalValue` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`EnumName`,`EnumValue`),
  CONSTRAINT `EnumDefValue_FK_EnumName` FOREIGN KEY (`EnumName`) REFERENCES `enumdef` (`EnumName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table enumdefvalue
-- 

/*!40000 ALTER TABLE `enumdefvalue` DISABLE KEYS */;

/*!40000 ALTER TABLE `enumdefvalue` ENABLE KEYS */;

-- 
-- Definition of machineinfo
-- 

DROP TABLE IF EXISTS `machineinfo`;
CREATE TABLE IF NOT EXISTS `machineinfo` (
  `MachineName` varchar(50) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `CreateTime` decimal(17,3) DEFAULT NULL,
  `UpdateTime` decimal(17,3) DEFAULT NULL,
  `CreateUser` varchar(100) DEFAULT NULL,
  `UpdateUser` varchar(100) DEFAULT NULL,
  `UpdateReason` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`MachineName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table machineinfo
-- 

/*!40000 ALTER TABLE `machineinfo` DISABLE KEYS */;
INSERT INTO `machineinfo`(`MachineName`,`Description`,`CreateTime`,`UpdateTime`,`CreateUser`,`UpdateUser`,`UpdateReason`) VALUES
('test1','데이터 생성 테스트용 장비',20171112074125.000,20171112074125.000,'manager','manager','manager'),
('test2','test2machine',20171112074125.000,20171112074125.000,'manager','manager','manager'),
('test3','test3machine',20171112074125.000,20171112074125.000,'manager','manager','manager'),
('testMachine','데이터 생성 테스트용 장비',20171112074125.000,20171112074125.000,'manager','manager','manager');
/*!40000 ALTER TABLE `machineinfo` ENABLE KEYS */;

-- 
-- Definition of machinemanager
-- 

DROP TABLE IF EXISTS `machinemanager`;
CREATE TABLE IF NOT EXISTS `machinemanager` (
  `ManagerID` varchar(50) NOT NULL,
  `MachineName` varchar(50) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `CreateTime` decimal(17,3) DEFAULT NULL,
  `UpdateTime` decimal(17,3) DEFAULT NULL,
  `CreateUser` varchar(100) DEFAULT NULL,
  `UpdateUser` varchar(100) DEFAULT NULL,
  `UpdateReason` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ManagerID`,`MachineName`),
  KEY `MachineManager_FK_MachineName` (`MachineName`),
  CONSTRAINT `MachineManager_FK_MachineName` FOREIGN KEY (`MachineName`) REFERENCES `machineinfo` (`MachineName`),
  CONSTRAINT `MachineManager_FK_ManagerId` FOREIGN KEY (`ManagerID`) REFERENCES `manager` (`ManagerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table machinemanager
-- 

/*!40000 ALTER TABLE `machinemanager` DISABLE KEYS */;

/*!40000 ALTER TABLE `machinemanager` ENABLE KEYS */;

-- 
-- Definition of machinestate
-- 

DROP TABLE IF EXISTS `machinestate`;
CREATE TABLE IF NOT EXISTS `machinestate` (
  `MachineName` varchar(50) NOT NULL,
  `LastEventTime` varchar(19) DEFAULT NULL,
  `CurState` varchar(10) DEFAULT NULL,
  `MachineData` varchar(200) DEFAULT NULL,
  `Updated` decimal(17,3) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`MachineName`),
  CONSTRAINT `MachineState_FK_MachineName` FOREIGN KEY (`MachineName`) REFERENCES `machineinfo` (`MachineName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table machinestate
-- 

/*!40000 ALTER TABLE `machinestate` DISABLE KEYS */;
INSERT INTO `machinestate`(`MachineName`,`LastEventTime`,`CurState`,`MachineData`,`Updated`,`Description`) VALUES
('test1','20171210065207.351','Normal','8 ?',20171210065207.351,'Not Initialized Yet!'),
('test2','20171210062525.343','Normal','1 1 ?2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 ',20171210062525.343,'Not Initialized Yet!'),
('test3','20171202055433.428','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055433.428,'EmptyDescription'),
('testMachine','20171119164919.626','Normal','11▦이렇게 데이터가 기록됩니다.',20171119164919.691,'EmptyDescription');
/*!40000 ALTER TABLE `machinestate` ENABLE KEYS */;

-- 
-- Definition of machinestatelog
-- 

DROP TABLE IF EXISTS `machinestatelog`;
CREATE TABLE IF NOT EXISTS `machinestatelog` (
  `MachineName` varchar(50) NOT NULL,
  `LastEventTime` varchar(19) NOT NULL,
  `CurState` varchar(10) DEFAULT NULL,
  `MachineData` varchar(200) DEFAULT NULL,
  `Updated` decimal(17,3) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`MachineName`,`LastEventTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table machinestatelog
-- 

/*!40000 ALTER TABLE `machinestatelog` DISABLE KEYS */;
INSERT INTO `machinestatelog`(`MachineName`,`LastEventTime`,`CurState`,`MachineData`,`Updated`,`Description`) VALUES
('test1','00010101000000.000','Normal','System.Byte[]',20171129043024.971,'EmptyDescription'),
('test1','20171119174248.788','Normal','8▦',20171119174248.937,'EmptyDescription'),
('test1','20171119174255.084','Normal','11▦fsadf',20171119174255.110,'EmptyDescription'),
('test1','20171119174257.318','Normal','11▦fadsf',20171119174257.323,'EmptyDescription'),
('test1','20171119175121.593','Normal','8▦',20171119175121.681,'EmptyDescription'),
('test1','20171119175124.899','Normal','11▦fsadf',20171119175124.998,'EmptyDescription'),
('test1','20171119205248.799','Normal','8▦',20171119205248.936,'EmptyDescription'),
('test1','20171119205304.168','Normal','11▦이렇게 하는게 아닌가 보네?',20171119205304.268,'EmptyDescription'),
('test1','20171119210322.933','Normal','8▦',20171119210322.998,'EmptyDescription'),
('test1','20171119210326.239','Normal','11▦fdsafasd',20171119210326.328,'EmptyDescription'),
('test1','20171119210337.713','Normal','11▦도데체 떻게 해야 하는건가?',20171119210337.784,'EmptyDescription'),
('test1','20171119211021.023','Normal','8▦',20171119211021.109,'EmptyDescription'),
('test1','20171119211024.589','Normal','11▦fdsfsd',20171119211024.641,'EmptyDescription'),
('test1','20171119211026.854','Normal','11▦fsdafsdaf',20171119211026.964,'EmptyDescription'),
('test1','20171119212125.070','Normal','8▦',20171119212125.223,'EmptyDescription'),
('test1','20171119212127.593','Normal','11▦fasdfdas',20171119212127.655,'EmptyDescription'),
('test1','20171119212131.183','Normal','11▦fasdfsd',20171119212131.193,'EmptyDescription'),
('test1','20171119212947.705','Normal','8▦',20171119212947.751,'EmptyDescription'),
('test1','20171119212952.239','Normal','11▦dfsdfasdfds',20171119212952.275,'EmptyDescription'),
('test1','20171119212955.169','Normal','11▦fsdafasdfdas',20171119212955.261,'EmptyDescription'),
('test1','20171119212956.791','Normal','11▦자동 메시지',20171119212956.815,'EmptyDescription'),
('test1','20171119212957.806','Normal','11▦자동 메시지',20171119212957.818,'EmptyDescription'),
('test1','20171119212958.827','Normal','11▦자동 메시지',20171119212958.931,'EmptyDescription'),
('test1','20171119212959.830','Normal','11▦자동 메시지',20171119212959.935,'EmptyDescription'),
('test1','20171119213000.858','Normal','11▦자동 메시지',20171119213000.955,'EmptyDescription'),
('test1','20171119213001.863','Normal','11▦자동 메시지',20171119213001.959,'EmptyDescription'),
('test1','20171119213002.895','Normal','11▦자동 메시지',20171119213002.964,'EmptyDescription'),
('test1','20171119213003.901','Normal','11▦자동 메시지',20171119213003.969,'EmptyDescription'),
('test1','20171119213004.918','Normal','11▦자동 메시지',20171119213004.973,'EmptyDescription'),
('test1','20171119213005.947','Normal','11▦자동 메시지',20171119213005.975,'EmptyDescription'),
('test1','20171119213006.953','Normal','11▦자동 메시지',20171119213006.978,'EmptyDescription'),
('test1','20171119213007.978','Normal','11▦자동 메시지',20171119213007.981,'EmptyDescription'),
('test1','20171119213008.972','Normal','11▦자동 메시지',20171119213008.984,'EmptyDescription'),
('test1','20171119213010.011','Normal','11▦자동 메시지',20171119213010.097,'EmptyDescription'),
('test1','20171119213011.020','Normal','11▦자동 메시지',20171119213011.099,'EmptyDescription'),
('test1','20171120050902.929','Normal','8▦',20171120050902.974,'EmptyDescription'),
('test1','20171120050917.277','Normal','11▦한글 메시지가 어떻게 저장되어야 할까?',20171120050917.311,'EmptyDescription'),
('test1','20171120051518.518','Normal','8▦',20171120051518.559,'EmptyDescription'),
('test1','20171120051523.379','Normal','11▦자동 메시지',20171120051523.413,'EmptyDescription'),
('test1','20171120051524.380','Normal','11▦자동 메시지',20171120051524.422,'EmptyDescription'),
('test1','20171120052348.990','Normal','8▦',20171120052349.049,'EmptyDescription'),
('test1','20171120052353.384','Normal','11▦dfaf',20171120052353.461,'EmptyDescription'),
('test1','20171121050203.448','Normal','8▦',20171121050203.509,'EmptyDescription'),
('test1','20171121050222.210','Normal','11▦waist',20171121050222.229,'EmptyDescription'),
('test1','20171121050858.948','Normal','8▦',20171121050859.091,'EmptyDescription'),
('test1','20171121050907.487','Normal','11▦fdsfsdafdsa',20171121050907.581,'EmptyDescription'),
('test1','20171121050910.297','Normal','11▦fsdfsda',20171121050910.345,'EmptyDescription'),
('test1','20171121053239.287','Normal','8▦',20171121053239.390,'EmptyDescription'),
('test1','20171121053243.199','Normal','11▦fdsfads',20171121053243.262,'EmptyDescription'),
('test1','20171121054523.820','Normal','8▦',20171121054523.876,'EmptyDescription'),
('test1','20171121054527.939','Normal','11▦gfdsgfd',20171121054527.959,'EmptyDescription'),
('test1','20171121054529.180','Normal','11▦gfdsg',20171121054529.181,'EmptyDescription'),
('test1','20171121054917.734','Normal','8▦',20171121054917.807,'EmptyDescription'),
('test1','20171122052358.783','Normal','8▦',20171122052358.811,'EmptyDescription'),
('test1','20171122052410.730','Normal','11▦test ',20171122052410.823,'EmptyDescription'),
('test1','20171122052550.836','Normal','8▦',20171122052550.975,'EmptyDescription'),
('test1','20171122052600.226','Normal','11▦이게 이제[',20171122052600.253,'EmptyDescription'),
('test1','20171122052605.923','Normal','11▦되짆아 봐',20171122052605.993,'EmptyDescription'),
('test1','20171122052618.584','Normal','11▦멋지다.. 이렇게 하면 될것을 ㅋㅋ.',20171122052618.682,'EmptyDescription'),
('test1','20171122052634.145','Normal','8▦',20171122052634.243,'EmptyDescription'),
('test1','20171122052654.285','Normal','11▦자동 메시지',20171122052654.338,'EmptyDescription'),
('test1','20171122052655.319','Normal','11▦자동 메시지',20171122052655.353,'EmptyDescription'),
('test1','20171122052656.318','Normal','11▦자동 메시지',20171122052656.367,'EmptyDescription'),
('test1','20171122052657.359','Normal','11▦자동 메시지',20171122052657.382,'EmptyDescription'),
('test1','20171122052658.354','Normal','11▦자동 메시지',20171122052658.397,'EmptyDescription'),
('test1','20171122052659.385','Normal','11▦자동 메시지',20171122052659.428,'EmptyDescription'),
('test1','20171122052700.367','Normal','11▦자동 메시지',20171122052700.444,'EmptyDescription'),
('test1','20171122052701.426','Normal','11▦자동 메시지',20171122052701.459,'EmptyDescription'),
('test1','20171122052702.400','Normal','11▦자동 메시지',20171122052702.477,'EmptyDescription'),
('test1','20171122052703.447','Normal','11▦자동 메시지',20171122052703.500,'EmptyDescription'),
('test1','20171125055312.123','Normal','test data  with heidesql',201711250553.123,'테스트예요'),
('test1','20171125055312.124','Normal','test data  with heidesql',201711250553.123,'테스트예요'),
('test1','20171125061050.363','Normal','8▦',20171125061050.388,'EmptyDescription'),
('test1','20171125061102.377','Normal','11▦이렇게 저장해야 하는데..',20171125061102.399,'EmptyDescription'),
('test1','20171125061115.254','Normal','11▦한글로 저장할수도 있겠구나!',20171125061115.308,'EmptyDescription'),
('test1','20171125061143.549','Normal','11▦프로시져 호출을 할때는 소문자로만 합시다.',20171125061143.607,'EmptyDescription'),
('test1','20171125061157.658','Normal','11▦이것때문에 하루를 완젼히 ㅠㅠ..',20171125061157.700,'EmptyDescription'),
('test1','20171125062201.900','Normal','8▦',20171125062212.777,'EmptyDescription'),
('test1','20171125062235.568','Normal','11▦hhh',20171125062243.716,'EmptyDescription'),
('test1','20171125063417.837','Normal','8▦',20171125063425.125,'EmptyDescription'),
('test1','20171125063742.337','Normal','8▦',20171125063742.375,'EmptyDescription'),
('test1','20171125063811.425','Normal','11▦test333',20171125063811.516,'EmptyDescription'),
('test1','20171125065015.196','Normal','System.Byte[]',20171125065042.435,'EmptyDescription'),
('test1','20171125065049.272','Normal','System.Byte[]',20171125065157.835,'EmptyDescription'),
('test1','20171125065219.146','Normal','System.Byte[]',20171125065304.454,'EmptyDescription'),
('test1','20171125065326.215','Normal','System.Byte[]',20171125065607.309,'EmptyDescription'),
('test1','20171125065618.221','Normal','System.Byte[]',20171125065725.636,'EmptyDescription'),
('test1','20171125071136.536','Normal','System.Byte[]',20171125071139.338,'EmptyDescription'),
('test1','20171125071204.531','Normal','System.Byte[]',20171125071246.323,'EmptyDescription'),
('test1','20171125071346.816','Normal','System.Byte[]',20171125071428.026,'EmptyDescription'),
('test1','20171130053034.032','Normal','56016637',20171130053034.032,'EmptyDescription'),
('test1','20171130053057.276','Normal','4904901663792213017492184320841862201941922011241853202441881801765189200178228178460',20171130053057.276,'EmptyDescription'),
('test1','20171130053145.487','Normal','49049016637490500510520530540550560570480',20171130053145.487,'EmptyDescription'),
('test1','20171130053215.104','Normal','4904901663797098099010001010102010301040105010601070',20171130053215.104,'EmptyDescription'),
('test1','20171130054250.855','Normal','3800A625',20171130054250.855,'EmptyDescription'),
('test1','20171130054250.868','Normal','31003100A6253100320033003400350036003700380039003000',20171130054250.868,'EmptyDescription'),
('test1','20171202055327.179','Normal','3800A625',20171202055327.179,'EmptyDescription'),
('test1','20171202055355.594','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055355.594,'EmptyDescription'),
('test1','20171202055356.708','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055356.708,'EmptyDescription'),
('test1','20171202055357.713','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055357.713,'EmptyDescription'),
('test1','20171202055358.715','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055358.715,'EmptyDescription'),
('test1','20171202055359.720','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055359.720,'EmptyDescription'),
('test1','20171202055400.724','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055400.724,'EmptyDescription'),
('test1','20171202055401.727','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055401.727,'EmptyDescription'),
('test1','20171202055402.731','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055402.731,'EmptyDescription'),
('test1','20171202055403.736','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055403.736,'EmptyDescription'),
('test1','20171202055404.740','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055404.740,'EmptyDescription'),
('test1','20171202055405.742','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055405.742,'EmptyDescription'),
('test1','20171202055406.858','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055406.858,'EmptyDescription'),
('test1','20171202055407.862','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055407.862,'EmptyDescription'),
('test1','20171202055408.865','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055408.865,'EmptyDescription'),
('test1','20171202055409.871','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055409.871,'EmptyDescription'),
('test1','20171202055410.874','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055410.874,'EmptyDescription'),
('test1','20171202055411.880','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055411.880,'EmptyDescription'),
('test1','20171202055412.884','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055412.884,'EmptyDescription'),
('test1','20171202055413.886','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055413.886,'EmptyDescription'),
('test1','20171202055414.890','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055414.890,'EmptyDescription'),
('test1','20171202055415.900','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055415.900,'EmptyDescription'),
('test1','20171202055416.902','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055416.902,'EmptyDescription'),
('test1','20171202055418.014','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055418.014,'EmptyDescription'),
('test1','20171202055419.016','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055419.016,'EmptyDescription'),
('test1','20171202055426.900','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055426.900,'EmptyDescription'),
('test1','20171202055427.922','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055427.922,'EmptyDescription'),
('test1','20171202055428.943','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055428.943,'EmptyDescription'),
('test1','20171202055429.968','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055429.968,'EmptyDescription'),
('test1','20171202055430.989','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055430.989,'EmptyDescription'),
('test1','20171202055432.037','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055432.037,'EmptyDescription'),
('test1','20171202055433.070','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055433.070,'EmptyDescription'),
('test1','20171202055434.100','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055434.100,'EmptyDescription'),
('test1','20171202055435.010','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055435.010,'EmptyDescription'),
('test1','20171203060220.475','Normal','3800A625',20171203060220.475,'EmptyDescription'),
('test1','20171203060236.900','Normal','3800A625',20171203060236.900,'EmptyDescription'),
('test1','20171203060258.659','Normal','31003100A625310031003100310031003100',20171203060258.659,'EmptyDescription'),
('test1','20171203062915.337','Normal','3800A625',20171203062915.337,'EmptyDescription'),
('test1','20171203062931.671','Normal','31003100A6253100320033003400350036003700',20171203062931.671,'EmptyDescription'),
('test1','20171203062956.466','Normal','31003100A6255CD500AE5CB8200031003100',20171203062956.466,'EmptyDescription'),
('test1','20171210065122.630','Normal','8 ?',20171210065122.630,'Not Initialized Yet!'),
('test1','20171210065207.351','Normal','8 ?',20171210065207.351,'Not Initialized Yet!'),
('test2','00010101000000.000','Normal','System.Byte[]',20171129043400.326,'EmptyDescription'),
('test2','20171119174325.591','Normal','8▦',20171119174325.627,'EmptyDescription'),
('test2','20171119174330.389','Normal','11▦fdsf',20171119174330.488,'EmptyDescription'),
('test2','20171119174357.924','Normal','11▦fdsfds',20171119174358.023,'EmptyDescription'),
('test2','20171119175139.449','Normal','8▦',20171119175139.551,'EmptyDescription'),
('test2','20171119175141.693','Normal','11▦fdsafsd',20171119175141.768,'EmptyDescription'),
('test2','20171122052648.699','Normal','8▦',20171122052648.793,'EmptyDescription'),
('test2','20171122052652.531','Normal','11▦자동 메시지',20171122052652.554,'EmptyDescription'),
('test2','20171122052653.541','Normal','11▦자동 메시지',20171122052653.556,'EmptyDescription'),
('test2','20171122052654.546','Normal','11▦자동 메시지',20171122052654.571,'EmptyDescription'),
('test2','20171122052655.574','Normal','11▦자동 메시지',20171122052655.585,'EmptyDescription'),
('test2','20171122052656.586','Normal','11▦자동 메시지',20171122052656.600,'EmptyDescription'),
('test2','20171122052657.575','Normal','11▦자동 메시지',20171122052657.615,'EmptyDescription'),
('test2','20171122052658.601','Normal','11▦자동 메시지',20171122052658.630,'EmptyDescription'),
('test2','20171122052659.667','Normal','11▦자동 메시지',20171122052659.771,'EmptyDescription'),
('test2','20171122052700.639','Normal','11▦자동 메시지',20171122052700.677,'EmptyDescription'),
('test2','20171122052701.646','Normal','11▦자동 메시지',20171122052701.695,'EmptyDescription'),
('test2','20171122052702.664','Normal','11▦자동 메시지',20171122052702.710,'EmptyDescription'),
('test2','20171122052703.663','Normal','11▦자동 메시지',20171122052703.734,'EmptyDescription'),
('test2','20171122052704.690','Normal','11▦자동 메시지',20171122052704.737,'EmptyDescription'),
('test2','20171130054339.080','Normal','3800A625',20171130054339.080,'EmptyDescription'),
('test2','20171130054346.025','Normal','31003100A62531003100310031003100310031003100',20171130054346.025,'EmptyDescription'),
('test2','20171202053436.917','Normal','3800A625',20171202053436.917,'EmptyDescription'),
('test2','20171202053449.152','Normal','31003100A62550BB7CC5200074C770AC200054BADCC2C0C900AC200000AC34AE200058D594B270AC7CC53F00',20171202053449.152,'EmptyDescription'),
('test2','20171202053511.512','Normal','3800A625',20171202053511.512,'EmptyDescription'),
('test2','20171202053947.850','Normal','3800A625',20171202053947.850,'EmptyDescription'),
('test2','20171202054300.512','Normal','3800A625',20171202054300.512,'EmptyDescription'),
('test2','20171202054303.828','Normal','31003100A625660064006100660073006400',20171202054303.828,'EmptyDescription'),
('test2','20171202054820.828','Normal','3800A625',20171202054820.828,'EmptyDescription'),
('test2','20171202054843.654','Normal','31003100A62574006500730074003200',20171202054843.654,'EmptyDescription'),
('test2','20171202055259.682','Normal','3800A625',20171202055259.682,'EmptyDescription'),
('test2','20171202055312.458','Normal','31003100A6255CD500AE5CB8200054BADCC2C0C97CB92000',20171202055312.458,'EmptyDescription'),
('test2','20171202055334.595','Normal','3800A625',20171202055334.595,'EmptyDescription'),
('test2','20171202055353.485','Normal','31003100A625',20171202055353.485,'EmptyDescription'),
('test2','20171202055423.208','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055423.208,'EmptyDescription'),
('test2','20171202055424.219','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055424.219,'EmptyDescription'),
('test2','20171202055425.331','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055425.331,'EmptyDescription'),
('test2','20171202055426.335','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055426.335,'EmptyDescription'),
('test2','20171202055427.355','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055427.355,'EmptyDescription'),
('test2','20171202055428.378','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055428.378,'EmptyDescription'),
('test2','20171202055429.402','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055429.402,'EmptyDescription'),
('test2','20171202055430.422','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055430.422,'EmptyDescription'),
('test2','20171202055431.336','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055431.336,'EmptyDescription'),
('test2','20171202055432.379','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055432.379,'EmptyDescription'),
('test2','20171202055433.413','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055433.413,'EmptyDescription'),
('test2','20171202055434.445','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055434.445,'EmptyDescription'),
('test2','20171202055435.464','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055435.464,'EmptyDescription'),
('test2','20171202055436.468','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055436.468,'EmptyDescription'),
('test2','20171203060243.116','Normal','3800A625',20171203060243.116,'EmptyDescription'),
('test2','20171203060253.585','Normal','31003100A625310032003300340035003600',20171203060253.585,'EmptyDescription'),
('test2','20171209070944.196','Normal','8 ?',20171209070944.196,'Not Initialized Yet!'),
('test2','20171209070953.561','Normal','1 1 ?t??? T붤쩜?? 0??킔Ю? ',20171209070953.561,'Not Initialized Yet!'),
('test2','20171209071036.368','Normal','1 1 ?1 2 3 4 5 6 ',20171209071036.368,'Not Initialized Yet!'),
('test2','20171209071101.576','Normal','1 1 ?1 1 1 1 1 1 1 1 1 1 1 ',20171209071101.576,'Not Initialized Yet!'),
('test2','20171210055859.593','Normal','8 ?',20171210055859.593,'Not Initialized Yet!'),
('test2','20171210055917.370','Normal','1 1 ?\\?췉?',20171210055917.370,'Not Initialized Yet!'),
('test2','20171210055947.640','Normal','1 1 ?눗 ? 淺눗t?  후? 淺섟꺃t행?',20171210055947.640,'Not Initialized Yet!'),
('test2','20171210055959.316','Normal','1 1 ?1 2 3 4 5 6 7 8 9 0 ',20171210055959.316,'Not Initialized Yet!'),
('test2','20171210062421.549','Normal','8 ?',20171210062421.549,'Not Initialized Yet!'),
('test2','20171210062429.706','Normal','1 1 ?1 2 3 4 5 ',20171210062429.706,'Not Initialized Yet!'),
('test2','20171210062447.870','Normal','1 1 ?1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 ',20171210062447.870,'Not Initialized Yet!'),
('test2','20171210062509.006','Normal','1 1 ?1 1 1 1 1 1 1 1 1 1 1 ',20171210062509.006,'Not Initialized Yet!'),
('test2','20171210062515.512','Normal','1 1 ?1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 ',20171210062515.512,'Not Initialized Yet!'),
('test2','20171210062521.149','Normal','1 1 ?2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 ',20171210062521.149,'Not Initialized Yet!'),
('test2','20171210062525.343','Normal','1 1 ?2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 ',20171210062525.343,'Not Initialized Yet!'),
('test3','20171202055343.006','Normal','3800A625',20171202055343.006,'EmptyDescription'),
('test3','20171202055350.720','Normal','31003100A625',20171202055350.720,'EmptyDescription'),
('test3','20171202055431.469','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055431.469,'EmptyDescription'),
('test3','20171202055432.396','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055432.396,'EmptyDescription'),
('test3','20171202055433.428','Normal','31003100A62590C7D9B3200054BADCC2C0C9',20171202055433.428,'EmptyDescription'),
('testMachine','20171119163343.418','Normal','11▦이 데이터는 샘플 데이터입니다.',20171119163343.493,'EmptyDescription'),
('testMachine','20171119163410.814','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163410.849,'EmptyDescription'),
('testMachine','20171119163411.840','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163411.853,'EmptyDescription'),
('testMachine','20171119163412.863','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163412.966,'EmptyDescription'),
('testMachine','20171119163413.844','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163413.860,'EmptyDescription'),
('testMachine','20171119163414.885','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163414.974,'EmptyDescription'),
('testMachine','20171119163415.893','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163415.979,'EmptyDescription'),
('testMachine','20171119163416.900','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163416.982,'EmptyDescription'),
('testMachine','20171119163417.908','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163417.990,'EmptyDescription'),
('testMachine','20171119163418.968','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163418.995,'EmptyDescription'),
('testMachine','20171119163419.953','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163419.999,'EmptyDescription'),
('testMachine','20171119163420.953','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163421.003,'EmptyDescription'),
('testMachine','20171119163421.988','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163422.007,'EmptyDescription'),
('testMachine','20171119163422.982','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163423.011,'EmptyDescription'),
('testMachine','20171119163424.007','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163424.014,'EmptyDescription'),
('testMachine','20171119163425.006','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163425.018,'EmptyDescription'),
('testMachine','20171119163426.008','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163426.022,'EmptyDescription'),
('testMachine','20171119163427.067','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163427.135,'EmptyDescription'),
('testMachine','20171119163428.070','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163428.138,'EmptyDescription'),
('testMachine','20171119163429.079','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163429.144,'EmptyDescription'),
('testMachine','20171119163430.068','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163430.147,'EmptyDescription'),
('testMachine','20171119163431.077','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163431.149,'EmptyDescription'),
('testMachine','20171119163432.119','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163432.152,'EmptyDescription'),
('testMachine','20171119163433.150','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163433.158,'EmptyDescription'),
('testMachine','20171119163434.149','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163434.161,'EmptyDescription'),
('testMachine','20171119163435.132','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163435.164,'EmptyDescription'),
('testMachine','20171119163436.164','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163436.167,'EmptyDescription'),
('testMachine','20171119163437.161','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163437.174,'EmptyDescription'),
('testMachine','20171119163438.196','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163438.286,'EmptyDescription'),
('testMachine','20171119163439.197','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163439.201,'EmptyDescription'),
('testMachine','20171119163440.218','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163440.314,'EmptyDescription'),
('testMachine','20171119163441.248','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163441.318,'EmptyDescription'),
('testMachine','20171119163442.266','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163442.323,'EmptyDescription'),
('testMachine','20171119163443.282','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163443.325,'EmptyDescription'),
('testMachine','20171119163444.290','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163444.327,'EmptyDescription'),
('testMachine','20171119163445.309','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163445.329,'EmptyDescription'),
('testMachine','20171119163446.291','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163446.331,'EmptyDescription'),
('testMachine','20171119163447.319','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163447.333,'EmptyDescription'),
('testMachine','20171119163448.341','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163448.445,'EmptyDescription'),
('testMachine','20171119163449.346','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163449.449,'EmptyDescription'),
('testMachine','20171119163450.374','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163450.452,'EmptyDescription'),
('testMachine','20171119163451.369','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163451.455,'EmptyDescription'),
('testMachine','20171119163452.377','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163452.458,'EmptyDescription'),
('testMachine','20171119163453.415','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163453.460,'EmptyDescription'),
('testMachine','20171119163454.399','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163454.465,'EmptyDescription'),
('testMachine','20171119163455.418','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163455.468,'EmptyDescription'),
('testMachine','20171119163456.440','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163456.471,'EmptyDescription'),
('testMachine','20171119163457.455','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163457.473,'EmptyDescription'),
('testMachine','20171119163458.462','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163458.475,'EmptyDescription'),
('testMachine','20171119163459.499','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163459.587,'EmptyDescription'),
('testMachine','20171119163500.488','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163500.593,'EmptyDescription'),
('testMachine','20171119163501.506','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163501.596,'EmptyDescription'),
('testMachine','20171119163502.540','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163502.602,'EmptyDescription'),
('testMachine','20171119163503.531','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163503.605,'EmptyDescription'),
('testMachine','20171119163504.547','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163504.608,'EmptyDescription'),
('testMachine','20171119163505.555','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163505.623,'EmptyDescription'),
('testMachine','20171119163506.580','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163506.626,'EmptyDescription'),
('testMachine','20171119163507.593','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163507.628,'EmptyDescription'),
('testMachine','20171119163508.620','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163508.631,'EmptyDescription'),
('testMachine','20171119163509.617','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163509.634,'EmptyDescription'),
('testMachine','20171119163510.635','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163510.636,'EmptyDescription'),
('testMachine','20171119163511.648','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163511.749,'EmptyDescription'),
('testMachine','20171119163512.667','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163512.752,'EmptyDescription'),
('testMachine','20171119163513.712','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163513.755,'EmptyDescription'),
('testMachine','20171119163514.693','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163514.758,'EmptyDescription'),
('testMachine','20171119163515.715','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163515.761,'EmptyDescription'),
('testMachine','20171119163516.720','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163516.764,'EmptyDescription'),
('testMachine','20171119163517.748','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163517.766,'EmptyDescription'),
('testMachine','20171119163518.761','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163518.768,'EmptyDescription'),
('testMachine','20171119163519.770','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163519.880,'EmptyDescription'),
('testMachine','20171119163520.769','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163520.773,'EmptyDescription'),
('testMachine','20171119163521.792','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163521.885,'EmptyDescription'),
('testMachine','20171119163522.808','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163522.887,'EmptyDescription'),
('testMachine','20171119163523.812','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163523.889,'EmptyDescription'),
('testMachine','20171119163524.834','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163524.892,'EmptyDescription'),
('testMachine','20171119163525.841','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163525.896,'EmptyDescription'),
('testMachine','20171119163526.858','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163526.899,'EmptyDescription'),
('testMachine','20171119163527.885','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163527.901,'EmptyDescription'),
('testMachine','20171119163528.903','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163528.904,'EmptyDescription'),
('testMachine','20171119163529.933','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163530.017,'EmptyDescription'),
('testMachine','20171119163530.936','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163530.939,'EmptyDescription'),
('testMachine','20171119163531.920','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163531.941,'EmptyDescription'),
('testMachine','20171119163532.954','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163533.053,'EmptyDescription'),
('testMachine','20171119163533.975','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163534.056,'EmptyDescription'),
('testMachine','20171119163534.977','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163535.059,'EmptyDescription'),
('testMachine','20171119163535.996','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163536.062,'EmptyDescription'),
('testMachine','20171119163537.016','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163537.067,'EmptyDescription'),
('testMachine','20171119163538.038','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163538.072,'EmptyDescription'),
('testMachine','20171119163539.058','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163539.074,'EmptyDescription'),
('testMachine','20171119163540.064','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163540.076,'EmptyDescription'),
('testMachine','20171119163541.074','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163541.084,'EmptyDescription'),
('testMachine','20171119163542.090','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163542.198,'EmptyDescription'),
('testMachine','20171119163543.108','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163543.201,'EmptyDescription'),
('testMachine','20171119163544.123','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163544.204,'EmptyDescription'),
('testMachine','20171119163545.118','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163545.206,'EmptyDescription'),
('testMachine','20171119163546.128','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163546.209,'EmptyDescription'),
('testMachine','20171119163547.183','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163547.211,'EmptyDescription'),
('testMachine','20171119163548.171','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163548.213,'EmptyDescription'),
('testMachine','20171119163549.194','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163549.215,'EmptyDescription'),
('testMachine','20171119163550.206','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163550.217,'EmptyDescription'),
('testMachine','20171119163551.213','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163551.219,'EmptyDescription'),
('testMachine','20171119163552.235','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163552.332,'EmptyDescription'),
('testMachine','20171119163553.212','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163553.256,'EmptyDescription'),
('testMachine','20171119163554.230','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163554.259,'EmptyDescription'),
('testMachine','20171119163555.247','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163555.262,'EmptyDescription'),
('testMachine','20171119163556.258','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163556.265,'EmptyDescription'),
('testMachine','20171119163557.271','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163557.378,'EmptyDescription'),
('testMachine','20171119163558.284','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163558.382,'EmptyDescription'),
('testMachine','20171119163559.308','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163559.387,'EmptyDescription'),
('testMachine','20171119163600.322','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163600.397,'EmptyDescription'),
('testMachine','20171119163601.363','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163601.404,'EmptyDescription'),
('testMachine','20171119163602.366','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163602.412,'EmptyDescription'),
('testMachine','20171119163603.362','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163603.415,'EmptyDescription'),
('testMachine','20171119163604.381','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163604.426,'EmptyDescription'),
('testMachine','20171119163605.406','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163605.429,'EmptyDescription'),
('testMachine','20171119163606.400','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163606.432,'EmptyDescription'),
('testMachine','20171119163607.421','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163607.435,'EmptyDescription'),
('testMachine','20171119163608.446','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163608.548,'EmptyDescription'),
('testMachine','20171119163609.441','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163609.442,'EmptyDescription'),
('testMachine','20171119163610.477','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163610.554,'EmptyDescription'),
('testMachine','20171119163611.495','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163611.557,'EmptyDescription'),
('testMachine','20171119163612.500','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163612.559,'EmptyDescription'),
('testMachine','20171119163613.514','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163613.563,'EmptyDescription'),
('testMachine','20171119163614.524','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163614.565,'EmptyDescription'),
('testMachine','20171119163615.541','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163615.567,'EmptyDescription'),
('testMachine','20171119163616.579','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163616.679,'EmptyDescription'),
('testMachine','20171119163617.579','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163617.659,'EmptyDescription'),
('testMachine','20171119163618.590','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163618.664,'EmptyDescription'),
('testMachine','20171119163619.593','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163619.666,'EmptyDescription'),
('testMachine','20171119163620.611','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163620.670,'EmptyDescription'),
('testMachine','20171119163621.632','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163621.676,'EmptyDescription'),
('testMachine','20171119163622.633','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163622.678,'EmptyDescription'),
('testMachine','20171119163623.661','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163623.683,'EmptyDescription'),
('testMachine','20171119163624.674','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163624.685,'EmptyDescription'),
('testMachine','20171119163625.680','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163625.687,'EmptyDescription'),
('testMachine','20171119163626.702','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163626.799,'EmptyDescription'),
('testMachine','20171119163627.721','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163627.790,'EmptyDescription'),
('testMachine','20171119163628.738','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163628.793,'EmptyDescription'),
('testMachine','20171119163629.734','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163629.797,'EmptyDescription'),
('testMachine','20171119163630.792','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163630.800,'EmptyDescription'),
('testMachine','20171119163631.779','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163631.802,'EmptyDescription'),
('testMachine','20171119163632.793','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163632.808,'EmptyDescription'),
('testMachine','20171119163633.809','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163633.819,'EmptyDescription'),
('testMachine','20171119163634.793','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163634.826,'EmptyDescription'),
('testMachine','20171119163635.833','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163635.940,'EmptyDescription'),
('testMachine','20171119163636.840','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163636.946,'EmptyDescription'),
('testMachine','20171119163637.837','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163637.844,'EmptyDescription'),
('testMachine','20171119163638.879','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163638.957,'EmptyDescription'),
('testMachine','20171119163639.888','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163639.959,'EmptyDescription'),
('testMachine','20171119163640.915','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163640.963,'EmptyDescription'),
('testMachine','20171119163641.896','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163641.965,'EmptyDescription'),
('testMachine','20171119163642.909','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163642.969,'EmptyDescription'),
('testMachine','20171119163643.932','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163643.971,'EmptyDescription'),
('testMachine','20171119163644.950','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163644.975,'EmptyDescription'),
('testMachine','20171119163645.972','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163645.977,'EmptyDescription'),
('testMachine','20171119163646.965','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163646.979,'EmptyDescription'),
('testMachine','20171119163647.994','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163648.091,'EmptyDescription'),
('testMachine','20171119163648.986','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163649.094,'EmptyDescription'),
('testMachine','20171119163650.023','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163650.097,'EmptyDescription'),
('testMachine','20171119163651.043','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163651.099,'EmptyDescription'),
('testMachine','20171119163652.040','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163652.102,'EmptyDescription'),
('testMachine','20171119163653.044','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163653.104,'EmptyDescription'),
('testMachine','20171119163654.074','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163654.107,'EmptyDescription'),
('testMachine','20171119163655.068','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163655.109,'EmptyDescription'),
('testMachine','20171119163656.094','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163656.112,'EmptyDescription'),
('testMachine','20171119163657.100','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163657.114,'EmptyDescription'),
('testMachine','20171119163658.128','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163658.228,'EmptyDescription'),
('testMachine','20171119163659.139','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163659.232,'EmptyDescription'),
('testMachine','20171119163700.162','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163700.237,'EmptyDescription'),
('testMachine','20171119163701.176','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163701.241,'EmptyDescription'),
('testMachine','20171119163702.166','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163702.246,'EmptyDescription'),
('testMachine','20171119163703.194','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163703.250,'EmptyDescription'),
('testMachine','20171119163704.195','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163704.255,'EmptyDescription'),
('testMachine','20171119163705.216','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163705.263,'EmptyDescription'),
('testMachine','20171119163706.229','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163706.267,'EmptyDescription'),
('testMachine','20171119163707.240','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163707.270,'EmptyDescription'),
('testMachine','20171119163708.261','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163708.273,'EmptyDescription'),
('testMachine','20171119163709.262','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163709.276,'EmptyDescription'),
('testMachine','20171119163710.278','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163710.280,'EmptyDescription'),
('testMachine','20171119163711.290','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163711.392,'EmptyDescription'),
('testMachine','20171119163712.309','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163712.395,'EmptyDescription'),
('testMachine','20171119163713.317','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163713.398,'EmptyDescription'),
('testMachine','20171119163714.343','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163714.422,'EmptyDescription'),
('testMachine','20171119163715.380','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163715.444,'EmptyDescription'),
('testMachine','20171119163716.363','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163716.447,'EmptyDescription'),
('testMachine','20171119163717.395','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163717.449,'EmptyDescription'),
('testMachine','20171119163718.391','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163718.451,'EmptyDescription'),
('testMachine','20171119163719.407','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163719.454,'EmptyDescription'),
('testMachine','20171119163720.419','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163720.458,'EmptyDescription'),
('testMachine','20171119163721.442','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163721.460,'EmptyDescription'),
('testMachine','20171119163722.450','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163722.462,'EmptyDescription'),
('testMachine','20171119163723.485','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163723.574,'EmptyDescription'),
('testMachine','20171119163724.472','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163724.576,'EmptyDescription'),
('testMachine','20171119163725.518','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163725.579,'EmptyDescription'),
('testMachine','20171119163726.501','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163726.581,'EmptyDescription'),
('testMachine','20171119163727.551','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163727.583,'EmptyDescription'),
('testMachine','20171119163728.529','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163728.585,'EmptyDescription'),
('testMachine','20171119163729.591','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163729.697,'EmptyDescription'),
('testMachine','20171119163730.561','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163730.589,'EmptyDescription'),
('testMachine','20171119163731.603','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163731.702,'EmptyDescription'),
('testMachine','20171119163732.588','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163732.594,'EmptyDescription'),
('testMachine','20171119163733.628','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163733.706,'EmptyDescription'),
('testMachine','20171119163734.618','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163734.709,'EmptyDescription'),
('testMachine','20171119163735.656','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163735.712,'EmptyDescription'),
('testMachine','20171119163736.650','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163736.715,'EmptyDescription'),
('testMachine','20171119163737.700','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163737.717,'EmptyDescription'),
('testMachine','20171119163738.668','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163738.719,'EmptyDescription'),
('testMachine','20171119163739.710','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163739.721,'EmptyDescription'),
('testMachine','20171119163740.702','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163740.723,'EmptyDescription'),
('testMachine','20171119163741.744','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163741.835,'EmptyDescription'),
('testMachine','20171119163742.735','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163742.838,'EmptyDescription'),
('testMachine','20171119163743.773','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163743.841,'EmptyDescription'),
('testMachine','20171119163744.763','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163744.845,'EmptyDescription'),
('testMachine','20171119163745.797','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163745.848,'EmptyDescription'),
('testMachine','20171119163746.793','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163746.850,'EmptyDescription'),
('testMachine','20171119163747.828','Normal','11▦데이터를 계속 기록해 보겠습니다. 수신 시간이 변경될 것입니다.',20171119163747.852,'EmptyDescription'),
('testMachine','20171119164907.765','Normal','8▦',20171119164907.794,'EmptyDescription'),
('testMachine','20171119164919.626','Normal','11▦이렇게 데이터가 기록됩니다.',20171119164919.691,'EmptyDescription');
/*!40000 ALTER TABLE `machinestatelog` ENABLE KEYS */;

-- 
-- Definition of manager
-- 

DROP TABLE IF EXISTS `manager`;
CREATE TABLE IF NOT EXISTS `manager` (
  `ManagerID` varchar(50) NOT NULL,
  `ManagerName` varchar(200) DEFAULT NULL,
  `ManagerPhoneNo` varchar(50) DEFAULT NULL,
  `ManagerEmail` varchar(50) DEFAULT NULL,
  `Updated` decimal(17,3) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ManagerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table manager
-- 

/*!40000 ALTER TABLE `manager` DISABLE KEYS */;

/*!40000 ALTER TABLE `manager` ENABLE KEYS */;

-- 
-- Dumping procedures
-- 

DROP PROCEDURE IF EXISTS `spUpdateMachineState`;
DELIMITER |
CREATE PROCEDURE `spUpdateMachineState`(IN `machineName` VARCHAR(50), IN `lastEventTime` VARCHAR(19), IN `curState` VARCHAR(10), IN `machineData` VARCHAR(200), IN `updatedDt` DECIMAL(17,3), IN `description` VARCHAR(200))
BEGIN
	-- 설비의 상태를 업데이트 합니다.
	INSERT INTO MACHINESTATE(MachineName,LastEventTime,CurState,MachineData,Updated,Description) VALUES(machineName,lastEventTime,curState,machineData,updatedDt,description)
	ON DUPLICATE KEY UPDATE 	LastEventTime = lastEventTime,CurState = curState,MachineData = machineData,Updated = updatedDt,Description = description;

	-- 설비의 데이터 이력을 추가 합니다.
	INSERT INTO MACHINESTATELOG(MachineName,LastEventTime,CurState,MachineData,Updated,Description) VALUES(machineName,lastEventTime,curState,machineData,updatedDt,description);
	
END |
DELIMITER ;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2017-12-12 05:45:11
-- Total time: 0:0:0:0:124 (d:h:m:s:ms)
