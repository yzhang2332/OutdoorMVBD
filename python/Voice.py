from openal.audio import *
from openal.loaders import *
import time

class Sound:
    sources_name = [
       "birds",
       "test",
       ]
    last_source = None
    def __init__(self):
        self.sink = SoundSink()
        self.sink.activate()
        sources = {}
        for name in self.sources_name:
            source = SoundSource()
            source.looping = True
            data = load_wav_file(".\\data\\" + name + ".wav")
            source.queue(data)
            sources[name] = source
        self.sources = sources

    def play(self, s, px, py):
        if self.last_source != None:
            self.sink.stop(self.sources.get(self.last_source))
        source = self.sources.get(s)
        if source == None:
            print("invalid source name")
            return
        source.position = [px, 0, py]
        self.sink.play(source)
        self.sink.update()
        print("play: ", s)
        self.last_source = s

if __name__ == "__main__":
    s = Sound()
    s.play("birds", 1, 0)
    time.sleep(10)
    s.play("test", 10, 0)
    time.sleep(10)
