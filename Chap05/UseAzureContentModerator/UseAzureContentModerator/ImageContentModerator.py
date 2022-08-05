import requests
from pprint import pprint

headers = {    
    'Content-Type': 'application/json',
    'Ocp-Apim-Subscription-Key': '897101576dc14d3c8b0e8f398a839d51',
}

params = {
    # Request parameters
    'CacheImage': 'True',
}

endpointUrl="https://aien1600contentmoderator.cognitiveservices.azure.com/"

data={
    "DataRepresentation":"URL",
    #"Value":"https://moderatorsampleimages.blob.core.windows.net/samples/sample2.jpg"
    "Value":"https://img.ltn.com.tw/Upload/news/600/2018/05/23/2435395_4.jpg",
}

try:
    response=requests.post(f"{endpointUrl}/contentmoderator/moderate/v1.0/ProcessImage/Evaluate", headers=headers, params=params, json=data)
    result=response.json()
    IsImageAdultClassified=result["IsImageAdultClassified"]
    IsImageRacyClassified=result["IsImageRacyClassified"]
    AdultClassificationScore=result["AdultClassificationScore"]
    RacyClassificationScore=result["RacyClassificationScore"]
    #pprint(result)
    if IsImageAdultClassified or IsImageRacyClassified:
        print(f"成人:{AdultClassificationScore*100:.2f}%, 種族:{RacyClassificationScore*100:.2f}%")
    else:
        print(f"成人:{IsImageAdultClassified}, 種族:{IsImageRacyClassified}")
except Exception as e:
    print(e)
