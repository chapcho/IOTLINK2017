

MariaDB Install

ServiceName : MySQLI

TCP Port : 3307


안녕하세요. 송인정입니다.

MariaDB 10.1.16 버젼을 추가 설치 하였습니다.

접속은 112.218.16.213 서버에서 127.0.0.1:3307로 접근 가능합니다.

Default CharacterSet : UTF8
ServiceName : MySQLI
TcpPort : 3307

입니다.

관리툴은 기존에 사용하던 HeidiSQL에 세션을 추가하였습니다.

=========================================================
MySQL DB Engine 변경
====================
use compdata;

alter table tbm_compressor engine = INNODB;
alter table tbp_compressor engine = INNODB;
alter table tbm_comp_as engine = INNODB;
alter table tbp_comp_as engine = INNODB;
alter table tbm_comp_status engine = INNODB;
alter table tbp_comp_status engine = INNODB;
alter table tbm_comp_set engine = INNODB;
alter table tbp_comp_set engine = INNODB;



use mysql;

create user 'compweb'@'%' identified by 'compWeb!23';

create user 'compweb'@localhost identified by 'compWeb!23';

REVOKE ALL privileges on *.* from 'compweb'@'%';

REVOKE ALL privileges on *.* from 'compweb'@localhost;

grant all privileges on compdata.* to 'compweb'@'%';

grant all privileges on compdata.* to 'compweb'@localhost;


select * from user;

select * from db;

select * from tables_priv;

show GRANTS FOR 'compweb'@'%';

use compdata;


GRANT ALL PRIVILEGES ON *.* to 'compweb'@'%';

GRANT ALL PRIVILEGES ON *.* to 'compweb'@'localhost';

flush privileges;

create user compcomm@'%' identified by 'compComm!23';

create user compcomm@localhost identified by 'compComm!23';

GRANT ALL Privileges ON compdata.* to 'compcomm'@'%';

GRANT ALL Privileges ON compdata.* to 'compcomm'@localhost;

flush privileges;

