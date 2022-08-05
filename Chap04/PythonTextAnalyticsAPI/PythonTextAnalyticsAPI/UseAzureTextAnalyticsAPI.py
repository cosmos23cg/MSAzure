import requests
from pprint import pprint

subscription_key = "you key"
assert subscription_key

text_analytics_base_url = "https://aien1812textanalytics.cognitiveservices.azure.com/text/analytics/v3.1/entities/health/jobs/"

#Detect Language
language_api_url = text_analytics_base_url + "languages"
print(language_api_url)

documents = { 'documents': [
    { 'id': '1', 'text': 'This is a document written in English.' },
    { 'id': '2', 'text': 'Este es un document escrito en Español.' },
    { 'id': '3', 'text': '这是一个用中文写的文件' },
    { 'id': '4', 'text': '這是一個用中文寫的文件' },
    { 'id': '5', 'text': 'サンプル' },
]}

headers   = {"Ocp-Apim-Subscription-Key": subscription_key}
response  = requests.post(language_api_url, headers=headers, json=documents)
languages = response.json()
pprint(languages)

#Analyze Sentiment
sentiment_api_url = text_analytics_base_url + "sentiment"
print(sentiment_api_url)

documents = {'documents' : [
  {'id': '1', 'language': 'en', 'text': 'I had a wonderful experience! The rooms were wonderful and the staff was helpful.'},
  {'id': '2', 'language': 'es', 'text': 'Los caminos que llevan hasta Monte Rainier son espectaculares y hermosos.'},  
  {'id': '3', 'language': 'zh', 'text': '這次透過訂房網站訂君悅(幫公司的客人訂房)，是我這輩子最糟糕的訂房經驗。那麼大間的飯店請幾個台灣籍人員負責訂房服務應該不困難吧?'}, 
  {'id': '4', 'language': 'ja', 'text': 'ばかやろう'}, 
]}

headers   = {"Ocp-Apim-Subscription-Key": subscription_key}
response  = requests.post(sentiment_api_url, headers=headers, json=documents)
sentiments = response.json()
pprint(sentiments)

#Extract key phrases
key_phrase_api_url = text_analytics_base_url + "keyPhrases"
print(key_phrase_api_url)

documents = {'documents' : [
  {'id': '1', 'language': 'en', 'text': 'I had a wonderful experience! The rooms were wonderful and the staff was helpful.'},
  {'id': '2', 'language': 'en', 'text': 'I had a terrible time at the hotel. The staff was rude and the food was awful.'},  
  {'id': '3', 'language': 'ja', 'text': 'ばかやろう'}, 
  #{'id': '4', 'language': 'zh', 'text': '這次透過訂房網站訂君悅(幫公司的客人訂房)，是我這輩子最糟糕的訂房經驗。那麼大間的飯店請幾個台灣籍人員負責訂房服務應該不困難吧?'}, 
]}
headers   = {'Ocp-Apim-Subscription-Key': subscription_key}
response  = requests.post(key_phrase_api_url, headers=headers, json=documents)
key_phrases = response.json()
pprint(key_phrases)

#Identify linked entities
entity_linking_api_url = text_analytics_base_url + "entities"
print(entity_linking_api_url)

documents = {'documents' : [
  {'id': '1', 'text': 'I really enjoy the new XBox One S. It has a clean look, it has 4K/HDR resolution and it is affordable.'},
  {'id': '2', 'text': 'The Seattle Seahawks won the Super Bowl in 2014.'}
]}

headers   = {"Ocp-Apim-Subscription-Key": subscription_key}
response  = requests.post(entity_linking_api_url, headers=headers, json=documents)
entities = response.json()

pprint(entities)