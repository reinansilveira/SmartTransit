FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SmartTransit.Application/SmartTransit.Application.csproj", "SmartTransit.Application/"] 
COPY ["SmartTransit.Domain/SmartTransit.Domain.csproj", "SmartTransit.Domain/"] 
COPY ["SmartTransit.Infrastructure/SmartTransit.Infrastructure.csproj", "SmartTransit.Infrastructure/"]
RUN dotnet restore "./SmartTransit.Application/SmartTransit.Application.csproj"
COPY . .
WORKDIR "/src/SmartTransit.Application"
RUN dotnet build "./SmartTransit.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SmartTransit.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartTransit.Application.dll"]