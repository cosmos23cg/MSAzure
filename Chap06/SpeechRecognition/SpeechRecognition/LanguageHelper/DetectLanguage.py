from azure.core.credentials import AzureKeyCredential
from azure.ai.textanalytics import TextAnalyticsClient

credential = AzureKeyCredential("a491b7ab0621424a99de497ba5402111")
endpoint="https://aien10textanalyticsapi.cognitiveservices.azure.com/"

def DetectLanguage(text):
    text_analytics_client = TextAnalyticsClient(endpoint, credential)

    documents = [
        text
    ]

    response = text_analytics_client.detect_language(documents)
    result = [doc for doc in response if not doc.is_error]

    #for doc in result:
    #print("Language detected: {}".format(result[0].primary_language.name))
    #print("ISO6391 name: {}".format(doc.primary_language.iso6391_name))
    #print("Confidence score: {}\n".format(doc.primary_language.confidence_score))
    return result[0].primary_language.name
