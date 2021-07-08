
In this example I'm using [Docker for SQL Server](https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash)

You can run it with
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyBigPassword1!" -p 1433:1433 --name sql1 -h sql1 -d mcr.microsoft.com/mssql/server:2019-latest
```

Inspect the IP with
```bash
docker inspect sql1 | grep "IPAddress"
```

Then login with SSMS
server name: 'localhost,1433'
Username: sa
Password: MyBigPassword1!
