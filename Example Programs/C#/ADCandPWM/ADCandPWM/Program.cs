using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCandPWM
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceBoard _ib = new InterfaceBoard();

            //Open COM port, make sure this matches your COM port number.
            _ib.OpenPort(3);

            int loop = 100;
            int adcSample;

            _ib.PWMEnable(0);                           //Enable PWM channel 1
            _ib.PWMEnable(1);                           //Enable PWM channel 2
            _ib.PWMSetPrescaler(0);                     //Set Prescaler 1:1

            while (loop > 0)
            {
                adcSample = _ib.ADCSample8(0);          //Read ADC channel 0
                _ib.PWMSetDuty8(0, adcSample);          //Write PWM duty
                System.Threading.Thread.Sleep(100);     //Delay for 100ms
                loop--;
            }

            _ib.PWMDisable(0);                          //Disable PWM channel 1
            _ib.PWMDisable(1);                          //Disable PWM channel 2
            _ib.ClosePort();                            //Remember to close port when program finished
        }
    }
}
