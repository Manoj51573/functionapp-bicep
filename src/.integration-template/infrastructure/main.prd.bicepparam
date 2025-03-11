using 'main.bicep'

param env = 'prd'
param logicAppSettings = [
  {
    name: 'ServiceBusConnectionString'
    value: '@Microsoft.KeyVault(VaultName=akv-ae-ais-dev-01;SecretName=ServiceBusWriteConnectionString)'
  }
]
