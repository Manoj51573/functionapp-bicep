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
    name: 'WEBSITE_LOAD_ROOT_CERTIFICATES'
    value: '0711D93AE6571FE44BB6D53C41222CCC1A439DF7'
  }
  {
    name: 'SapEccOption:BaseUrl'
    // value: 'https://apim-ae-dulux-001.azure-api.net/integration/pricing/v1/get-price'
    value: 'https://auazmelqod2.duluxgroup.net:1443/sap/opu/odata/sap/ZCOD_SO_SIMULATE_SRV_01/IsOrderHeaderSet?sap-client=010'
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
