import time
import RT_IB

ib = RT_IB.Create()

#NOTE: make sure you use your actual COM port value here!
comport = 3
ib.ComOpen(comport)

#Toggles an output pin on and off the specified number of times
loop = 10

while loop>0:
    ib.IOSetOutputPin(0, 1)
    time.sleep(0.5)

    ib.IOSetOutputPin(0, 0)
    time.sleep(0.5)

    loop -= 1

ib.ComClose()



    
