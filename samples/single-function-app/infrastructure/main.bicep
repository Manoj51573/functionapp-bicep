param env string
param functionAppSettings array = []
var intid = '<integration suffix>'

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
    }
  }
}
