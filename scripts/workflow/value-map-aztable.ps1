<#
    .SYNOPSIS Populates an Azure Storage Table from a json file
#>

[CmdletBinding()]
param (
    [Parameter()] [string] $storageAccountName,
    [Parameter()] [string] $storageResourceGroupName
)

$ErrorActionPreference = 'Stop'

Install-Module -Name AzTable

$tableName = "SampleValueMap"

$table = Get-AzTableTable `
    -TableName $tableName `
    -storageAccountName $storageAccountName `
    -resourceGroup $storageResourceGroupName

$rows = Get-Content .\value-map.json | ConvertFrom-Json

foreach($r in $rows) {
    $existing = Get-AzTableRow -table $table -partitionKey $r.partitionKey -rowKey $r.rowKey
    if ($existing) {
        write-host "Updating: $($existing.partitionKey)\$($existing.rowKey)"
        $existing.allowedElements = $r.allowedElements
        $existing | Update-AzTableRow -table $table
    }
    else {
        Add-AzTableRow -table $table -partitionKey $r.partitionKey -rowKey $r.rowKey -property @{"allowedElements"=$r.allowedElements}
    }
}