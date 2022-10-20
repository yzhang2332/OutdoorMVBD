import threading
import clr
import time
import os
import sys

binPath = os.path.dirname(os.path.abspath(__file__)) + '\\..\\bin\\Debug'
print(binPath)
sys.path.append(binPath)

clr.FindAssembly("MVBDClient.dll")
clr.AddReference("MVBDClient")

from Metec.MVBDClient import *
import System.Windows.Forms as WinForm

def UpdateThread(draw):
    #wait for connection
    while not draw.IsConnected():
        time.sleep(1)
    
    draw.UpdateJsonFile("scene.json")
    time.sleep(10)
    draw.UpdateJsonFile("scene_info.json")

if __name__ == "__main__":
    draw = FormDrawing("192.168.2.119") # MVBD ip
    app = WinForm.Application

    updateThread = threading.Thread(target=UpdateThread, args=(draw,))
    updateThread.start()
    WinForm.Application.Run(draw)