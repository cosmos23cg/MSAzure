import requests
from pprint import pprint


endpoint = 'https://aien1812contentmoderator.cognitiveservices.azure.com'
key = 'a83994a5f42e4a1cba536249e5af7c3e'

headers = {
    'Content-Type': 'text/plain',
    'Ocp-Apim-Subscription-Key': key,
}

params = {
    'autocorrect': 'Ture',
    'PII': 'True',
    'classify':"True",
    'language': 'eng',
}

str = "fuck"

response = requests.post(f'{endpoint}/contentmoderator/moderate/v1.0/ProcessText/DetectLanguage', headers=headers, params=params, data=str)
result = response.json()
pprint(result)
