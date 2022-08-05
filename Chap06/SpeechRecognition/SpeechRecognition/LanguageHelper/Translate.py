import os, requests, uuid, json
import uuid
from pprint import pprint

subscriptionKey = '8740d4e8a20d410c8b240fb06a7eeb36'
endpointUrl = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0"

def TranslateText(text, toLanguage):
    # If you encounter any issues with the base_url or path, make sure
    # that you are using the latest endpoint: https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
    params = f'&to={toLanguage}'
    constructed_url = f"{endpointUrl}{params}"
    headers = {
        'Ocp-Apim-Subscription-Key': subscriptionKey,
        'Ocp-Apim-Subscription-Region' : 'eastus2',
        'Content-type': 'application/json',
        'charset':'UTF-8',
        'X-ClientTraceId': str(uuid.uuid4())
    }
    # You can pass more than one object in body.
    body = [{
        'text' : f'{text}'
    }]
    response = requests.post(constructed_url, headers=headers, json=body).json()
    #pprint(response)
    return response[0]["translations"][0]["text"]