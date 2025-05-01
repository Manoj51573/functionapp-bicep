using 'main.bicep'

param env = 'dev'
param integrationSuffix = 'bunsales'
// param sftpHostName = '10.215.12.148'
// param sftpRootfolder = '/Inbound' // e.g. '/bunnings-salesout'
param fileShareServerFQDN = 'AUAZMYD2DS3.duluxgroup.net'
param fileShareAccountName = 'duluxgroup\\svc_ds'
param fileShareName = 'FileTransfers'

var keyVaultName = 'kv-ae-ais-dev-nnpbak'
var secretNameUsernameSftpfileserver = '${env}-username-sftpfileserver'
var secretNameUserpwdSftpfileserver = '${env}-userpwd-sftpfileserver'
// var secretNameUsernameSapBwSserver = '${env}-username-SapBwSserver'
var secretNameUserpwdSapBwSserver = '${env}-userpwd-SapBwSserver'

param logicAppSettings = [
  {
    name: 'SqlServerName'
    value: 'dgit-npe-ase-asql.database.windows.net'
  }
  {
    name: 'SqlDatabaseName'
    value: 'ControlDB'
  }
  {
    name: 'SFTP_HOSTNAME_SI_SERVER'
    value: '10.215.12.148'
  }
  {
    name: 'SFTP_ROOTFOLDER_SI_SERVER'
    value: '/Inbound'
  }
  {
    name: 'SFTP_USERNAME_SI_SERVER'
     value: '@Microsoft.KeyVault(SecretUri=https://${keyVaultName}.vault.azure.net/secrets/${secretNameUsernameSftpfileserver})'
  }
  {
    name: 'SFTP_USERPWD_SI_SERVER'
    value: '@Microsoft.KeyVault(SecretUri=https://${keyVaultName}.vault.azure.net/secrets/${secretNameUserpwdSftpfileserver})'
  }
  {
    name: 'BlobStorageEndpoint_DuluxAdls'
    value: 'https://dgitnpeaseadls.blob.core.windows.net'
  }
  {
    name: 'BlobStorageEndpoint_DataStorage'
    value: 'https://staeaisdevdatannpbak.blob.core.windows.net'
  }
  {
    name: 'FileSystem_mountPath'
    value: 'C:\\mounts\\FileSystem'
  }
  {
    name: 'FileSystem_password'
    value: '@Microsoft.KeyVault(SecretUri=https://${keyVaultName}.vault.azure.net/secrets/${secretNameUserpwdSapBwSserver})'
  }
  {
    name: 'ErrorNotification_RecipientEmailAddress'
    value: 'nicholas.wilson@duluxgroup.com.au'
  }
  {
    name: 'ADLS_NumberOfFilesToProcess'
    value: 2
  }
  {
    name: 'DataFactory_SubscriptionId'
    value: '9921d38c-3739-4271-95f2-c09093ad87a4'
  }
  {
    name: 'DataFactory_ResourceGroup'
    value: 'EA-NonProd-DataInsights-RG'
  }
  {
    name: 'DataFactory_Name'
    value: 'dgit-npe-ase-ADF'
  }
  {
    name: 'DataFactoryPipeline1Name'
    value: 'ADLS csv_to_ADLS parquet'
  }
  {
    name: 'DataFactoryPipeline2Name'
    value: 'PBI_Refresh_v1'
  }
]
