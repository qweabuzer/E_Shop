FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["E_Shop.API/E_Shop.API.csproj", "E_Shop.API/"]
COPY ["E_Shop.Application/E_Shop.Application.csproj", "E_Shop.Application/"]
COPY ["E_Shop.Core/E_Shop.Core.csproj", "E_Shop.Core/"]
COPY ["E_Shop.DataAccess/E_Shop.DataAccess.csproj", "E_Shop.DataAccess/"]
RUN dotnet restore "./E_Shop.API/./E_Shop.API.csproj"
COPY . .
WORKDIR "/src/E_Shop.API"
RUN dotnet build "./E_Shop.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./E_Shop.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN rm -f appsettings.json
COPY ["E_Shop.API/appsettings.Docker.json", "appsettings.json"]
ENTRYPOINT ["dotnet", "E_Shop.API.dll"]