# MicroPOS
.NET Developer Technical Task

EF migration is enabled in this project. To create initial DB please update web.config connection string credentials 
And after run this command

You need to enter proper crdentials
1.Server Name
2.User Name
3.User Password

```
<add name="MicroPos" connectionString="Data Source=.\;Initial Catalog=MicroPos;user id=sa;password=justSql1;" providerName="System.Data.SqlClient" />
```

After updating web.config run this command :


```C#
update-Database -projectName "MicroPOS.DAL" -startUpProjectName "MicroPOS.API" -verbose
```

You can run it on Package Manager Console 
