const int LED = 13;  // LED는 디지털 핀
                     // 13번에 연결되어 있음

void setup() {
  // put your setup code here, to run once:
  pinMode(LED, OUTPUT);   // 디지털 핀을 출력으로 설정
}

void loop() {
  // put your main code here, to run repeatedly:
  int i =0;

  for(i = 1; i < 30; i++)
  {
      LEDTilting(i*100);
  }
}

void LEDTilting(int delayTime)
{
  digitalWrite(LED, HIGH);
  delay(delayTime);
  digitalWrite(LED,LOW);  
  delay(500);
}
