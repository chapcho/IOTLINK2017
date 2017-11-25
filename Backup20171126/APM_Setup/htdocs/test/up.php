<?php
	require("config.php");
	$sql_q1 = "update controls set cmd = '1'";

	if(!@mysql_query($sql_q1))
	{    
		echo "&Answer;SQL Error - ".mysql_error();
		return;
	}

	
?>
<script language="javascript">
	setTimeout("history.back();",10);
</script>