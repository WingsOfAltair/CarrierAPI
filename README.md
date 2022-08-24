# CarrierAPI
A basic Multi-Carrier backend.

Instructions how to host API:

1- Install IIS 10.0: https://www.lansweeper.com/knowledgebase/how-to-install-iis/
  Make sure you (tick) add Windows Communication Foundation support
  
2- Setup the WCF API in IIS: https://www.youtube.com/watch?v=g-w1GvkwErk

3- Download & Install Postman

Inside Postman:

1- Click on Hamburger Menu icon in the top left corner

2- Go to File

3- Click on Import

4- Pick Raw text tab

5- Paste the following to the rich text field and press Continue then Import and then Send:

curl --location --request POST 'http://localhost/CarrierAPI.svc/PerformShipping' \
--header 'Content-Type: application/json' \
--data-raw '{
    "serviceUsed":1,
    "serviceID":3,
    "width":1,
    "height":1,
    "length":0.4,
    "weight":1
}'
