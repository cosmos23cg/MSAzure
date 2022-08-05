# -*- coding: utf-8 -*-

import os
from azure.cognitiveservices.language.textanalytics import TextAnalyticsClient
from msrest.authentication import CognitiveServicesCredentials

subscription_key = "ab949bd053314032bf78058b292fe779"
endpoint = "https://msit123textanalyticsapi.cognitiveservices.azure.com/"

def authenticateClient():
    credentials = CognitiveServicesCredentials(subscription_key)
    text_analytics_client = TextAnalyticsClient(endpoint=endpoint, credentials=credentials)
    return text_analytics_client

def sentiment():    
    client = authenticateClient()
    try:
        documents = [
            {"id": "1", "language": "en", "text": "I had the worst day of my life."},
            {"id": "2", "language": "en", "text": "This was a waste of my time. The speaker put me to sleep."},
            {"id": "3", "language": "es", "text": "No tengo dinero ni nada que dar..."},
            {"id": "4", "language": "it", "text": "L'hotel veneziano era meraviglioso. È un bellissimo pezzo di architettura."}
        ]
        response = client.sentiment(documents=documents)
        for document in response.documents:
            print("Document Id: ", document.id, ", Sentiment Score: ", "{:.2f}".format(document.score))
    except Exception as err:
        print("Encountered exception. {}".format(err))

def language_detection():
    client = authenticateClient()

    try:
        documents = [
            {'id': '1', 'text': 'This is a document written in English.'},
            {'id': '2', 'text': 'Este es un document escrito en Español.'},
            {'id': '3', 'text': '这是一个用中文写的文件'},
            {'id': '4', 'text': 'ただいま放送中'},
            {'id': '5', 'text': '양념치킨'},
        ]
        response = client.detect_language(documents=documents)

        for document in response.documents:
            print("Document Id: ", document.id, ", Language: ",
                  document.detected_languages[0].name)

    except Exception as err:
        print("Encountered exception. {}".format(err))

def entity_recognition():
    
    client = authenticateClient()

    try:
        documents = [
            {"id": "1", "language": "en", "text": "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and sell BASIC interpreters for the Altair 8800."},
            {"id": "2", "language": "es", "text": "La sede principal de Microsoft se encuentra en la ciudad de Redmond, a 21 kilómetros de Seattle."},
            {"id": "3", "language": "zh", "text": "美國總統川普無視北京反對，廿七日簽署「香港人權與民主法案」與「保護香港法案」"},
        ]
        response = client.entities(documents=documents)

        for document in response.documents:
            print("Document Id: ", document.id)
            print("\tKey Entities:")
            for entity in document.entities:
                print("\t\t", "NAME: ", entity.name, "\tType: ",
                      entity.type, "\tSub-type: ", entity.sub_type)
                for match in entity.matches:
                    print("\t\t\tOffset: ", match.offset, "\tLength: ", match.length, "\tScore: ",
                          "{:.2f}".format(match.entity_type_score))

    except Exception as err:
        print("Encountered exception. {}".format(err))

def key_phrases():
    
    client = authenticateClient()

    try:
        documents = [
            {"id": "1", "language": "ja", "text": "猫は幸せ"},
            {"id": "2", "language": "de", "text": "Fahrt nach Stuttgart und dann zum Hotel zu Fu."},
            {"id": "3", "language": "en", "text": "My cat might need to see a veterinarian."},
            {"id": "4", "language": "es", "text": "A mi me encanta el fútbol!"},
            {"id": "5", "language": "zh", "text": "美國總統川普無視北京反對，廿七日簽署「香港人權與民主法案」與「保護香港法案」"}
        ]

        for document in documents:
            print(
                "Asking key-phrases on '{}' (id: {})".format(document['text'], document['id']))

        response = client.key_phrases(documents=documents)

        for document in response.documents:
            print("Document Id: ", document.id)
            print("\tKey Phrases:")
            for phrase in document.key_phrases:
                print("\t\t", phrase)

    except Exception as err:
        print("Encountered exception. {}".format(err))

#sentiment()
#language_detection()
#entity_recognition()
key_phrases()

