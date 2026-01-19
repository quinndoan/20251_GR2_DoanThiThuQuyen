# GR2 Project - 2025.1

A research and development project for an IoT monitoring and control system using the MQTT protocol.

## Introduction
The project includes initial hardware design, firmware programming for microcontrollers, and building a desktop application for data management.

## Project Structure
- `Hardware/`: Contains schematic designs and PCB layouts.
- `Software/firmware/`: Firmware source code for the microcontroller (using PlatformIO & Arduino framework).
    - Interfaces with SSD1306 OLED display.
    - Controls NeoPixel LED strips.
- `Software/application_code/`: Windows management application (C# .NET 8).
    - Connects and receives data via MQTT protocol.
    - User interface built with WinForms.

## Technologies Used
- **Languages:** C++ (Firmware), C# (Application).
- **Protocol:** MQTT (Broker: HiveMQ).
- **Frameworks:** .NET 8, Arduino Platform.
- **Key Libraries:** 
    - `MQTTnet` (C#)
    - `U8g2`, `Adafruit_NeoPixel` (C++)

## Getting Started
1. **Firmware:** Open `Software/firmware/gr2_firmware` in VS Code (with PlatformIO extension) and flash it to the board.
2. **Application:** Open `Software/application_code` and run the project using Visual Studio or with the command `dotnet run`.

---