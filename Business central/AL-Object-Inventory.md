# AL Object Inventory

A PowerShell utility to scan an AL project recursively, extract AL object declarations, display the results grouped by object type, and export the inventory to a CSV file.

## Overview

The script searches the current directory and all subdirectories for `.al` files. It extracts:

- **Object Type** — for example, `table`, `page`, `codeunit`, or `enum`
- **Object ID**
- **Object Name**
- **File Name**

Results are sorted by object type and object ID.

## Prerequisites

- Windows PowerShell or PowerShell 7+
- An AL project containing `.al` source files

## Usage

1. Save the script as `Get-ALObjectInventory.ps1` in the AL project root.
2. Open PowerShell in the project directory.
3. Run:

   ```powershell
   .\\Get-ALObjectInventory.ps1
   ```

By default, the script scans the current directory (`$Path = "."`) and its subdirectories.

## Script

```powershell
$Path = "."

$Regex = '^\\s*(?<Type>tableextension|pageextension|enumextension|reportextension|permissionsetextension|permissionset|controladdin|codeunit|interface|xmlport|profile|query|report|table|page|enum)\\s+(?<Id>\\d+)\\s+(?<Name>"[^"]+"|[^\\r\\n{]+?)\\s*$'

$Objects = foreach ($File in (Get-ChildItem -Path $Path -Filter "*.al" -Recurse -File)) {
    foreach ($Line in (Get-Content $File.FullName)) {
        if ($Line -match $Regex) {
            [PSCustomObject]@{
                ObjectType = $Matches["Type"]
                ObjectID   = [int]$Matches["Id"]
                ObjectName = $Matches["Name"].Trim().Trim('"')
                FileName   = $File.Name
            }
        }
    }
}

$Objects |
    Sort-Object ObjectType, ObjectID |
    Format-Table ObjectType, ObjectID, ObjectName -GroupBy ObjectType -AutoSize

$Objects |
    Sort-Object ObjectType, ObjectID |
    Export-Csv ".\\ALObjects.csv" -NoTypeInformation -Encoding UTF8
```

## Output

### PowerShell

The inventory is displayed in the console, grouped by object type.

### CSV

The script creates `ALObjects.csv` in the current working directory. The CSV contains:

| Column | Description |
|---|---|
| `ObjectType` | AL object category |
| `ObjectID` | Numeric object ID |
| `ObjectName` | AL object name |
| `FileName` | Name of the source `.al` file |

The CSV can be opened in Microsoft Excel or used for further analysis.

## Notes and Limitations

- The regular expression matches object declarations on a single line, such as `page 50100 "POS Layout Card"`.
- The opening brace (`{`) may appear on the following line.
- The script extracts declarations from source text; it does not compile or validate the AL project.
- The script recognizes the object types listed in the regular expression. Add more object types to the `Type` group as needed.
- `FileName` contains only the source file name, not its full path. If duplicate file names are possible, consider storing `$File.FullName` instead.
