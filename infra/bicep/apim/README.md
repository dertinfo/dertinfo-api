# API Management Registration

The bicep in this folder registers this api workload with the central APIM instance in order that we route requests form out clients through the APIM instance.

This happens automatically in the ADO pipelines for deploying the API ensring that the definition defined it the one that APIM is using.

**Please Note: At the time of writing (20241126) you must update the definition (openapi.json) in this folder**


## Deploy Manually

If you want to deploy this to an APIM instance manually you can you the following Azure CLI commands

```
cd infra/bicep/apim

az deployment group what-if --resource-group [resource group] --template-file main.bicep --parameters main.parameters.json

az deployment group create --resource-group [resource group] --template-file main.bicep --parameters main.parameters.json

```