import json
import requests
from pprint import pprint

YOUR_API_KEY = 'your key'
YOUR_AUDIO_FILE = 'Voice1.wav'
#YOUR_AUDIO_FILE = 'Voice2.wav'
REGION = 'eastus' # westus, eastasia, northeurope 
MODE = 'interactive'
LANG = 'en-US'
#LANG = 'zh-TW'
FORMAT = 'simple'

def SpeechRecognize():
    # 1. Get an Authorization Token
    token = get_token()
    # 2. Perform Speech Recognition
    results = get_text(token, YOUR_AUDIO_FILE)
    # 3. Print Results
    pprint(results)

def get_token():
    # Return an Authorization Token by making a HTTP POST request to Cognitive Services with a valid API key.
    url = 'https://api.cognitive.microsoft.com/sts/v1.0/issueToken'
    headers = {
        'Ocp-Apim-Subscription-Key': YOUR_API_KEY
    }
    r = requests.post(url, headers=headers)
    token = r.content
    return(token)

def get_text(token, audio):
    # Request that the Bing Speech API convert the audio to text
    url = 'https://{0}.stt.speech.microsoft.com/speech/recognition/{1}/cognitiveservices/v1?language={2}&format={3}'.format(REGION, MODE, LANG, FORMAT)
    headers = {
        'Accept': 'application/json',
        'Ocp-Apim-Subscription-Key': YOUR_API_KEY,
        'Transfer-Encoding': 'chunked',
        'Content-type': 'audio/wav; codec=audio/pcm; samplerate=16000',
        'Authorization': 'Bearer {0}'.format(token)
    }
    r = requests.post(url, headers=headers, data=stream_audio_file(audio))
    results = json.loads(r.content)
    return results

def stream_audio_file(speech_file, chunk_size=1024):
    # Chunk audio file
    with open(speech_file, 'rb') as f:
        while 1:
            data = f.read(chunk_size)
            if not data:
                break
            yield data

SpeechRecognize()

