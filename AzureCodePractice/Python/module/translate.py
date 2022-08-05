import requests

transEndpoint = 'https://api.cognitive.microsofttranslator.com/'
transKey = 'a13d0676ecd74de8bd5cc3ebb06d9330'
transRegion = 'westus2'

def translateText(query, to):    
    params = f'to={to}'
    transUrl = f'{transEndpoint}/translate?api-version=3.0&{params}'
    transHeaders = {
        'Ocp-Apim-Subscription-Key':transKey,
        'Ocp-Apim-Subscription-Region':transRegion,
        'Content-type':'application/json'
    }
    data=[{'text':query}]
    translateResponse = requests.post(transUrl, headers=transHeaders, json=data)

    translatedText = translateResponse[0]['translations'][0]['text']
    return translatedText
