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

param publicCerts = [
  {
    name: 'auazmelqod2'
    thumbprint: '0711D93AE6571FE44BB6D53C41222CCC1A439DF7'
    blob: 'LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tDQpNSUlDVnpDQ0FjQUNCeUFVQnlBQkJUWXdEUVlKS29aSWh2Y05BUUVGQlFBd2NURUxNQWtHQTFVRUJoTUNSRVV4DQpIREFhQmdOVkJBb1RFMU5CVUNCVWNuVnpkQ0JEYjIxdGRXNXBkSGt4RXpBUkJnTlZCQXNUQ2xOQlVDQlhaV0lnDQpRVk14RkRBU0JnTlZCQXNUQzBrd01ESXdOak01TXpNMk1Sa3dGd1lEVlFRREZCQXFMbVIxYkhWNFozSnZkWEF1DQpibVYwTUI0WERURTBNRGN5TURBeE1EVXpObG9YRFRNNE1ERXdNVEF3TURBd01Wb3djVEVMTUFrR0ExVUVCaE1DDQpSRVV4SERBYUJnTlZCQW9URTFOQlVDQlVjblZ6ZENCRGIyMXRkVzVwZEhreEV6QVJCZ05WQkFzVENsTkJVQ0JYDQpaV0lnUVZNeEZEQVNCZ05WQkFzVEMwa3dNREl3TmpNNU16TTJNUmt3RndZRFZRUURGQkFxTG1SMWJIVjRaM0p2DQpkWEF1Ym1WME1JR2ZNQTBHQ1NxR1NJYjNEUUVCQVFVQUE0R05BRENCaVFLQmdRRC82ZlBVekNWWGJqQmlWbk9YDQpqOFNTWTVKTFpsR3FNQ29rdG1xVmFCb1J1SytjQzZGMEY1REFKdFdwTDhBTDNRbVhBa0ttZ3o5Y0xSSHpOaHk1DQpaem50Qkl6VldIL00zVkZvTk4wRmJ0NWxQeGo4aU9UZlhaOFpaZmdHY3c4N0h1cTZ0QTlKb3ZHbmNaaTE2d2tDDQpvbU5ZM2VoZUQ4SWs2V2M3SHVoMVhKVUpsUUlEQVFBQk1BMEdDU3FHU0liM0RRRUJCUVVBQTRHQkFDWVRzTUFvDQppZFAvT2FGWHkxd3p1T1FlVEN1TWEyQUNLbnlmL2xqc3AyL1JOSWcraGVCWGVUQ3JIOUdPUTZtSUExbk9OMlQ0DQpDQ1A4YnltdE92cGIrSFVaRndoRUxxbDZOeU91dzg2cS9WNFVBd09ab2pmTTRYN1VmZ1h5Qy9ldmFSN3VIdXlBDQpkWmVYNXNPZ0ZoS0gyUnJycUxYaHNoQmNHZ25FSFprUVdXeVANCi0tLS0tRU5EIENFUlRJRklDQVRFLS0tLS0NCg=='
    publicCertificateLocation: 'LocalMachineMy'
  }
]
