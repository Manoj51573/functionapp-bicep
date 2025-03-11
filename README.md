# Introduction

The Insight Integration Pattern Template provides a template for developing integration solutions that can be deployed to an Azure Integration Services environment that has been deployed using Insight Path.

Integrations built using the Pattern Template rely on two Bicep modules that are configured and deployed with Insight Path - [pattern.bicep](https://github.com/Insight-Services-APAC/azure-integration-landing-zone/blob/main/src/modules/Insight/Integration/pattern.bicep) and [landingZone.bicep](https://github.com/Insight-Services-APAC/azure-integration-landing-zone/blob/main/src/modules/Insight/Integration/landingZone.bicep). These two modules are deployed to a Bicep Registry hosted on an Azure Container Registry in the customer's environment.

Development is accelerated by providing a suggested folder structure, sample Azure Pipelines and reference Bicep modules.

## Building an Integration

Check out the [getting started guide](docs/getting-started.md) for how to build Integrations.

## Deploying an Integration

## Folder Structure

Files & Folder | Description
--- | ---
`.azdo` | Defines Azure DevOps Pipelines (yaml). These definitions need to be manually imported into ADO
`.github` | Defines GitHub Pipelines (yml). These pipelines automatically appear into GitHub Actions
[.azdo/.deploy.yaml](/.azdo/.deploy.yaml) | For Azure DevOps - Pipeline template. Copy for each new integration
[.github/workflows/deploy.yml](/.github/workflows/deploy.yml.yml) | For GitHub Actions - Pipeline template. Copy for each new integration
`src` | Contains solution assets including infrastructure, functions and workflows
`src/<integration-suffix>/infrastructure` | Infrastructure as code in Bicep. Should include a `main.bicep` and parameter files
`src/<integration-suffix>/workflow` | Contains Logic App workflow definitions
`src/<integration-suffix>/function` | Contains Function App workflow definitions
[`bicepconfig.json`](bicepconfig.json) | Bicep Registry configuration. Required to retrieve modules from Azure Container Registry. Ensure you have authenticated with AZ CLI and have ACR Pull over the registry

## Infrastructure

The integration infrastructure is defined using [Bicep](https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/overview?tabs=bicep).

Bicep Modules are leveraged To provide repeatable patterns and simplify integration definitions. Pattern Modules are stored in an Azure Container Registry to ensure that all workflows have access to the same Modules.

Connectivity to remote Bicep registries is configured within the [bicepconfig.json](bicepconfig.json) file. More information on Module configuration is available at [Add module settings in the Bicep config file](https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/bicep-config-modules)

You will need need an active Azure Login session with a user that holds `AcrPull` permissions on the Azure Container Registry in order to work locally with the `landingZone` and `pattern` modules.

### Validate Bicep

[PSRule](https://microsoft.github.io/PSRule/v2/) is included in this repository. [Install the PowerShell tools](https://microsoft.github.io/PSRule/v2/install-instructions/#installing-powershell) locally on your workstation and then you can validate any Bicep changes / edits you make.

For example, here's how to validate the Sample deployment Bicep. You must be in the root folder of the repository.

```PowerShell
Assert-PSRule -Format File -Path './.ps-rule/' -InputPath ./src/sample-integration/infrastructure/main.dev.bicepparam -Outcome Fail, Error;
```

> Note: your Bicep may return validation warnings / errors. Review warnings closely before proceeding to commit to source control and publishing to customer environments. 

### Integration Modules

## Contribute

Create a branch named `feature/<work item id>-<feature-description>`
