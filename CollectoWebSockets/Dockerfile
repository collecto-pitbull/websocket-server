# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY . .

# Restaurar dependencias
RUN dotnet restore "./CollectoWebSockets.csproj" --disable-parallel

# Publicar la aplicación
RUN dotnet publish "./CollectoWebSockets.csproj" -c Release -o /app --no-restore

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar la app publicada
COPY --from=build /app .

# Entrypoint
ENTRYPOINT ["dotnet", "CollectoWebSockets.dll"]