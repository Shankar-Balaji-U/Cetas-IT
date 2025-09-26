Import-Module 'C:\Program Files (x86)\Microsoft Dynamics NAV\90\RoleTailored Client\NavModelTools.ps1';


$nav_version = 'v(16.0.0.0)';

$all_obj_name = 'all-objects-' + $nav_version + '.txt';

$base_source = 'D:\Nav Training\NAV CU Update\Base\NAV CU 50.txt';
$base_split_source = 'D:\Nav Training\NAV CU Update\Base\Split';

$modified_source = 'D:\Nav Training\NAV CU Update\Modified\NAV CU 50.txt';
$modified_split_source = 'D:\Nav Training\NAV CU Update\Modified\Split';


$delta_source = 'D:\Nav Training\NAV CU Update\Delta';

$target_source = 'D:\Nav Training\NAV CU Update\Target\NAV CU 67.txt';
$target_split_source = 'D:\Nav Training\NAV CU Update\Target\Split';

$result_source = 'D:\Nav Training\NAV CU Update\Result';

# $result_source_files = 'D:\Nav Training\NAV CU Update\Result\*.txt';

Split-NAVApplicationObjectFile -Source $base_source -Destination $base_split_source;

Split-NAVApplicationObjectFile -Source $modified_source -Destination $modified_split_source;

Split-NAVApplicationObjectFile -Source $target_source -Destination $target_split_source;


Compare-NAVApplicationObject -OriginalPath $base_split_source -ModifiedPath $modified_split_source -DeltaPath $delta_source;

Merge-NAVApplicationObject -OriginalPath $base_split_source -ModifiedPath $modified_split_source -TargetPath $target_split_source -ResultPath $result_source;

Join-NAVApplicationObjectFile -Source $result_source -Destination (Join-Path -Path $result_source -ChildPath $all_obj_name);
