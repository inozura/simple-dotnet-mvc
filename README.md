# Simple .NET MVC Application

<p>This is simple MVC app have less features such as Create(with upload file functionality) and View data from JSON</p>

## Project Running

### Install .Net SDK
  
  You need to install .Net SDK Version 6 in official Microsoft site

### Install library

  install the required libraries

```bash
  dotnet add package Npgsql.EntityFrameworkCore
  dotnet add package Microsoft.Extensions.Configuration
  dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Setup database

  Go to `appsettings.json` in the root directory project, then change `DefaultConnection` key to the postgresql database that you have.
  Example:

```json
  "ConnectionStrings": {
    "DefaultConnection": "User ID=admin;Password=123;Server=localhost;Port=5432;Database=mvc_dotnet;Integrated Security=true;Pooling=true;"
  }
```

  Then we need run migration to store initial column in database. First is you need to install `dotnet-ef` tools, you install with this command

```bash
  dotnet tool install --global dotnet-ef
```

  Then run migration
```bash
  dotnet ef database update
```


### Final

  Run the app with running this command

```bash
  dotnet watch
```