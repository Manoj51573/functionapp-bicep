# Getting started with the Insight Integration Pattern Template

You can build two types of Azure Integrations using the Pattern Template. Let's take a look at each, and the configuration options available.

## Pre-requisites

Before you can build integrations using the Pattern Template you must have the following in place.

### Visual Studio Code

In order to build Azure Functions or Azure Logic Apps (Standard) integrations you will need to have [Visual Studio Code installed](https://code.visualstudio.com/download). You can run on any Operating System. 

You will need the following extensions:

- [Azure Functions Core Tools Extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions)
- [Azure Logic Apps (Standard)](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurelogicapps)
- [Azurite Storage Emulator](https://marketplace.visualstudio.com/items?itemName=Azurite.azurite)
- [Bicep](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-bicep)
- [PSRule](https://marketplace.visualstudio.com/items?itemName=bewhite.psrule-vscode)

### Azure CLI

In order to access the Bicep Registry (see below) you will need to be able to log into an Azure Subscription. The easiest way to enable this is to [install the Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli).

### Bicep Registry Access

Modify the [bicepconfig.json](../bicepconfig.json) file in the root of this repsitory and update the `registry` entry to point at your Bicep Registry. Insight Path uses an Azure Container Registry for this purpose, but if you have an alternative you can configure it. You should not need to modify the `modulePath` if you are using an Insight Path deployment.

```json
  "moduleAliases": {
    "br": {
      "IntegrationModules": {
        "registry": "<tbc>.azurecr.io",
        "modulePath": "bicep/modules/integration"
      }
    }
  }
```

In order to use the modules hosted in the Bicep Registry you will need to be logged into an Azure Subscription with a user who has been granted `acrPull` permissions (either directly, or as part of a group). If you do not login, or your user does not have Registry access, you will receive an error when editing the `main.bicep` file for your integration.

### PowerShell

PowerShell is required to enable the use of PSRule. You can [install PowerShell on any OS](https://learn.microsoft.com/powershell/scripting/install/installing-powershell).

### PSRule (v2)

PSRule allows you to validate your Bicep infrastructure deployments before you commit them to source control. You can run the tool locally through PowerShell by [installing the PSRule modules](https://microsoft.github.io/PSRule/v2/install-instructions/#getting-the-modules).

## Relationship with Insight Path

As mentioned in the main readme, there is a direct relationship between the Pattern Template and Insight Path. Two Bicep modules that are deployed as part of Insight Path are refrenced within each Integration you build using this repository.

## Configuration Options

Over time we will build up the samples folder with examples of how to configure the following items. Note that you will find a [Sample deployment](../src/sample-integration/README.md) that has some of these items already configured.

### Logic Apps

```bicep
logicApp: {
  name: 'lap-ae-ais-${env}-${integrationSuffix}'
  appServicePlan: landingZone.appServiceName
  appSettings: logicAppSettings
  tags: tags
}
```

### Function Apps

```bicep
functionApp: {
  name: 'fun-ae-ais-${env}-${integrationSuffix}'
  appServicePlan: landingZone.appServiceName
  appSettings: functionAppSettings
  workerRuntime: 'dotnet-isolated'
  workerVersion: 'v6.0'
  tags: tags
}
```

### Logic and Function App Settings

You provide the values to insert into the App Settings for both integration types using this format. Note that `slotSetting` is not applicable to Logic Apps. These values are merged with the default values defined in the `pattern.bicep` file found in Insight Path's deployment.

```bicep
param functionAppSettings = [
  {
    name: 'APP_ENVIRONMENT_NAME'
    value: 'ase-ae-ais-dev-01.appserviceenvironment.net'
    slotSetting: false
  }
  {
    name: 'APIM_GATEWAY_NAME'
    value: 'apim-ae-ais-dev-01.azure-api.net'
  }
]
```

### Service Bus Queues

To be documented.

### Storage Tables

To be documented. 

### Storage Containers

To be documented.

## Deployment

Azure Pipelines files are used to deploy both the underlying Azure Functions or Logic Apps resource as well as the application source code. You can see a sample for the [Sample deployment](../.azdo/sample-integration.yaml).
