using 'main.bicep'

param env = 'dev'
param integrationSuffix = 'int01'
param functionAppSettings = [
  {
    name: 'APP_ENVIRONMENT_NAME'
    value: 'ase-ae-ais-dev-01.appserviceenvironment.net'
  }
  {
    name: 'APIM_GATEWAY_NAME'
    value: 'apim-ae-ais-dev-01.azure-api.net'
  }
  {
    name: 'SERVICE_BUS_NAMESPACE_NAME'
    value: 'sb-ae-ais-dev-02'
  }
  {
    name: 'STORAGE_ACCOUNT_DATA_NAME'
    value: 'stasydipdevdat02'
  }
  {
    name: 'STORAGE_ACCOUNT_TEL_NAME'
    value: 'stasydipdevtel02'
  }
  {
    name: 'KEY_VAULT_SHARED_NAME'
    value: 'akv-ae-ais-dev-02'
  }
  {
    name: 'KEY_VAULT_APIM_NAME'
    value: 'akv-ae-ais-dev-03'
  }
]

param logicAppSettings = [
  {
    name: 'TestLogicAppSetting01'
    value: 'LogicSettingValue01'
  }
  {
    name: 'TestLogicAppSetting02'
    value: 'LogicSettingValue02'
  }
]
