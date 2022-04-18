import requests

response = requests.get('https://localhost:5001/api/health', verify=False)

print(response.json())