#!/bin/bash

echo ========== 
echo Test DNS
echo ==========

# Get authorisation key for the function app
functionResourceGroupName="arg-ae-ais-dev-int01"
functionAppName="fun-ae-ais-dev-int01"
functionName="ValidateEnvironmentDns"

# Get the Azure Function authorization key
# Need to use Azure CLI because there is no simple way to get a key using PowerShell
primaryKey=$(az functionapp keys list --resource-group $functionResourceGroupName --name $functionAppName --query functionKeys.default | sed 's/"//g')
# Define the API endpoint URL
apiUrl="https://$functionAppName.ase-ae-ais-dev-01.appserviceenvironment.net/api/$functionName?code=$primaryKey"

# make a curl request and provide the function key in the header
#curl -v "$apiUrl"  -o "TestResult.xml"
wget -O "TestResult.xml" "$apiUrl"

# print out the file contents
# cat TestResult.xml