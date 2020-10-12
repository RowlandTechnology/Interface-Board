# Interface Board

A board designed to allow PC access to embedded style electronic signals at 3V3 or 5V.

Includes: ADC / DAC / I2C / IO / Servo / SPI / UART

USB Firmware allows control via a USB connection. Works with a Windows PC but should also work with other USB master based devices.

WIFI Firmware allows control via a WIFI network connection. Works with any networked device including devices via the internet. 
WIFI connection requires the use of the UART peripheral and so this is not available for Slave functionality when using the WIFI firmware.

Board supplied with firmware as requested. Firmware can be changed using a PICkit 3 or PICkit 4 device or similar Microchip programmer.

To setup the WIFI to work with your own network you first need to power up the board using a USB connection or by applying a 5V power supply between the 5V and GND pins. 
Next connect to the WIFI network hosted by the board with the network name InterfaceBoard using password all in lowercase as the Password. 
Visit the website at page 192.168.4.1 and then enter your WIFI network details into the form provided. 
On clicking ok the board will store the details in none volatile memory and attempt to connect to your network and establish a local IP address. 
If all goes ok here then the Interface Board network should dissappear.

Refer to your router configuration page to see the IP address of the device. 

If the WIFI network is not available then the board will revert back to it's setup mode allowing the network to be changed. 
Once network connection is available again the board will automatically reconnect.
