<html>
<head>
<meta charset="UTF-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=0, user-scalable=no, target-densitydpi=medium-dpi" />

</head>
<body>


<?php
	echo "
		<form action='dataview.php' method=post>
		<table width=100% height=680 cellspacing=0 style=border-collapse:collapse;>
		<tr>
        		<td width=100% height=58 style=border-width:1;>
				<p align=center><span style=font-size:16pt;>
				계정을 입력하세요.<br></span></p>
			</td>
    		</tr>
		
		<tr>
			<td width=100% height=58 style=border-width:1;>
				<p align=center><span style=font-size:16pt;>
				계정 : <input type=text name=inputid size=10>
				</span></p>
			</td>
		</tr>
		    			
		<tr>
			<td width=100% height=58 style=border-width:1;>
				<p align=center>
					<input type=submit class='btn btn-primary' value='결과 보기'>
				</p>
			</td>
		</tr>
		<tr>
			<td width=100% height=58 style=border-width:1;>
				<p align=center>
					
				</p>
			</td>
		</tr>
		</table>

		</form>
		";

?>
</body>
</html>