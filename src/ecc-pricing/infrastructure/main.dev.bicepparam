using 'main.bicep'

param env = 'dev'
param integrationSuffix = 'eccpricing'
param functionAppSettings = [
  {
    name: 'APP_ENVIRONMENT_NAME'
    value: 'ase-ae-ais-dev-01.appserviceenvironment.net'
  }
  {
    name: 'APIM_GATEWAY_NAME'
    value: 'apim-ae-ais-dev-nnpbak.azure-api.net'
  }
  {
    name: 'STORAGE_ACCOUNT_DATA_NAME'
    value: 'staeaisdevdatannpbak'
  }
  {
    name: 'STORAGE_ACCOUNT_TEL_NAME'
    value: 'staeaisdevlogsnnpbak'
  }
  {
    name: 'KEY_VAULT_APIM_NAME'
    value: 'kv-ae-ais-dev-apim'
  }
  {
    name: 'SapEccOption:BaseUrl'
    value: 'https://api-dev.dwer.wa.gov.au/integration/pricing/v1/get-price'
  }
  {
    name: 'SapEccOption:UserName'
    value: 'kv-ae-ais-dev-apim'
  }
  {
    name: 'SapEccOption:Password'
    value: 'dummy'
  }
]
