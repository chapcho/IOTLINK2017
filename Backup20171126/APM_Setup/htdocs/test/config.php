<?php

$dbhost = 'localhost';

$dbuser = 'root';
$dbpass = 'amin!!';
$dbname = 'comp';

$conn = @mysql_connect($dbhost, $dbuser, $dbpass);
@mysql_select_db($dbname,$conn);
?>
