[CmdletBinding()]
param (
    [Parameter(Mandatory)] [string] $ResourceGroupName,
    [Parameter(Mandatory)] [string] $Location,
    [Parameter(Mandatory)] [string] $EnvironmentAbbreviation
)

# Load default tags from file
$json = Get-Content -Path "$PSScriptRoot/../src/tags.json" -Raw
$fileData = ConvertFrom-Json -InputObject $json -AsHashtable
$tags = $fileData.defaultTags
# Add the environment tag to the set
$tags.Add("environment", $EnvironmentAbbreviation)

$resourceGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction SilentlyContinue

if (-Not $resourceGroup) {  
    Write-Host "Creating Resource Group $ResourceGroupName"
    New-AzResourceGroup -Name $ResourceGroupName -Location $Location -Tag $tags
}
else {
    Write-Host "Updating Tags on existing Resource Group $ResourceGroupName"
    Update-AzTag -ResourceId $resourceGroup.ResourceId -Tag $tags -Operation 'Replace'
}