# NortalTask

1. In order to run application, please add **appsettings.json** file:
```
{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  },


  "ConnectionStrings": {
    "EShopConnection": "Data Source=localhost;Initial Catalog=eShop;Integrated Security=True"
  }
}
```
2. To seed database with products please run SeedProducts.sql script.
