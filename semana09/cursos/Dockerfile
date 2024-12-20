    FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
    WORKDIR /app
    EXPOSE 9999 5001

    FROM mcr.microsoft.com/dotnet/sdk:8.0.301 AS build
    ARG configuration=Release
    WORKDIR /src
    COPY ["src/Cursos/Cursos.Api/Cursos.Api.csproj", "src/Cursos/Cursos.Api/"]
    RUN dotnet restore "src\Cursos\Cursos.Api\Cursos.Api.csproj"
    COPY . .
    WORKDIR "/src/src/Cursos/Cursos.Api"
    RUN dotnet build "Cursos.Api.csproj" -c $configuration -o /app/build

    FROM build AS publish
    ARG configuration=Release
    RUN dotnet publish "Cursos.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

    FROM base AS final
    WORKDIR /app
    COPY --from=publish /app/publish .

    ENTRYPOINT ["dotnet", "Cursos.Api.dll"]