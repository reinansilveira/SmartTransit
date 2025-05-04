# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
COPY ["SmartTransit.Application/SmartTransit.Application.csproj", "SmartTransit.Application/"]
COPY ["SmartTransit.Domain/SmartTransit.Domain.csproj", "SmartTransit.Domain/"]
COPY ["SmartTransit.Infrastructure/SmartTransit.Infrastructure.csproj", "SmartTransit.Infrastructure/"]
RUN dotnet restore "./Api/Api.csproj"
COPY . .
WORKDIR /src/Api
RUN dotnet build "./Api.csproj" -c Release -o /app/build

# Etapa de publish
FROM build AS publish
RUN dotnet publish "./Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copiar o script wait-for-it.sh para o contêiner
COPY wait-for-it.sh /app/wait-for-it.sh

# Dar permissão de execução ao script
RUN chmod +x /app/wait-for-it.sh

# Comando para iniciar o contêiner
ENTRYPOINT ["/bin/bash", "/app/wait-for-it.sh", "mysql_db:3306", "--", "dotnet", "Api.dll"]
