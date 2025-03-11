param env string
param functionAppSettings array
param logicAppSettings array
var intid = 'id01'

// Integration Landing Zone Configuration
module configuration 'br/IntegrationModules:landing-zone:v1.0.5' = {
  name: 'configuration'
  params: {
    environment: env
  }
}

var landingZone = configuration.outputs.landingZone

// Integration Pattern
module mainDeployment 'br/IntegrationModules:pattern:v1.0.5' = {
  name: 'integrationDeployment-${intid}'
  params: {
    integrationSuffix: intid
    landingZone: landingZone
    platform: configuration.outputs.platform
    env: env
    logicApp: {
      name: 'lap-ae-ais-${env}-${intid}'
      appServicePlan: landingZone.appServiceName
      appSettings: logicAppSettings
    }
    functionApp: {
      name: 'fap-ae-eip-${env}-${intid}'
      appServicePlan: landingZone.appServiceName
      appSettings: functionAppSettings
      workerRuntime: 'dotnet-isolated'
      workerVersion: 'v6.0'
      serviceBusQueues:[
        {
          name: 'bq-servicenow-staffnotifier-${env}-${intid}'
          useDeadLetter: true
          accessMethod: 'receive'         
        }
      ]
    }
  }
}
