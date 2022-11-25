from openal.audio import *
from openal.loaders import *
import time
import copy

class Sound:
    name_map = {
        "鸟": "birds",
        "树": "test"
    }
    sources_name = [
       "birds",
       "test",
       ]
    # last_source = None
    def __init__(self):
        self.sink = SoundSink()
        self.sink.activate()
        sources_map = {}
        for name in self.sources_name:
            source = SoundSource()
            source.looping = True
            data = load_wav_file(".\\data\\" + name + ".wav")
            source.queue(data)
            sources[name] = source
        self.sources_map = sources
        self.sources = []

    # def play(self, s, px, py):
    #     if self.last_source != None:
    #         self.sink.stop(self.sources.get(self.last_source))
    #     source = self.sources.get(s)
    #     if source == None:
    #         print("invalid source name")
    #         return
    #     source.position = [px, 0, py]
    #     self.sink.play(source)
    #     self.sink.update()
    #     print("play: ", s)
    #     self.last_source = s        

    def play(self, datas):
        if len(self.sources) > 0:
            self.sink.stop(self.sources)
            self.sources = []
        for d in datas:
            name = sources_name.get(d.name)
            source = copy.deepcopy(self.sources_map.get(name))
            if source == None:
                continue
            source.position = [d.cx, 0, d.cy]
            self.sources.append(source)
        self.sink.play(self.sources)
        self.sink.update()
            

if __name__ == "__main__":
    s = Sound()
    while 1:
        s.play("birds", 1, 0)
        time.sleep(10)
    # s.play("test", 10, 0)
    # time.sleep(10)
