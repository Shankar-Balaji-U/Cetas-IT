# Root Cause Analysis – SQL Full-Text Search Failure in Business Central

## Issue Summary

Users were unable to open or search the Customer List page in Microsoft Dynamics 365 Business Central.
The system displayed the following error message:

```text id="gw5vlg"
An unexpected error occurred after a database command was cancelled.
```

The page automatically closed after the error occurred.

---

# Business Central Error Details

The following SQL error message was displayed in Business Central:

```text id="8v9a0k"
SQL error message:
An error has occurred during the full-text query. Common causes include: word-breaking errors or timeout, FDHOST permissions/ACL issues, service account missing privileges, malfunctioning IFilters, communication channel issues with FDHost and sqlservr.exe, etc. If recently performed in-place upgrade to SQL2025, For help please see https://aka.ms/sqlfulltext.
```

---

# Root Cause

Business Central uses SQL Server Full-Text Search for optimized searching on master pages such as:

* Customers
* Vendors
* Items
* Contacts

During Customer search execution, Business Central generated a SQL query using the `CONTAINS()` function.

The SQL Server Full-Text catalog associated with the Customer table became corrupted, causing the Full-Text query execution to fail.

Affected Full-Text Catalog:

```text id="s7rb5y"
bc_fda220f4-c9da-ef11-9344-7c1e523f8025$Customer$437dbf0e-84ff-417a-965d-ed2bb9650972
```

This issue was related to SQL Server Full-Text Search infrastructure and was not caused by:

* Business Central customization
* AL code changes
* page extensions
* application performance issues

---

# Analysis Performed

## 1. SQL Query Validation

The SQL statement from the event log contained the following condition:

```sql id="9mjlwm"
CONTAINS("Customer"."No_",@0)
OR CONTAINS("Customer"."Name",@1)
OR CONTAINS("Customer"."Phone No_",@2)
OR CONTAINS("Customer"."Contact",@3)
```

This confirmed that:

* Business Central was using SQL Server Full-Text Search
* the failure occurred during Full-Text query execution

---

## 2. Full-Text Feature Validation

The following query was executed to verify whether SQL Full-Text Search was installed:

```sql id="bb1h8o"
SELECT FULLTEXTSERVICEPROPERTY('IsFullTextInstalled')
```

Result:

```text id="jlwmf8"
1
```

This confirmed that the SQL Full-Text Search feature was installed successfully.

---

## 3. Full-Text Catalog Identification

The following query was executed to identify the available Full-Text catalogs and associated tables:

```sql id="0k9l1v"
SELECT 
    c.name AS CatalogName,
    i.object_id,
    OBJECT_NAME(i.object_id) AS TableName
FROM sys.fulltext_indexes i
JOIN sys.fulltext_catalogs c
    ON i.fulltext_catalog_id = c.fulltext_catalog_id;
```

The following query was executed to retrieve all existing Full-Text catalogs:

```sql id="h3n8xq"
SELECT *
FROM sys.fulltext_catalogs;
```

The result confirmed the existence of the Customer Full-Text catalog:

```text id="3jlwm1"
bc_fda220f4-c9da-ef11-9344-7c1e523f8025$Customer$437dbf0e-84ff-417a-965d-ed2bb9650972
```

---

# Solution

The issue was resolved by rebuilding the corrupted SQL Server Full-Text catalog using the following SQL command:

```sql id="jlwm6v"
ALTER FULLTEXT CATALOG 
[bc_fda220f4-c9da-ef11-9344-7c1e523f8025$Customer$437dbf0e-84ff-417a-965d-ed2bb9650972]
REBUILD;
```

---

# Result

After rebuilding the Full-Text catalog:

* the Customer page opened successfully
* Customer search functionality resumed normally
* the SQL Full-Text query error was resolved completely

---

# Conclusion

The issue was caused by corruption in the SQL Server Full-Text catalog used by Business Central Customer search functionality.

The problem was infrastructure-related and not caused by:

* Business Central customization
* AL code
* application performance
* page extensions

Rebuilding the affected Full-Text catalog fully resolved the issue.
