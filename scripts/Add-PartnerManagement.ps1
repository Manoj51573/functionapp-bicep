$partnerId = 1158331
$output = az extension show --name managementpartner
if (!$?) {
    az extension add --name managementpartner 
}
$partner = az managementpartner show | ConvertFrom-Json 
if ($null -eq $partner) { 
    az managementpartner create --partner-id $partnerId 
}  
else { 
    az managementpartner update --partner-id $partnerId 
}
Write-Host "Verifying partner Id"
az managementpartner show
