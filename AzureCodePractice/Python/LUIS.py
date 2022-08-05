from urllib import response
import requests
from pprint import pprint
from module import translate

# LUIS
endpoint = 'https://aien1812luis.cognitiveservices.azure.com'
appid = '6ca35243-b359-44ca-b71e-17e33d6b65be'
key = 'ddd12123ad894f49af7c8120165913dd'

def main():
    query = 'apple'
    #===英翻中===
    query = translate.translateText(query, 'zh-Hant')
    #===========
    url = f'{endpoint}/luis/prediction/v3.0/apps/{appid}/slots/staging/predict?verbose=true&show-all-intents=true&log=true&subscription-key={key}&query={query}'
    response = requests.get(url).json()
    pprint(response)

    topIntent = response['prediction']['topIntent']
    confidence = response['prediction']['intents'][topIntent]['score']

    print(f'意象:{topIntent}, 信心指數:{confidence*100:.2f}%')

if __name__ == '__main__':
    main()
