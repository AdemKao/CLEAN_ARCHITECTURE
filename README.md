# CLEAN_ARCHITECTURE_DDD

##  Contents 

### Project Architecture
<img src="images/architecture.PNG" />

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
       more .\CLEAN_ARCHITECTURE_DDD.sln
      ```
  2.  Add project to `.sln`
      ```dotnetcli
      dotnet sln add (ls -r **\*.csproj)
      ```
  3.  Build the project
      ```dotnetcli
      dotnet build
      ```
### Add Contracts, Application Reference to Api
```dotnetcli
dotnet add .\BuberDinner.Api\ reference .\BuberDinner.Contracts\ .\BuberDinner.Application\
```
### Add Application Reference to Infrastructure
```dotnetcli
dotnet add .\BuberDinner.Infrastructure\ reference .\BuberDinner.Application\
```
### Add Domain Reference to Application
```dotnetcli
dotnet add .\BuberDinner.Application\ reference .\BuberDinner.Domain\
```
### Add Infrastructure Reference to Api
```dotnetcli
dotnet add .\BuberDinner.Api\ reference .\BuberDinner.Infrastructure\
```
### Install VSCode Extension
- REST Client

### Run Web Api
```dotnetcli
dotnet run --project .\BuberDinner.Api\
```