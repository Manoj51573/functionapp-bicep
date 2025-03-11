param (
    $ResourceGroupName,
    $Location,
    $TemplateFile,
    $TemplateParameterFile,
    $EnvironmentAbbreviation
)

$resourceGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction SilentlyContinue
if (-Not $resourceGroup) {  
    $updateDate = get-date -Format "yyyy-MM-dd HH:mm:ss K"
    $tags = @{
        "applicationName"    = "Shared - Infrastructure";
        "environment"        = $EnvironmentAbbreviation;
        "owner"              = "[REPLACE-ME]";
        "criticality"        = "Tier2";
        "costCenter"         = "Data Platforms";
        "dataClassification" = "Sensitive";
        "CreatedDate"        = $updateDate
    }
    New-AzResourceGroup -Name $ResourceGroupName -Location $Location -Tag $tags
}

$DeploymentName = (([io.path]::GetFileNameWithoutExtension($TemplateFile)) + '-' + ((Get-Date).ToUniversalTime()).ToString('MMdd-HHmm-ss-ff'))

# az deployment group create -n $DeploymentName -g $ResourceGroupName --template-file $TemplateFile --parameters $TemplateParameterFile

New-AzResourceGroupDeployment `
    -Name $DeploymentName `
    -ResourceGroupName $ResourceGroupName `
    -TemplateFile $TemplateFile `
    -TemplateParameterFile $TemplateParameterFile
