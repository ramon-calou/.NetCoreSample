FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env

LABEL version="1.0" maintainer="Ramon Calou"

WORKDIR /app

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "RestaurantsApi.dll"]