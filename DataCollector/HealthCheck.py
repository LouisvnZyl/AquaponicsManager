import requests
import time
import RPi.GPIO as GPIO

GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)
GPIO.setup(14,GPIO.OUT)

while(True):
    GPIO.output(14, GPIO.HIGH)
    getResponse = requests.get('http://192.168.1.109:45457/api/health', verify = False)
    print(getResponse.json())
    
    mydata={}
    mydata['id'] = "87440"
    postResponse = requests.post('http://192.168.1.109:45457/api/health/1', verify = False)
    print(postResponse.text)
    
    GPIO.output(14, GPIO.LOW)
    time.sleep(1)