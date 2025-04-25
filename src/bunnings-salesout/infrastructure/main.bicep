@description('Shortcode of the environment being delpoyed to.')
@minLength(3)
@maxLength(3)
param env string

@description('Suffix to be added to the integration name. Should be short. Example = "int01"')
@minLength(3)
@maxLength(10)
param integrationSuffix string

@description('Array of settings for Function App. Example = [{ name: \'WEBSITE_RUN_FROM_PACKAGE\' value: \'1\'}]')
param logicAppSettings array = []

@description('Hostname of the SFTP server. Example = \'sftp.example.com\'')
param sftpHostName string

@description('Root folder of the SFTP server. Example = \'/path/to/root\'')
param sftpRootfolder string 

@description('Name of the user for the file share. Example = \'domain\\username\'')
param fileShareAccountName string
@description('Password of the user created for the file share')
param fileShareName string 
@description('IP address or FQDN of the file share server.')
param fileShareServerFQDN string 

// Integration Landing Zone Configuration
module configuration 'br/IntegrationModules:landing-zone:v3.0.1' = {
  name: 'configuration'
  params: {
    environment: env
  }
}

var secretNameSftpUsername = '${env}-username-sftpfileserver'
var secretNameSftpPassword = '${env}-userpwd-sftpfileserver'

var office365Connector= {
  name: 'office365'
  displayName: 'office365'
}

var adfConnector= {
  name: 'adfConnector'
  displayName: 'adfConnector'
}

var sftpConnector = {
  name: 'sftpConnector'
  displayName: 'sftp-connector'
  credentials : {
    username: secretNameSftpUsername
    password: secretNameSftpPassword
  }
  rootFolder: sftpRootfolder
  hostName: sftpHostName
}

var azureStorageAccounts = {
  FileSystem: {
      type: 'FileShare'
      accountName: fileShareAccountName
      endpoint: fileShareServerFQDN
      shareName: fileShareName
      mountPath: '\\mounts\\FileSystem'
      accessKey: '@AppSettingRef(FileSystem_password)'
  }
}

var landingZone = configuration.outputs.landingZone

// Integration Pattern
module mainDeployment 'br/IntegrationModules:pattern:v3.0.1' = {
  name: 'integrationDeployment-${integrationSuffix}'
  params: {
    integrationSuffix: integrationSuffix
    landingZone: landingZone
    platform: configuration.outputs.platform
    env: env
    logicApp: {
      name: 'logic-ae-ais-${env}-${integrationSuffix}'
      appServicePlan: landingZone.appServiceName
      appSettings: logicAppSettings
      azureStorageAccounts : azureStorageAccounts
      office365Connector: office365Connector
      sftpConnector: sftpConnector
      //adfConnector: adfConnector
    }
  }
}
