[CmdletBinding()]
Param(
    [string] $environmentName,
    [string] $keyVaultName,
    [string] $usernameSftpFileServer,
    [string] $userpwdSftpFileServer,
    [string] $usernameSapBwSserver,
    [string] $userpwdSapBwSserver
)

$usernameSftpFileServerSecureSecret = ConvertTo-SecureString -AsPlainText -String $usernameSftpFileServer -Force
Set-AzKeyVaultSecret -VaultName $keyVaultName -Name "$environmentName-username-sftpfileserver" -SecretValue $usernameSftpFileServerSecureSecret -ContentType 'text/plain'

$userpwdSftpFileServerSecureSecret = ConvertTo-SecureString -AsPlainText -String $userpwdSftpFileServer -Force
Set-AzKeyVaultSecret -VaultName $keyVaultName -Name "$environmentName-userpwd-sftpfileserver" -SecretValue $userpwdSftpFileServerSecureSecret -ContentType 'text/plain'

$usernameSapBwSserverSecureSecret = ConvertTo-SecureString -AsPlainText -String $usernameSapBwSserver -Force
Set-AzKeyVaultSecret -VaultName $keyVaultName -Name "$environmentName-username-SapBwSserver" -SecretValue $usernameSapBwSserverSecureSecret -ContentType 'text/plain'

$userpwdSapBwSserverSecureSecret = ConvertTo-SecureString -AsPlainText -String $userpwdSapBwSserver -Force
Set-AzKeyVaultSecret -VaultName $keyVaultName -Name "$environmentName-userpwd-SapBwSserver" -SecretValue $userpwdSapBwSserverSecureSecret -ContentType 'text/plain'