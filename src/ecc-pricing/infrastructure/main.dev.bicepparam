using 'main.bicep'

param env = 'dev'
param integrationSuffix = 'eccpricing'

var keyVaultName = 'kv-ae-ais-dev-nnpbak'
var secretNameUsernameSapecc = '${env}-username-sapecc'
var secretNameUserpwdSapecc = '${env}-userpwd-sapecc'

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
     value: '@Microsoft.KeyVault(SecretUri=https://${keyVaultName}.vault.azure.net/secrets/${secretNameUsernameSapecc})'
  }
  {
    name: 'SapEccOption:Password'
    value: '@Microsoft.KeyVault(SecretUri=https://${keyVaultName}.vault.azure.net/secrets/${secretNameUserpwdSapecc})'
  }
]
