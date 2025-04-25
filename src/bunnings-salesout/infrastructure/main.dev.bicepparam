using 'main.bicep'

param env = 'dev'
param integrationSuffix = 'bunsales'
param sftpHostName = '10.215.12.148'
param sftpRootfolder = '/Inbound' // e.g. '/bunnings-salesout'
param fileShareServerFQDN = 'AUAZMYD2DS3.duluxgroup.net'
param fileShareAccountName = 'duluxgroup\\svc_ds'
param fileShareName = 'FileTransfers'

var keyVaultName = 'kv-ae-ais-dev-nnpbak'
var secretNameUsernameSftpfileserver = '${env}-username-sftpfileserver'
var secretNameUserpwdSftpfileserver = '${env}-userpwd-sftpfileserver'
var secretNameUsernameSapBwSserver = '${env}-username-SapBwSserver'
var secretNameUserpwdSapBwSserver = '${env}-userpwd-SapBwSserver'

param logicAppSettings = [
  {
    name: 'SettingName'
    value: 'LogicSettingValue01'
  }
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
    name: 'Dulux_ADLS_AccountName'
    value: 'dgitnpeaseadls'
  }
  {
    name: 'DataStorage_AccountName'
    value: 'staeaisdevdatannpbak'
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
]
