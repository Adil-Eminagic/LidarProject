import serial
import pandas as pd
import time  # Import the time module
import movingParts as mp

# Initialize the serial connection
serialInst = serial.Serial()
serialInst.baudrate = 115200
serialInst.port = 'COM7'
serialInst.open()




serialInst.write(('start').encode('utf-8'))  # Encode the move as bytes
time.sleep(1)

mp.r(serialInst)
time.sleep(5)


mp.f(serialInst)
time.sleep(5)

# +

# serialInst.write(('r1').encode('utf-8'))  # Encode the move as bytes
# time.sleep(5)

mp.s(serialInst)

# Close the serial connection
serialInst.close()
