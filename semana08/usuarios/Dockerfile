    FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
    WORKDIR /app
    EXPOSE 7777

    ENV ASPNETCORE_URLS=http://+:7777
    FROM mcr.microsoft.com/dotnet/sdk:8.0.301 AS build
    ARG configuration=Release
    WORKDIR /src
    COPY ["src/Usuarios/Usuarios.Api/Usuarios.Api.csproj", "src/Usuarios/Usuarios.Api/"]
    RUN dotnet restore "src\Usuarios\Usuarios.Api\Usuarios.Api.csproj"
    COPY . .
    WORKDIR "/src/src/Usuarios/Usuarios.Api"
    RUN dotnet build "Usuarios.Api.csproj" -c $configuration -o /app/build

    FROM build AS publish
    ARG configuration=Release
    RUN dotnet publish "Usuarios.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

    FROM base AS final
    WORKDIR /app
    COPY --from=publish /app/publish .

    ENTRYPOINT ["dotnet", "Usuarios.Api.dll"]