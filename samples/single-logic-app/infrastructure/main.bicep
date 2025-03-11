param env string
param logicAppSettings array = []
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
