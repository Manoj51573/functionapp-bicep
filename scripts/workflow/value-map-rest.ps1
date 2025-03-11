<#
    .SYNOPSIS Populates an Azure Storage Table from a json file
#>

[CmdletBinding()]
param (
    [Parameter()] [string] $storageAccountName,
    [Parameter()] [string] $valueFilePath
)

$ErrorActionPreference = 'Stop'

$tableEndpoint="https://$($storageAccountName).table.core.windows.net/"
$resourceUrl="https://storage.azure.com/"

$token=$(Get-AzAccessToken -ResourceUrl $resourceUrl).Token

$GMTTime = (Get-Date).ToUniversalTime().toString('R')
$headers = @{
    Authorization="Bearer $token"
    Accept='*/*'
    'Content-Type'='application/json'
    'x-ms-date' = $GMTTime
    'x-ms-version' = '2021-08-06'
    'x-ms-command-name' = 'StorageClient.Tables.UpdateEntity'
}

$rows = Get-Content $valueFilePath | ConvertFrom-Json

foreach($r in $rows) {
    $r | Add-Member -NotePropertyName "AllowedElements@odata.type" -NotePropertyValue "Edm.String"
    $r | Add-Member -NotePropertyName "PartitionKey@odata.type" -NotePropertyValue "Edm.String"
    $r | Add-Member -NotePropertyName "RowKey@odata.type" -NotePropertyValue "Edm.String"
    $query="$($tableEndpoint)AmplaValueMap(PartitionKey='$($r.PartitionKey)',RowKey='$($r.RowKey)')"
    $itemString = $($r | ConvertTo-Json)
    Write-Host $itemString
    Invoke-RestMethod -Method "Put" -Uri $query -Headers $headers -Body $itemString -ContentType "application/json" -Verbose
}