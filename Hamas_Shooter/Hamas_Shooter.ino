#include <ili9341.h>
static int8_t Send_buf[8] = {0};
uint16_t x, y;
#define CMD_NEXT_SONG 0X01
#define CMD_PREV_SONG 0X02
#define CMD_PLAY_W_INDEX 0X03
#define CMD_VOLUME_UP 0X04
#define CMD_VOLUME_DOWN 0X05
#define CMD_SET_VOLUME 0X06
#define CMD_SINGLE_CYCLE_PLAY 0X08
#define CMD_SEL_DEV 0X09
#define DEV_TF 0X02
#define CMD_SLEEP_MODE 0X0A
#define CMD_WAKE_UP 0X0B
#define CMD_RESET 0X0C
#define CMD_PLAY 0X0D
#define CMD_PAUSE 0X0E
#define CMD_PLAY_FOLDER_FILE 0X0F
#define CMD_STOP_PLAY 0X16
#define CMD_FOLDER_CYCLE 0X17
#define CMD_SET_SINGLE_CYCLE 0X19
#define SINGLE_CYCLE_ON 0X00
#define SINGLE_CYCLE_OFF 0X01
#define CMD_SET_DAC 0X1A
#define DAC_ON  0X00
#define DAC_OFF 0X01
#define CMD_PLAY_W_VOL 0X22

void setup() {
  Serial.begin(9600);
  Serial2.begin(9600, SERIAL_8N1);
  delay(500);

 // sendCommand(CMD_SEL_DEV, 0, DEV_TF);
  delay(200);

  tft.init();
  tft.setRotation(1);
  uint16_t calData[5] = {361, 3474, 295, 3379, 7};
  tft.setTouch(calData);

  printTFT();
}

void loop()
{

  if (tft.getTouch(&x, &y))
  {
    if(x > 60 && y > 45 && x < 260 && y < 115)
    {
      sendCommand(0x22, 0x1E, 0x01);
      tft.fillScreen(TFT_RED);
      delay(500);
      printTFT();
    }
  }
}
void printTFT()
{
  tft.fillScreen(TFT_WHITE);
  tft.fillRect(60, 45, 200, 70, TFT_GREEN);
  tft.setTextSize(4);
  tft.setTextColor(TFT_WHITE, TFT_GREEN);
  tft.drawString( "SHOOT", 110, 65 );
}

void sendCommand(byte command, byte option1, byte option2) 
{
  Send_buf[0] = 0x7e;
  Send_buf[1] = 0xff;
  Send_buf[2] = 0x06;
  Send_buf[3] = command;
  Send_buf[4] = 0x00;
  Send_buf[5] = option1;
  Send_buf[6] = option2;
  Send_buf[7] = 0xef;
  for (uint8_t i = 0; i < 8; i++)
  {
    Serial2.write(Send_buf[i]);
  }
}
