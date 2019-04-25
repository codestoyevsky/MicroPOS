# MicroPOS
.NET Developer Technical Task

### Live Demos 

- URL: https://micropos.azurewebsites.net
- Swagger: https://micropos.azurewebsites.net/swagger

### Installation

EF migration is enabled in this project. To create initial DB please update web.config connection string credentials 
And after run this command

You need to enter proper crdentials

- 1.Server Name
- 2.User Name
- 3.User Password

```
<add name="MicroPos" connectionString="Data Source=.\;Initial Catalog=MicroPos;user id=sa;password=justSql1;" providerName="System.Data.SqlClient" />
```

After updating web.config run this command :


```sh
update-Database -projectName "MicroPOS.DAL" -startUpProjectName "MicroPOS.API" -verbose
```

You can run it on Package Manager Console 


### Tech
* [ASP.NET WEB API] 
* [AutoMapper] 
* [Swagger] 
* [Entity Framework] 
* [Migration in Entity Framework]
* [NUnit]
* [Shoudly]
* [Azure Web Service]
* [Azure SQL Database]


### Todos
 - Write MORE Tests
 - Validation can be improved
 - Add more details to swagger 
 - Implement IoC, Unity Container 
