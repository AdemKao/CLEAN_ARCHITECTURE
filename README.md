# CLEAN_ARCHITECTURE_DDD

## Contents
- [CLEAN_ARCHITECTURE_DDD](#clean_architecture_ddd)
  - [Contents](#contents)
  - [Source](#source)
  - [Summary](#summary)
  - [Clean Architecture](#clean-architecture)
  - [Project Architecture](#project-architecture)
  - [Project Setup](#project-setup)
    - [Create project](#create-project)
    - [Build project](#build-project)
    - [Create dependencies between Projects](#create-dependencies-between-projects)
      - [Api Add Reference to Contracts, Application](#api-add-reference-to-contracts-application)
      - [Infrastructure Add Reference to Application](#infrastructure-add-reference-to-application)
      - [Application Add Reference to Domain](#application-add-reference-to-domain)
      - [Api Add Reference to Infrastructure](#api-add-reference-to-infrastructure)
      - [Conculsion](#conculsion)
    - [Build the solution](#build-the-solution)
    - [Install VSCode Extension And Test](#install-vscode-extension-and-test)
      - [Run Web Api](#run-web-api)
      - [Create a new folder Request](#create-a-new-folder-request)
      - [Conclusion](#conclusion)
    - [Change BuberDinner.Api's Program.cs](#change-buberdinnerapis-programcs)
    - [Delete Swashbuckle.AspNetCore in BuberDinner.Api.csproj](#delete-swashbuckleaspnetcore-in-buberdinnerapicsproj)
    - [Move every ItemGroup -> ProjectReference below down <PropertyGroup> in each project](#move-every-itemgroup---projectreference-below-down-propertygroup-in-each-project)
    - [Delete Class1.cs in each project](#delete-class1cs-in-each-project)
    - [run dotnet build to check everything is fine](#run-dotnet-build-to-check-everything-is-fine)
  - [Auth endpoints](#auth-endpoints)
    - [Create a Register and Login](#create-a-register-and-login)
      - [Create a folder which name Docs](#create-a-folder-which-name-docs)
      - [Create a folder which named Authentication in BuberDinner.Contracts](#create-a-folder-which-named-authentication-in-buberdinnercontracts)
      - [Create basic code in each .cs files](#create-basic-code-in-each-cs-files)

<hr>

## Source

https://www.youtube.com/watch?v=ZwQf_JQUUCQ&t=576s

## Summary

- Project Setup
  - Create solution & projects
  - Define project dependecies
- Auth endpoints
  - Create auth endpoints
  - Model Register, Login requests & responses
  - Create auth service which returns a mock response
- Use the 'REST Client' vscode plugin to query the API
- Setup dependency injection for the application & Infrastructure layers
<hr>

## Clean Architecture

<img src="images/architecture_2.PNG" />

## Project Architecture

<img src="images/architecture_3.PNG" />

## Project Setup

### Create project

```dotnetcli
dotnet new sln -o CLEAN_ARCHITECTURE_DDD
cd CLEAN_ARCHITECTURE_DDD
dotnet new webapi -o BuberDinner.Api
dotnet new classlib -o BuberDinner.Contracts
dotnet new classlib -o BuberDinner.Infrastructure
dotnet new classlib -o BuberDinner.Application
dotnet new classlib -o BuberDinner.Domain
```

### Build project

1.  origin info
    ```dotnetcli
     more ./CLEAN_ARCHITECTURE_DDD.sln
    ```
2.  Add project to `.sln`
    ```dotnetcli
    dotnet sln add (ls -r **/*.csproj)
    ```
3.  Build the project
    ```dotnetcli
    dotnet build
    ```

### Create dependencies between Projects

#### Api Add Reference to Contracts, Application

```dotnetcli
dotnet add ./BuberDinner.Api/ reference ./BuberDinner.Contracts/ ./BuberDinner.Application/
```

#### Infrastructure Add Reference to Application

```dotnetcli
dotnet add ./BuberDinner.Infrastructure/ reference ./BuberDinner.Application/
```

#### Application Add Reference to Domain

```dotnetcli
dotnet add ./BuberDinner.Application/ reference ./BuberDinner.Domain/
```

#### Api Add Reference to Infrastructure

```dotnetcli
dotnet add ./BuberDinner.Api/ reference ./BuberDinner.Infrastructure/
```

#### Conculsion

for now we have five folders in this solution, and also you can see these five projects in `CLEAN_ARCHITECTURE_DDD.sln`

```
.
├── BuberDinner.Api
├── BuberDinner.Application
├── BuberDinner.Contracts
├── BuberDinner.Domain
├── BuberDinner.Infrastructure
├── CLEAN_ARCHITECTURE_DDD.sln
├── README.md
├── Request
└── images
```

to open the _BuberDinner.Api_, you can see the .Net.Sdk.Web in the `.csproj`

<hr>

### Build the solution

```dotnetcli
 % dotnet build
```

### Install VSCode Extension And Test

- REST Client

#### Run Web Api

```dotnetcli
dotnet run --project ./BuberDinner.Api/
```

#### Create a new folder Request

Then create a folder `Weather` in Request folder,and create a GetForcasts.http file

```bash
Request
└── Weather
    └── GetForcasts.http
```

In `GetForcast.http` file you can write the `Get`,`Post`etc... to url and click th send Request button.Then you will get the response

```
GET http://localhost:5124/WeatherForecast
```

#### Conclusion

It's a simple tool to test request to your api end point.

<hr>

### Change BuberDinner.Api's Program.cs

for now we don't need these things

1. builder.Services.AddEndpointsApiExplorer();
2. builder.Services.AddSwaggerGen();
3. app.UseAuthorization();
4. app.UseSwagger();
5. app.UseSwaggerUI();
   so the final code will be

```cs
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
}
var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

```

### Delete Swashbuckle.AspNetCore in BuberDinner.Api.csproj

```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\BuberDinner.Contracts\BuberDinner.Contracts.csproj" />
    <ProjectReference Include="..\BuberDinner.Application\BuberDinner.Application.csproj" />
    <ProjectReference Include="..\BuberDinner.Infrastructure\BuberDinner.Infrastructure.csproj" />
  </ItemGroup>

</Project>
```

### Move every ItemGroup -> ProjectReference below down <PropertyGroup> in each project

### Delete Class1.cs in each project

### run dotnet build to check everything is fine

```
dotnet build
```

the current folder structure will be down below

```
.
├── BuberDinner.Api
│   ├── BuberDinner.Api.csproj
│   ├── Controllers
│   ├── Program.cs
│   ├── Properties
│   ├── WeatherForecast.cs
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── bin
│   └── obj
├── BuberDinner.Application
│   ├── BuberDinner.Application.csproj
│   ├── bin
│   └── obj
├── BuberDinner.Contracts
│   ├── BuberDinner.Contracts.csproj
│   ├── bin
│   └── obj
├── BuberDinner.Domain
│   ├── BuberDinner.Domain.csproj
│   ├── bin
│   └── obj
├── BuberDinner.Infrastructure
│   ├── BuberDinner.Infrastructure.csproj
│   ├── bin
│   └── obj
├── CLEAN_ARCHITECTURE_DDD.sln
├── README.md
├── Request
```
## Auth endpoints
### Create a Register and Login

<img src="images/architecture_4.PNG" />

#### Create a folder which name Docs

```
Docs
└── Api.md
```
#### Create a folder which named Authentication in BuberDinner.Contracts
Then Create `RegisterRequest.cs`, `LoginRequest.cs` and `AuthenticationResponse.cs`

```
BuberDinner.Contracts
├── Authentication
│   ├── AuthenticationResponse.cs
│   ├── LoginRequest.cs
│   └── RegisterRequest.cs
└── BuberDinner.Contracts.csproj
```
#### Create basic code in each .cs files
you can see details in these files