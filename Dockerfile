FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Enviroment Variables
# ENV ConnectionString=Server=db4free.net;Port=3306;Database=sac_web_api;Uid=sac_web_api_ufjf;Pwd=s@cw3b4p1;

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SAC_WebAPI.dll"]