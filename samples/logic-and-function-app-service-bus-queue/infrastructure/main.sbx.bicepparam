using 'main.bicep'

param env = 'dev'
param functionAppSettings = [
  {
    name: 'ServiceBusConnectionString'
    value: '@Microsoft.KeyVault(VaultName=akv-ae-ais-dev-01;SecretName=ServiceBusWriteConnectionString)'
  }
  {
    name: 'ServiceBusQueueName'
    value: 'bq-samplequeue-dev-id01'
  }
  {
    name: 'ApplicationDbConnectionString'
    value: '@Microsoft.KeyVault(VaultName=akv-ae-ais-dev-01;SecretName=ApplicationDbConnectionString)'
  }
]

param logicAppSettings = [
  {
    name: 'ServiceBusConnectionString'
    value: '@Microsoft.KeyVault(VaultName=akv-ae-ais-dev-01;SecretName=ServiceBusReadConnectionString)'
  }
  {
    name: 'ServiceBusQueueName'
    value: 'bq-samplequeue-dev-id01'
  }
  {
    name: 'ApplicationDbConnectionString'
    value: '@Microsoft.KeyVault(VaultName=akv-ae-ais-dev-01;SecretName=ApplicationDbConnectionString)'
  }
]
