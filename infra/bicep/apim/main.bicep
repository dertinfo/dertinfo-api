/*
Outline: API Definition for the DertInfo API Workload
Author: David Hall
Created: 2024-11-25
Prerequisites:
- The primary APIM instance has been deployed
Azure CLI Commands:
- az deployment group create --resource-group di-rg-apim-integration-[env] --template-file main.bicep --parameters @parameters-main-[env].json
*/

// #####################################################
// Parameters
// #####################################################

@description('The APIM instance name')
param apimInstanceName string

@description('The API Name')
param apiName string

@description('The API Description')
param apiDescription string

@description('Backend Service Url')
param backendServiceUrl string

@description('API URL suffix')
param apiPath string = ''

@description('Backend Resource Name')
param backendAppServiceName string

@description('Backend Resource Name')
param backendAppServiceResourceGroup string

// #####################################################
// Variables
// #####################################################

var resourceManagerUrl = environment().resourceManager
var apiNameLower = toLower(apiName)
var backendName = 'backend-${apiNameLower}'
var appServiceUrl = 'https://${backendAppServiceName}.azurewebsites.net'
var appServiceManagementUri = '${resourceManagerUrl}${appService.id}'

// #####################################################
// References
// #####################################################

// Get a reference to an existing APIM instance
resource apimInstance 'Microsoft.ApiManagement/service@2023-09-01-preview' existing = {
  name: apimInstanceName
}

resource appService 'Microsoft.Web/sites@2024-04-01' existing = {
  name: backendAppServiceName
  scope: resourceGroup(backendAppServiceResourceGroup)
}

// #####################################################
// Resources
// #####################################################

// Create an API in the APIM instance
resource api 'Microsoft.ApiManagement/service/apis@2023-09-01-preview' = {
  name: apiName
  parent: apimInstance
  properties: {
    displayName: apiName
    description: apiDescription
    serviceUrl: backendServiceUrl
    path: apiPath
    subscriptionRequired: false
    protocols: [
      'https'
    ]
    format: 'openapi'
    value: loadJsonContent('./openapi.json')
  }
}

// Create the API Policies
resource policy 'Microsoft.ApiManagement/service/apis/policies@2023-09-01-preview' = {
  name: 'policy'
  parent: api
  properties: {
    format: 'xml'
    value: loadTextContent('./policy.xml')
  }
}

resource backend 'Microsoft.ApiManagement/service/backends@2023-09-01-preview' = {
  name: backendName
  parent: apimInstance
  properties: {
    url: appServiceUrl
    description: 'Backend for the ${apiName} API'
    protocol: 'http'
    resourceId: appServiceManagementUri
  }
}
