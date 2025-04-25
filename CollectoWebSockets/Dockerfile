# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj y restaurar dependencias
COPY *.sln .
COPY CollectoWebSockets/*.csproj ./CollectoWebSockets/
RUN dotnet restore

# Copiar todo y compilar
COPY CollectoWebSockets/. ./CollectoWebSockets/
WORKDIR /src/CollectoWebSockets
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto (ajusta si es diferente)
EXPOSE 7284
EXPOSE 5072

ENTRYPOINT ["dotnet", "CollectoWebSockets.dll"]