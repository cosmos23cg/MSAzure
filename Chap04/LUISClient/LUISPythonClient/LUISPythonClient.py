import requests
from pprint import pprint

EndpointUrl="https://msit130luis.cognitiveservices.azure.com"
AppId="c34af328-d601-4113-af7d-51ae0433dfba"
SubscriptionKey="18fb2b5c54154cd39362f75c69c52238"
query="小碗麵線"

url=f"{EndpointUrl}/luis/prediction/v3.0/apps/{AppId}/slots/production/predict?subscription-key={SubscriptionKey}&verbose=true&show-all-intents=true&log=true&query={query}"

response=requests.get(url).json()
pprint(response)

topIntent=response["prediction"]["topIntent"]
score=response["prediction"]["intents"][topIntent]["score"]

print(f"Intent:{topIntent}, 信心指數:{score*100:.2f}%")


