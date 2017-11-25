<?
	$dbhost = '127.0.0.1';
	$dbuser = 'root';
	$dbpass = 'amin!!';
	$dbname = 'comp';

	$userid = $_POST['inputid'];

//echo $userid;

	$conn = mysql_connect($dbhost, $dbuser, $dbpass);
	//mysql_select_db($dbname,$conn);

	if($conn)
	{
		if(@mysql_select_db($dbname,$conn))
		{
			//echo "<CENTER>==================Monitoring Page=====================</CENTER><br>";
			echo "<br>";
		}else{
			echo "에러 : 데이터베이스 접속 이름 확인.<br>";
			exit();
		}
	}else{
		echo "에러 : 데이터베이스 접속 실패.<br>";
		exit();
	}

	// DB 데이터 가져와서 변수에 넣기 (최근 5개만)
	//$sqlq1 = "SELECT * FROM $userid order by no desc limit 5";

	// DB 데이터 가져와서 변수에 넣기 (최근 10개를 역순으로)

	$sqlq1 = "select * from (select * from $userid order by no desc limit 10) as a order by no asc";

//echo "111디비접속\r\n";
	
	$sql_1 = @mysql_query($sqlq1,$conn);

//echo "222쿼리날리기\r\n";
	
	$counti=0;
	while($row = @mysql_fetch_array($sql_1))
	{
		$outputairpressure[] = $row['outputairpressure'];
		$inoilpressure[] = $row['inoilpressure'];
		$outputairtemp[] = $row['outputairtemp'];
		$inoiltemp[] = $row['inoiltemp'];
		$savetime[] = $row['savetime'];		
		$counti++;
		//echo "\r\n";
	}

//echo "333데이터 저장\r\n";


	for($a=0; $a < $counti; $a++)
	{
		$timedata1[$a] = date("'m월 d일 H시 i분 s초'",strtotime($savetime[$a]));
		//echo nl2br($timedata1[$a]);

	}
	
//echo $timedata1[0];

?>



<meta name="viewport" content="width=device-width, initial-scale=1.0" />

<!DOCTYPE HTML>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<title>IoT Link Test Page</title>

		<style type="text/css">
		#container {
			min-width: 310px;
			max-width: 800px;
			height: 400px;
			margin: 0 auto
		}
		</style>
	</head>

	<body>
	<script src="http://112.218.16.213/test/code/highcharts.js"></script>
	<script src="http://112.218.16.213/test/code/modules/exporting.js"></script>

	<div id="container"></div>

		<script type="text/javascript">

//하이챠트
Highcharts.chart('container', {

    title: {
        text: 'IoT Link 테스트'
    },

    subtitle: {
        text: '계정:<?php echo $userid ?>'
    },

    xAxis: {
	
        categories: [<?php echo join($timedata1, ',') ?>]
    },

    yAxis: {
        title: {
            text: '값'
        }
    },

    plotOptions: {
        line: {
            dataLabels: {
                enabled: true
            },
            enableMouseTracking: true
        }
    },

    legend: {
        layout: 'vertical',
        align: 'right',
        verticalAlign: 'middle'
    },

    series: [{
	name: '토출공기압력',
	data: [<?php echo join($outputairpressure, ',') ?>]
	},{
	name: '내부오일압력',
	data: [<?php echo join($inoilpressure, ',') ?>]
	},{
	name: '토출공기온도',
	data: [<?php echo join($outputairtemp, ',') ?>]
	},{
	name: '내부오일온도',
	data: [<?php echo join($inoiltemp, ',') ?>]
	}]



});
		</script>

<input type=image src="UP.png" width="100" height="100" onClick="location.href='/test/up.php'"><br>
<input type=image src="DOWN.png" width="100" height="100" onClick="location.href='/test/down.php'"><br>


	</body>
</html>
