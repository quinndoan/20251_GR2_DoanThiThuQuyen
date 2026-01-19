#include <Arduino.h>
#include <Wire.h>
#include <U8g2lib.h>
#include <Adafruit_NeoPixel.h>

// --- Cấu hình OLED ---
U8G2_SSD1306_128X32_UNIVISION_F_SW_I2C u8g2(U8G2_R0, /* clock=*/ 22, /* data=*/ 21, /* reset=*/ U8X8_PIN_NONE);

// --- Cấu hình LED ---
#define LED_PIN     4
#define NUM_LEDS    12
Adafruit_NeoPixel pixels(NUM_LEDS, LED_PIN, NEO_GRB + NEO_KHZ800);

void setup() {
  // 1. Khởi động Serial để debug
  Serial.begin(115200);
  delay(1000);
  Serial.println(">>> Lab Project: Core Version Started <<<");

  // 2. Khởi động màn hình OLED
  u8g2.begin();
  u8g2.setFont(u8g2_font_ncenB08_tr); // Chọn font chữ
  
  // Hiển thị thông báo chào mừng
  u8g2.clearBuffer();
  u8g2.drawStr(0, 10, "He thong san sang!");
  u8g2.drawStr(0, 25, "Student: Quyen"); 
  u8g2.sendBuffer();

  // 3. Khởi động dải đèn LED
  pixels.begin();
  pixels.clear(); // Tắt hết đèn
  pixels.show();
}

void loop() {
  // Vòng lặp đơn giản: Chớp tắt đèn LED đỏ
  Serial.println("Loop running...");
  
  // Bật màu ĐỎ
  for(int i=0; i<NUM_LEDS; i++) {
    pixels.setPixelColor(i, pixels.Color(255, 0, 0));
  }
  pixels.show();
  delay(1000);

  // Bật màu XANH
  for(int i=0; i<NUM_LEDS; i++) {
    pixels.setPixelColor(i, pixels.Color(0, 255, 0));
  }
  pixels.show();
  delay(1000);
}