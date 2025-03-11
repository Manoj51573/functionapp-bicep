
[CmdletBinding()]
param (
    [Parameter()] [string] $env,
    [Parameter()] [string] $name
)

$updateDate = get-date -Format "yyyy-MM-dd HH:mm:ss K"
$tags = @{
    "applicationName"    = "Shared - Infrastructure";
    "environment"        = $env;
    "owner"              = "[REPLACE-ME]";
    "criticality"        = "Tier2";
    "costCenter"         = "Data Platforms";
    "dataClassification" = "Standard";
    "CreatedDate"        = $updateDate
}

$resource = Get-AzResourceGroup -Name $name -ErrorAction SilentlyContinue
if (-Not $resource) {
    New-AzResourceGroup -Name $name -Location 'australiaeast' -Tag $tags
}