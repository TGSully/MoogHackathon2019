bool didReceive = false;

void setup() {
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);
  Serial.begin(57600);
  while(!Serial);
   
}

void loop() {
  if (didReceive)
  {
    digitalWrite(LED_BUILTIN, HIGH);
    //millis(100);
    digitalWrite(LED_BUILTIN, LOW);
    didReceive =false;
  }

}

void serialEvent()
{
  didReceive = true;
}
