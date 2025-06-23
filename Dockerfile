# Etapa 1: Compilación
# Usamos la imagen del SDK de .NET 8 para tener todas las herramientas de construcción.Add commentMore actions
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ApiV2.csproj", "."]
RUN dotnet restore "./ApiV2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ApiV2.csproj" -c Release -o /app/build

# Etapa 2: Publicación
# Tomamos los archivos compilados y los preparamos para producción.
FROM build AS publish
RUN dotnet publish "ApiV2.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: Imagen Final y Ligera
# Usamos una imagen más pequeña que solo tiene lo necesario para ejecutar la API.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiV2.dll"]