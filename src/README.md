# Integration Source

This folder is the root for integration source files including Bicep (IaC), Logic Apps (workflows) and, Functions (code).

## Creating a new integration

1. Copy the `/src/.integration-template` folder into the `src` folder.
2. Rename the folder with the integration suffix e.g. **IntegrationName**
   1. Remove any folders not required e.g. functions or workflows
3. Copy and rename [/.azdo/.deploy.yaml](/.azdo/.deploy.yaml) to `/.azdo/<IntegrationName>.yaml`
   1. remove any parameters not required
   2. Import the configure the integration suffix
4. Import the `/.azdo/<IntegrationName>.yaml` into Azure DevOps Pipelines
   1. Move to the integration folder and rename with the integration suffix
   2. Approve service connections
5. Open the `function` or `workflow` folder in VSCode and develop your solution.
6. When ready to deploy, extract configuration from `local.settings.json` and populate the bicepparam file(s) accordingly.
7. Check-in your code and run the pipeline to deploy to your target environments.