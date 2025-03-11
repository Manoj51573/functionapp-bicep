using 'main.bicep'

param env = 'dev'
param functionAppSettings = [
  {
    name: 'ServiceBusConnectionString'
    value: '@Microsoft.KeyVault(VaultName=akv-ae-ais-dev-01;SecretName=ServiceBusWriteConnectionString)'
  }
]
