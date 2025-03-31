# Integration Source

This folder is the root for integration source files including Bicep (IaC), Logic Apps (workflows) and, Functions (code).

## Creating a new integration

1. Copy the `/src/sample-integration` folder into the `src` folder.
2. Rename the folder with the integration suffix e.g. **IntegrationName**
   1. Remove any folders not required e.g. functions or workflows
3. Copy and rename [/.github/workflows/release-sample.yml](/.github/workflows/release-sample.yml) to `/.github/workflows/release-<IntegrationName>.yaml`
   1. remove any parameters not required
   2. Import the configure the integration suffix
4. Open the `function` or `workflow` folder in VSCode and develop your solution.
5. When ready to deploy, extract configuration from `local.settings.json` and populate the bicepparam file(s) accordingly.
6. Check-in your code and run the pipeline to deploy to your target environments.