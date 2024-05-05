#include "esp_camera.h"
#include <WiFi.h>
#define LED 4

const char* ssid = "SPARTA";
const char* password = "danielking12";
const char* host = "192.168.134.170";
const int port = 81;

WiFiClient client;
bool connectedToServer = false;

// Camera configuration
#define CAMERA_MODEL_AI_THINKER // Has PSRAM
#include "camera_pins.h"

void setup() {
  Serial.begin(115200);
  Serial.println();
  pinMode(LED, OUTPUT);
  digitalWrite(4, HIGH);
  // Connect to Wi-Fi
  Serial.print("Connecting to ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  
  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());

  // Camera initialization
  camera_config_t config;
  config.ledc_channel = LEDC_CHANNEL_0;
  config.ledc_timer = LEDC_TIMER_0;
  config.pin_d0 = Y2_GPIO_NUM;
  config.pin_d1 = Y3_GPIO_NUM;
  config.pin_d2 = Y4_GPIO_NUM;
  config.pin_d3 = Y5_GPIO_NUM;
  config.pin_d4 = Y6_GPIO_NUM;
  config.pin_d5 = Y7_GPIO_NUM;
  config.pin_d6 = Y8_GPIO_NUM;
  config.pin_d7 = Y9_GPIO_NUM;
  config.pin_xclk = XCLK_GPIO_NUM;
  config.pin_pclk = PCLK_GPIO_NUM;
  config.pin_vsync = VSYNC_GPIO_NUM;
  config.pin_href = HREF_GPIO_NUM;
  config.pin_sscb_sda = SIOD_GPIO_NUM;
  config.pin_sscb_scl = SIOC_GPIO_NUM;
  config.pin_pwdn = PWDN_GPIO_NUM;
  config.pin_reset = RESET_GPIO_NUM;
  config.xclk_freq_hz = 20000000;
  config.pixel_format = PIXFORMAT_JPEG;
  config.frame_size = FRAMESIZE_QVGA;
  config.jpeg_quality = 12;
  config.fb_count = 1;

  // Initialize the camera
  esp_err_t err = esp_camera_init(&config);
  if (err != ESP_OK) {
    Serial.printf("Camera init failed with error 0x%x", err);
    return;
  }

  Serial.println("Camera initialized");

  // Connect to server
  if (!client.connect(host, port)) {
    Serial.println("Connection to server failed");
    return;
  }

  Serial.println("Connected to server");
  connectedToServer = true;
}

void sendImageTLV(uint8_t* imageData) {
  uint8_t emptyBytes[6] = {0x08, 0, 0, 0, 0, 0};
  emptyBytes[1] = (uint8_t)(5000 & 0xFF); // Second byte (LSB)
  emptyBytes[2] = (uint8_t)((5000>> 8) & 0xFF); // Third byte
  emptyBytes[3] = (uint8_t)((5000 >> 16) & 0xFF); // Fourth byte
  emptyBytes[4] = (uint8_t)((5000 >> 24) & 0xFF); // Fifth byte (MSB)
  client.write(emptyBytes, 6);
  client.write(imageData, 5000);
}



void loop() {
    // Capture a photo
    camera_fb_t * fb = esp_camera_fb_get();
    if (!fb)
      Serial.println("Camera capture failed");

    // Send photo to server using TLV protocol
    if (connectedToServer) {
      Serial.println("Streaming photo to server");
      sendImageTLV(fb->buf); // Send image using TLV protocol
      Serial.println("Photo sent to server");
    } else {
      Serial.println("Connection to server lost. Reconnecting...");
      if (client.connect(host, port)) {
        Serial.println("Reconnected to server");
        connectedToServer = true;
      } else {
        Serial.println("Failed to reconnect to server");
      }
    }

    esp_camera_fb_return(fb); // Release the frame buffer
}
