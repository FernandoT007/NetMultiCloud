* **Solucion:**
    * dotnet new globaljson --sdk-version 8.0.301 --force
    * dotnet new sln -n Usuarios

* **Domain:** 
    * dotnet new classlib -o src/Usuarios/Usuarios.Domain
    * dotnet sln add .\src\Usuarios\Usuarios.Domain\Usuarios.Domain.csproj
    * cd .\src\Usuarios\Usuarios.Domain
    * dotnet add package MediatR.Contracts --version 2.0.1

* **Applicacion:** 
    * cd..
    * cd..
    * cd..
    * dotnet new classlib -o .\src\Usuarios\Usuarios.Application
    * dotnet sln add .\src\Usuarios\Usuarios.Application\Usuarios.Application.csproj
    * cd..
    * dotnet add .\src\Usuarios\Usuarios.Application\Usuarios.Application.csproj reference .\src\Usuarios\Usuarios.Domain\Usuarios.Domain.csproj
    * cd .\src\Usuarios\Usuarios.Application\
    * dotnet add package MediatR --version 12.2.0

* **Infrastructure:** 
    * cd..
    * cd..
    * cd..
    * dotnet new classlib -o src/Usuarios/Usuarios.Infrastructure
    * dotnet sln add .\src\Usuarios\Usuarios.Infrastructure\Usuarios.Infrastructure.csproj
    * dotnet add .\src\Usuarios\Usuarios.Infrastructure\Usuarios.Infrastructure.csproj reference .\src\Usuarios\Usuarios.Application\Usuarios.Application.csproj
    * cd .\src\Usuarios\Usuarios.Infrastructure\
    * dotnet add package Microsoft.EntityFrameworkCore --version 8.0.6
    * dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.4
    * dotnet add package EFCore.NamingConventions --version 8.0.3

* **Api:** 
    * cd..
    * cd..
    * cd..
    * dotnet new webapi -o src/Usuarios/Usuarios.Api --name Usuarios.Api
    * dotnet sln add .\src\Usuarios\Usuarios.Api\Usuarios.Api.csproj 
    * dotnet add .\src\Usuarios\Usuarios.Api\Usuarios.Api.csproj reference .\src\Usuarios\Usuarios.Application\Usuarios.Application.csproj 
    * dotnet add .\src\Usuarios\Usuarios.Api\Usuarios.Api.csproj reference .\src\Usuarios\Usuarios.Infrastructure\Usuarios.Infrastructure.csproj
    * cd .\src\Usuarios\Usuarios.Api\
    * dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.6
    * dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.6
    * dotnet tool install --global dotnet-ef --version 8.0.6
    * dotnet add package Bogus --version 35.5.1

* **Crear BD** 
    * dotnet ef --verbose migrations add InitialCreate -p .\src\Usuarios\Usuarios.Infrastructure\ -s .\src\Usuarios\Usuarios.Api\