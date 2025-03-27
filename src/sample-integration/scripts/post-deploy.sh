#!/bin/bash

echo ========== 
echo Test DNS
echo ==========

# # Get authorisation key for the function app
# functionResourceGroupName="arg-ae-ais-dev-sample"
# functionAppName="func-ae-ais-dev-sample"
# functionName="testfunction"

# # Get the Azure Function authorization key
# # Need to use Azure CLI because there is no simple way to get a key using PowerShell
# primaryKey=$(az functionapp keys list --resource-group $functionResourceGroupName --name $functionAppName --query functionKeys.default | sed 's/"//g')
# # Define the API endpoint URL
# apiUrl="https://$functionAppName.ase-ae-ais-dev-01.appserviceenvironment.net/api/$functionName?code=$primaryKey"

# # make a curl request and provide the function key in the header
# #curl -v "$apiUrl"  -o "TestResult.xml"
# wget -O "TestResult.xml" "$apiUrl"

# print out the file contents
# cat TestResult.xml

$keyVaultName="kv-ae-ais-dev-apim"

## lookup the resource id for your Azure Function App ##
$resourceId = (Get-AzResource -ResourceGroupName "arg-ae-ais-$environmentName-sample" -ResourceName "func-ae-ais-$environmentName-sample" -ResourceType "Microsoft.Web/sites").ResourceId

$functionName = 'testfunction'
Write-Host "updating $functionName-$environmentName"    

$path = "$resourceId/functions/$functionName/listkeys?api-version=2021-02-01"
$response = Invoke-AzRestMethod -Path $path -Method POST
Write-host "Sending request"
Write-host ($response.Content | ConvertFrom-Json)[0]
$functionKey = ($response.Content | ConvertFrom-Json).default

$secureSecret = ConvertTo-SecureString -AsPlainText -String $functionKey -Force

$secretName = "fap-ae-ais-$environmentName-sample-$functionName-key"

Write-host "Setting secret in APIM KV"
Set-AzKeyVaultSecret -VaultName $keyVaultName -Name $secretName -SecretValue $secureSecret -ContentType 'text/plain'