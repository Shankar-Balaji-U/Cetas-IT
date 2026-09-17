Get-Module -ListAvailable | Select-Object Name, Version, Path | Format-Table -AutoSize

Connect-AzAccount -TenantId cc014a1f-a666-4014-b398-e54dfa2bbf40

Set-PSRepository -InstallationPolicy Trusted -Name PSGallery

Update-Module Az.*
