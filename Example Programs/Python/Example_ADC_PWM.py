import time
import RT_IB

ib = RT_IB.Create()

#NOTE: make sure you use your actual COM port value here!
comport = 3
ib.ComOpen(comport)

ib.PWMEnable(0)

#Reads an ADC pin and outputs the voltage to a PWM pin
loop = 20

while loop>0:
    AdcSample = ib.ADCSample8(0)
    ib.PWMSetDuty8(0, AdcSample)
    time.sleep(0.5)

    loop -= 1

ib.PWMDisable(0)

ib.ComClose()



    
