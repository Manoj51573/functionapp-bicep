param (
    $Location,
    $TemplateFile,
    $TemplateParameterFile,
    $EnvironmentAbbreviation,
    $ResourceGroupName
)

az group create -n $ResourceGroupName -l $Location

$DeploymentName = (([io.path]::GetFileNameWithoutExtension($TemplateFile)) + '-' + ((Get-Date).ToUniversalTime()).ToString('MMdd-HHmm'))

az deployment group create -n $DeploymentName --resource-group $ResourceGroupName --template-file $TemplateFile --parameters $TemplateParameterFile
