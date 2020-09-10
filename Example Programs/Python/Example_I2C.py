import time
import RT_IB

ib = RT_IB.Create()

#NOTE: make sure you use your actual COM port value here!
comport = 3
ib.ComOpen(comport)

ib.I2CInitialise()

#Write Example
ib.I2CStart()
ib.I2CSend(0x40<<1) #device address - write mode
ib.I2CSend(0x00) #internal address
ib.I2CSend(0x00) #data byte 0
ib.I2CSend(0x00) #data byte 1
ib.I2CEnd()

#Read Example
ib.I2CStart()
ib.I2CSend(0x40<<1 | 0x01) #device address - read mode
ib.I2CSend(0x00) #internal address
ib.I2CRestart()
data0 = ib.I2CReceive(0) #0 to signify not the last byte to be received
data1 = ib.I2CReceive(1) #1 to signify the last byte received
ib.I2CEnd()

ib.ComClose()



    
