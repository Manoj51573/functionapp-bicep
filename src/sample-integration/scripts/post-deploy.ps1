[CmdletBinding()]
 param (     
     [Parameter(Mandatory)][string]$environmentName
 )

$expiryDate = $(Get-Date).AddDays(364)
$keyVaultName="kv-ae-ais-$environmentName-apim"

## lookup the resource id for your Azure Function App ##
$resourceId = (Get-AzResource -ResourceGroupName "rg-ae-ais-$environmentName-sample" -ResourceName "func-ae-ais-$environmentName-sample" -ResourceType "Microsoft.Web/sites").ResourceId

$functionName = 'testfunction'
Write-Host "updating $functionName-$environmentName"    

$path = "$resourceId/functions/$functionName/listkeys?api-version=2021-02-01"
$response = Invoke-AzRestMethod -Path $path -Method POST
Write-host "Sending request"
Write-host ($response.Content | ConvertFrom-Json)[0]
$functionKey = ($response.Content | ConvertFrom-Json).default

$secureSecret = ConvertTo-SecureString -AsPlainText -String $functionKey -Force

$secretName = "func-ae-ais-$environmentName-sample-$functionName-key"

Write-host "Setting secret in APIM KV"
Set-AzKeyVaultSecret -VaultName $keyVaultName -Name $secretName -SecretValue $secureSecret -Expires $expiryDate -ContentType 'text/plain'