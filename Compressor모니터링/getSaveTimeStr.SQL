

delimiter //

Create Function getSaveTimeStr() Returns VARCHAR(20)
Begin
Declare V_RetVal VarChar(20) Default '';

SET V_RetVal = DATE_FORMAT(NOW(),'%Y%m%d%h%i%s');
RETURN V_RetVal;

End 

//

Delimiter ;