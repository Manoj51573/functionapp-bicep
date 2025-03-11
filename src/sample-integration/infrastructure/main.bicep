@description('Shortcode of the environment being delpoyed to.')
@minLength(3)
@maxLength(3)
param env string

@description('Suffix to be added to the integration name. Should be short. Example = "int01"')
@minLength(3)
@maxLength(10)
param integrationSuffix string

@description('Array of settings for Logic App. Example = [ { name: \'WEBSITE_RUN_FROM_PACKAGE\' value: \'1\'} ]')
param logicAppSettings array = []
@description('Array of settings for Function App. Example = [{ name: \'WEBSITE_RUN_FROM_PACKAGE\' value: \'1\'}]')
param functionAppSettings array = []

// Integration Landing Zone Configuration
module configuration 'br/IntegrationModules:landing-zone:v1.0' = {
  name: 'configuration'
  params: {
    environment: env
  }
}

var landingZone = configuration.outputs.landingZone

// Integration Pattern
module mainDeployment 'br/IntegrationModules:pattern:v1.0' = {
  name: 'integrationDeployment-${integrationSuffix}'
  params: {
    integrationSuffix: integrationSuffix
    landingZone: landingZone
    platform: configuration.outputs.platform
    env: env
    logicApp: {
      name: 'lap-ae-ais-${env}-${integrationSuffix}'
      appServicePlan: landingZone.appServiceName
      appSettings: logicAppSettings
    }
    functionApp: {
      name: 'fun-ae-ais-${env}-${integrationSuffix}'
      appServicePlan: landingZone.appServiceName
      appSettings: functionAppSettings
      workerRuntime: 'dotnet-isolated'
      workerVersion: 'v6.0'
    }
  }
}
