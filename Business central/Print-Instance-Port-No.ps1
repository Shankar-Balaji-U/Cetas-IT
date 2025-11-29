Import-Module 'C:\Program Files\Microsoft Dynamics 365 Business Central\240\Service\NavAdminTool.ps1'

$version = '24'
$instances = Get-NAVServerInstance | Where-Object { $_.Version -like "$version*" }

$results = foreach ($instance in $instances) {
    $config = Get-NAVServerConfiguration -ServerInstance $instance.ServerInstance
    
    $configHash = @{ServerInstance = $instance.ServerInstance}
    $ports = @(
        'ManagementServicesPort',
        'ClientServicesPort', 
        'SOAPServicesPort',
        'ODataServicesPort',
        'DeveloperServicesPort',
        'SnapshotDebuggerServicesPort'
    )
    
    foreach ($port in $ports) {
        $configHash[$port] = ($config | Where-Object KeyName -eq $port).Value
    }
    
    [PSCustomObject]$configHash
}

# Display as table
$results | Format-Table -AutoSize
