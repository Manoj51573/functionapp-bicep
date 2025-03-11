param env string
param logicAppSettings array = []
param functionAppSettings array = []
var intid = '<integration suffix>'

// Integration Landing Zone Configuration
module configuration 'br/IntegrationModules:landing-zone:v1.0' = {
  name: 'configuration'
  params: {
    environment: env
  }
}

var landingZone = configuration.outputs.landingZone

// Integration Pattern
module logicAppDeployment 'br/IntegrationModules:pattern:v1.0' = {
  name: 'lap-int-deploy-${intid}'
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
  }
}

// Integration Pattern
module functionAppDeployment 'br/IntegrationModules:pattern:v1.0' = {
  name: 'fap-int-deploy-${intid}'
  params: {
    integrationSuffix: intid
    landingZone: landingZone
    platform: configuration.outputs.platform
    env: env
    functionApp: {
      name: 'fap-ae-ais-${env}-${intid}'
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
