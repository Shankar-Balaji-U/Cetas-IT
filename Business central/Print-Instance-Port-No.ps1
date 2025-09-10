$version = '24';
$instances = Get-NAVServerInstance | Where-Object { $_.Version -like "$version*" };

$ports = @(
    'ManagementServicesPort',
    'ClientServicesPort',
    'SOAPServicesPort',
    'ODataServicesPort',
    'DeveloperServicesPort',
    'SnapshotDebuggerServicesPort'
);

foreach ($instance in $instances) {
    $config = Get-NAVServerConfiguration -ServerInstance $instance.ServerInstance
    # Do something with $config if needed
 
    $config.ForEach({
        if ($_.KeyName -in @(
            'ManagementServicesPort',
            'ClientServicesPort',
            'SOAPServicesPort',
            'ODataServicesPort',
            'DeveloperServicesPort',
            'SnapshotDebuggerServicesPort'
        )) {
            "$($_.KeyName) : $($_.Value)"
        }
    })
}
