import requests
from pprint import pprint

headers = {    
    'Content-Type': 'text/plain',
    'Ocp-Apim-Subscription-Key': '897101576dc14d3c8b0e8f398a839d51',
}

params = {
    # Request parameters
    'autocorrect': 'True',
    'PII': 'True',
    'classify': 'True',
    'language': 'eng',
}

endpointUrl="https://aien1600contentmoderator.cognitiveservices.azure.com/"

str="Kiss my ass"
#str="Kiss my asshole"
#str="""Is this a grabage email abcdef@abcd.com, phone: 4255550111, IP: 255.255.255.255, 1234 Main Boulevard, Panapolis WA 96555. Crap is the profanity here. Is this information PII? phone 2065550111"""

try:
    response=requests.post(f"{endpointUrl}/contentmoderator/moderate/v1.0/ProcessText/Screen", data=str, headers=headers, params=params).json()
    #pprint(response)
    
    dict=response["Classification"]

    dict.pop('ReviewRecommended')                           # 移除第一項(key內容為ReviewRecommended的項目
    #print(dict.items())

    maxscore=max(item["Score"] for item in dict.values())   #取得最高信心指數
    #print(maxscore)

    for item in dict.items():
       if item[1]["Score"]==maxscore:
           category=item[0]
    if category=="Category1":
        print(f"涉及性與成人內容, 信心指數:{maxscore*100:.2f}%")
    elif category=="category2":
        print(f"涉及性騷擾內容, 信心指數:{maxscore*100:.2f}%")
    else:
        print(f"涉及冒犯內容, 信心指數:{maxscore*100:.2f}%")
except Exception as e:
    print(e)
