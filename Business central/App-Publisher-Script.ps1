Import-Module 'C:\Program Files\Microsoft Dynamics 365 Business Central\240\Service\NavAdminTool.ps1'

$serverName = '';
 
Get-NAVServerConfiguration -ServerInstance $serverName

$path = "E:\cetas\CETAS Information Technology_CedarLive_1.0.0.88.app";
 
$app = Get-NAVAppInfo -ServerInstance $serverName -Path $path -Tenant default

Publish-NAVApp -ServerInstance $serverName -Path $path -SkipVerification 

Sync-NAVApp -ServerInstance $serverName -Name $app.Name -Version $app.Version

Start-NAVAppDataUpgrade -ServerInstance $serverName -Name $app.Name -Version $app.Version
