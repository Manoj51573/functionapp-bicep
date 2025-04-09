[CmdletBinding()]
Param(
    [string] $environmentName,
    [string] $keyVaultName,
    [string] $usernameSapEcc,
    [string] $userpwdSapEcc
)

$usernameSapEccSecureSecret = ConvertTo-SecureString -AsPlainText -String $usernameSapEcc -Force
Set-AzKeyVaultSecret -VaultName $keyVaultName -Name "$environmentName-username-sapecc" -SecretValue $usernameSapEccSecureSecret -ContentType 'text/plain'

$userpwdSapEccSecureSecret = ConvertTo-SecureString -AsPlainText -String $userpwdSapEcc -Force
Set-AzKeyVaultSecret -VaultName $keyVaultName -Name "$environmentName-userpwd-sapecc" -SecretValue $userpwdSapEccSecureSecret -ContentType 'text/plain'