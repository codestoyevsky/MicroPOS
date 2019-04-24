# MicroPOS
.NET Developer Techical Task

EF migration is enabled in this project. To create initial DB please update web.config connection string credentials 
And after run this command

update-Database -projectName "MicroPOS.DataAccess" -startUpProjectName "MicroPOS.API" -verbose
