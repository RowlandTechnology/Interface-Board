using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LEDFlash
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceBoard _ib = new InterfaceBoard();

            //Open COM port, make sure this matches your COM port number.
            _ib.OpenPort(3);

            int loop = 10;

            while (loop > 0)
            {
                _ib.IOSetOutputPin(0, 1);               //Output Pin 0 High
                System.Threading.Thread.Sleep(500);     //Delay for 500ms

                _ib.IOSetOutputPin(0, 0);               //Output Pin 0 Low
                System.Threading.Thread.Sleep(500);     //Delay for 500ms

                loop--;
            }

            _ib.ClosePort();                            //Remember to close port when program finished
        }
    }
}
