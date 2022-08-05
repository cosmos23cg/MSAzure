import speech_recognition as sr 
import time

def callback(recognizer, audio):
    try: 
        print(recognizer.recognize_sphinx(audio))
    except: 
        return

m = sr.Microphone()
r = sr.Recognizer()
stop_listening = r.listen_in_background(m, callback)

while True: 
    time.sleep(1)
