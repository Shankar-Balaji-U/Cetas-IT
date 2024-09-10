# Seamless Database Performance with Read Scale-Out 

## Usage of Database in Business central
Business central ofter interact with database by reading and writing.
1. In common, by running Codeunits, Entries and Vewing UI pages and Calls by Web Services.
2. For Analytical purpose, by queries, reports, or API pages.


## For whom:

If you run the Business Central database in a High Availability architecture, you can use the built-in Read Scale-Out feature in Azure SQL Database or SQL Server to load-balance read-only workloads.

Read Scale-Out uses read-only replica instead of read-write replica (also known as the primary database).

So they won't affect the performance of business processes.


Steps to Enable Read Scale-Out:
	1. Enable it in Business central Database.
	2.
	3.

1. Enable it in Business central Database.
	In the Business Central SAAS, read scale-out is readily available and automatically enabled on the databases.
		For On-Prem we need to Check these:
			1. Check database supports read scale-out.
			2. Enable read scale-out on the database.

			Note: 

			If Database runs on Azure SQL Database, determine whether the performance tier of the database supports read scale-out. You can then enable it if it's supported. For more information, see Use read-only replicas to load-balance read-only query workloads in the Azure SQL Database documentation.
