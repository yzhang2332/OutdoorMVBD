import threading
import clr
import time
import os
import sys
#import win32com.client as win

binPath = os.path.dirname(os.path.abspath(__file__)) + '/../bin/Debug'
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
    
    file_name = "../bin/debug/scene_1.json"
    draw.UpdateJsonFile(file_name)


#TEXT_SPEAKER = win.Dispatch("SAPI.SpVoice")

#def SendVoiceHandler(type, label):
#    if type == 1:
#        TEXT_SPEAKER.Speak(label)

if __name__ == "__main__":
    draw = FormDrawing("192.168.14.74") # MVBD ip
    #draw = FormDrawing("192.168.14.74", SendVoice(SendVoiceHandler)) # MVBD ip
    app = WinForm.Application

    updateThread = threading.Thread(target=UpdateThread, args=(draw,))
    updateThread.start()
    WinForm.Application.Run(draw)
