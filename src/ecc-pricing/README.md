# Get Pricing API

This integration is comprised of a backend function app that is abstracted by APIM. This endpoint performs the followings:
- Accepts https request body(in JSON) format
- Validates the request
- Gets the pricing data from SAP ECC via odata webservice API
- transforms the xml response(received from SAP ECC) into JSON payload and returns to the request originator

<br>

This API endpoint can be accessed from on-premise system by https://apim-ae-ais-dev-nnpbak.azure-api.net/integration/ecc-pricing/v1/get-pricing



![Get Pricing API](.media/getPricingAPI.png)

