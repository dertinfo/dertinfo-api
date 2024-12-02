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

@description('Backend Service Url')
param apiPath string = '/api'

@description('Rate limit calls')
param rateLimitCalls int = 300

@description('Rate limit renewal period in seconds')
param rateLimitRenewalSecs int = 60

// #####################################################
// Variables
// #####################################################

var apiNameLower = toLower(apiName)

// #####################################################
// References
// #####################################################

// Get a reference to an existing APIM instance
resource apimInstance 'Microsoft.ApiManagement/service@2023-09-01-preview' existing = {
  name: apimInstanceName
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
  name: substring('backend-${apiNameLower}',0,80) // APIM has a 80 character limit on backend names
  parent: apimInstance
  properties: {
    url: backendServiceUrl
    description: 'Backend for the ${apiName} API'
    protocol: 'https'
  }
}

/* todo - deal with the subscription requirement by default*/
