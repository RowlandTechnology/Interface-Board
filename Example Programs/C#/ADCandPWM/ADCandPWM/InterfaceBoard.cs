using System;
using System.IO.Ports;
using System.Threading;

public class InterfaceBoard
{
    SerialPort _serialPort = new SerialPort();

    public InterfaceBoard()
    {
        
    }

    public void OpenPort(int Port)
    {
        String PortStr = "COM" + Port.ToString();

        // Create a new SerialPort object with default settings.
        _serialPort.PortName = PortStr;
        _serialPort.BaudRate = 115200;

        // Set the read/write timeouts
        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;

        _serialPort.Open();
    }

    public void ClosePort()
    {
        _serialPort.Close();
    }




    //Reads an ADC pin as an 8-bit value (0-255)
    public int ADCSample8(int pin)
    {
        byte[] arr1 = new byte[] { 0x9B, (byte)pin, 0 };
        _serialPort.Write(arr1, 0, 3);          //Write Command
        _serialPort.Read(arr1, 0, 3);           //Get Rely
        return (arr1[2]);
    }

    //Reads an ADC pin as an 10-bit value (0-1023)
    public int ADCSample10(int pin)
    {
        byte[] arr1 = new byte[] { 0x9C, (byte)pin, 0, 0 };
        _serialPort.Write(arr1, 0, 4);          //Write Command
        _serialPort.Read(arr1, 0, 4);           //Get Rely
        int retval = (arr1[2] << 8) | arr1[3];
        return (retval);
    }

    //Disables the DAC output pin
    public void DACDisable()
    {
        byte[] arr1 = new byte[] { 0x9E };
        _serialPort.Write(arr1, 0, 1);          //Write Command
        _serialPort.Read(arr1, 0, 1);           //Get Rely
    }

    //Enables the DAC output pin
    public void DACEnable()
    {
        byte[] arr1 = new byte[] { 0x9D };
        _serialPort.Write(arr1, 0, 1);          //Write Command
        _serialPort.Read(arr1, 0, 1);           //Get Rely
    }

    //Outputs a 5-bit value (0-31) to the DAC output pin
    public void DACOutput(int value)
    {
        byte[] arr1 = new byte[] { 0x9F, (byte)value };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
    }

    //Enables the I2C interface
    public void I2CInitialise()
    {
        byte[] arr1 = new byte[] { 0x86 };
        _serialPort.Write(arr1, 0, 1);          //Write Command
        _serialPort.Read(arr1, 0, 1);           //Get Rely
    }

    //Receives a byte from the I2C interface
    public int I2CReceive(int last)
    {
        byte[] arr1 = new byte[] { 0x8B, (byte)last, 0 };
        _serialPort.Write(arr1, 0, 3);          //Write Command
        _serialPort.Read(arr1, 0, 3);           //Get Rely
        return (arr1[2]);
    }

    //Restarts the I2C interface
    public void I2CRestart()
    {
        byte[] arr1 = new byte[] { 0x88 };
        _serialPort.Write(arr1, 0, 1);          //Write Command
        _serialPort.Read(arr1, 0, 1);           //Get Rely
    }

    //Sends a byte to the I2C interface
    public int I2CSend(int data)
    {
        byte[] arr1 = new byte[] { 0x8A, (byte)data, 0 };
        _serialPort.Write(arr1, 0, 3);          //Write Command
        _serialPort.Read(arr1, 0, 3);           //Get Rely
        return (arr1[2]);
    }

    //Starts the I2C interface
    public void I2Start()
    {
        byte[] arr1 = new byte[] { 0x87 };
        _serialPort.Write(arr1, 0, 1);          //Write Command
        _serialPort.Read(arr1, 0, 1);           //Get Rely
    }

    //Stops the I2C interface
    public void I2Stop()
    {
        byte[] arr1 = new byte[] { 0x89 };
        _serialPort.Write(arr1, 0, 1);          //Write Command
        _serialPort.Read(arr1, 0, 1);           //Get Rely
    }

    //Reads a value from a pin
    public int IOGetInputPin(int pin)
    {
        byte[] arr1 = new byte[] { 0x81, (byte)pin, 0 };
        _serialPort.Write(arr1, 0, 3);          //Write Command
        _serialPort.Read(arr1, 0, 3);           //Get Rely
        return (arr1[2]);
    }

    //Write a value to a pin
    public void IOSetOutputPin(int pin, int state)
    {
        byte[] arr1 = new byte[] { 0x80, (byte) pin, (byte) state };
        _serialPort.Write(arr1, 0, 3);          //Write Command
        _serialPort.Read(arr1, 0, 3);           //Get Rely
    }

    //Disables a PWM output channel
    public void PWMDisable(int channel)
    {
        byte[] arr1 = new byte[] { 0x93, (byte)channel };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
    }

    //Enables a PWM output channel
    public void PWMEnable(int channel)
    {
        byte[] arr1 = new byte[] { 0x92, (byte)channel };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
    }

    //Outputs an 8-bit duty (0-255) to the selected PWM output channel
    public void PWMSetDuty8(int channel, int duty)
    {
        byte[] arr1 = new byte[] { 0x95, (byte)channel, (byte)duty };
        _serialPort.Write(arr1, 0, 3);          //Write Command
        _serialPort.Read(arr1, 0, 3);           //Get Rely
    }

    //Outputs a 10-bit duty (0-1023) to the selected PWM output channel
    public void PWMSetDuty10(int channel, int duty)
    {
        byte[] arr1 = new byte[] { 0x96, (byte)channel, (byte)(duty >> 8), (byte)duty };
        _serialPort.Write(arr1, 0, 4);          //Write Command
        _serialPort.Read(arr1, 0, 4);           //Get Rely
    }

    //Sets the PWM output prescaler
    public void PWMSetPrescaler(int scaler)
    {
        byte[] arr1 = new byte[] { 0x94, (byte)scaler };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
    }

    //Enables the SPI interface
    public void SPIInitialise()
    {
        byte[] arr1 = new byte[] { 0x82 };
        _serialPort.Write(arr1, 0, 1);          //Write Command
        _serialPort.Read(arr1, 0, 1);           //Get Rely
    }

    //Sets the SPI output prescaler
    public void SPIPrescaler(int scaler)
    {
        byte[] arr1 = new byte[] { 0x85, (byte)scaler };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
    }

    //Transfers a byte to and from the SPI interface
    public int SPITransfer(int data)
    {
        byte[] arr1 = new byte[] { 0x83, (byte)data, 0 };
        _serialPort.Write(arr1, 0, 3);          //Write Command
        _serialPort.Read(arr1, 0, 3);           //Get Rely
        return (arr1[2]);
    }

    //Disables a Servo output channel
    public void ServoDisable(int channel)
    {
        byte[] arr1 = new byte[] { 0x98, (byte)channel };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
    }

    //Enables a Servo output channel
    public void ServoEnable(int channel)
    {
        byte[] arr1 = new byte[] { 0x97, (byte)channel };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
    }

    //Specifies a Servo output channel position as an 8-bit value (0-255)
    public void ServoSetPosition8(int channel, int position)
    {
        byte[] arr1 = new byte[] { 0x99, (byte)channel, (byte)position };
        _serialPort.Write(arr1, 0, 3);          //Write Command
        _serialPort.Read(arr1, 0, 3);           //Get Rely
    }

    //Specifies a Servo output channel position as an 16-bit value (0-65535)
    public void ServoSetPosition16(int channel, int position)
    {
        byte[] arr1 = new byte[] { 0x9A, (byte)channel, (byte)(position >> 8), (byte)position };
        _serialPort.Write(arr1, 0, 4);          //Write Command
        _serialPort.Read(arr1, 0, 4);           //Get Rely
    }

    //Sets the UART baud rate
    //0=1200, 1=2400, 2=4800, 3=9600, 4=19200, 5=38400, 6=57600, 7=115200
    public void UARTBaud(int baud)
    {
        byte[] arr1 = new byte[] { 0x91, (byte)baud };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
    }

    //Enables the UART interface
    public void UARTInitialise()
    {
        byte[] arr1 = new byte[] { 0x8D };
        _serialPort.Write(arr1, 0, 1);          //Write Command
        _serialPort.Read(arr1, 0, 1);           //Get Rely
    }

    //Receives a byte from the UART receive buffer
    public int UARTReceive()
    {
        byte[] arr1 = new byte[] { 0x90, 0 };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
        return (arr1[1]);
    }

    //Returns the number of bytes in the UART receive buffer
    public int UARTRxCount()
    {
        byte[] arr1 = new byte[] { 0x8F, 0 };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
        return (arr1[1]);
    }

    //Transmits a byte via the UART
    public void UARTTransmit(int data)
    {
        byte[] arr1 = new byte[] { 0x8E, (byte)data };
        _serialPort.Write(arr1, 0, 2);          //Write Command
        _serialPort.Read(arr1, 0, 2);           //Get Rely
    }
}
