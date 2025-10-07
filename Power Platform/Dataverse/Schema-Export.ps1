
Register-PSRepository -Name "MyPowerPlatformRepo" -SourceLocation "https://my.powerplatform.repo.url/api/v2/" -InstallationPolicy Trusted


# Install the core administration modules
Install-Module -Name Microsoft.PowerApps.Administration.PowerShell -Scope CurrentUser -Force
Install-Module -Name Microsoft.PowerApps.PowerShell -Scope CurrentUser -Force

# Install the Dataverse connector module
Install-Module -Name Microsoft.Xrm.Tooling.CrmConnector.PowerShell -Scope CurrentUser -Force


Import-Module Microsoft.PowerApps.Administration.PowerShell -Verbose
# Import-Module Microsoft.PowerApps.PowerShell -Verbose
Import-Module Microsoft.Xrm.Tooling.CrmConnector.PowerShell -Verbose


# Connect to Dataverse interactively
$envUrl = 'https://orgb65ee896.crm8.dynamics.com/';

# Define connection details
$tenantId = '';
$clientID = '';
$clientSecret = '';

# Create authentication context
$secureSecret = ConvertTo-SecureString $clientSecret -AsPlainText -Force
$credential = New-Object System.Management.Automation.PSCredential ($clientId, $secureSecret)



$connection = Get-CrmConnection -ConnectionString "AuthType=OAuth;
  Username=shankarbalaji.u@cetastech.com;
  Integrated Security=true;
  Url=$envUrl;
  AppId=0331f0c0-46f5-41df-ae29-b3ed559bd19f;
  ClientId=$clientID;
  ClientSecret=$clientSecret;
  RedirectUri=https://login.microsoftonline.com/common/oauth2/nativeclient;
  LoginPrompt=Auto"
