# InventoryControl

Prerequisites: https://dotnet.microsoft.com/download/dotnet-core/3.1

DB: MSSQL

#### Running the Inventory System
In order to run the application, please follow below steps
##### 1. Setting Up the Database
Create a database named InventoryDB on MSSQL
Execute below SQL script on the created MSSQL database named InventoryDB
```sql
USE [InventoryDB]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 5/16/2020 8:59:25 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 5/16/2020 8:59:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL,
	[AvailableQuantity] [int] NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[ReorderLimit] [int] NOT NULL
) ON [PRIMARY]
GO
```
##### 2. Running the API
Go to the folder and change the placeholder:{MSSQL SERVER NAME} in appsettings.json file as below to point to the correct DB
```
cd InventoryControl\Inventory_API\InventoryControl.API
```
```json
{ 
  "ConnectionStrings": {
  "DefaultConnection": "{MSSQL SERVER NAME};Database=InventoryDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
Execute below command from the same folder
```
dotnet run
```
Inverntory Product API would start and be listening on http://localhost:5030

##### 3. Running the Web Application
```
cd InventoryControl\Inventory_Web\src\InventoryControl.Web
dotnet run
```
Application would start on :  https://localhost:5001

Also note if any of the launched URLs are changed, relevant settings should be changed accordingly. Default API URL setting of Web application works correctly

##### OKTA Set up
As the IDP Okta dev server (https://dev-381291.okta.com/) has been setup and relevant settings are already updated, so no change required. To login to the application please use below credentials

Username:  suhashiniweerakoon@gmail.com

Temporary password:  Welcome@99x


