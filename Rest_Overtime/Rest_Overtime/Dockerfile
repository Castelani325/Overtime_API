# 1. Fase de Build (Usa o SDK do .NET 10)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copia os arquivos de projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código e compila
COPY . ./
RUN dotnet publish -c Release -o out

# 2. Fase de Execução (Runtime leve)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta que o Docker vai usar
EXPOSE 80
EXPOSE 443

# Comando para iniciar a API
ENTRYPOINT ["dotnet", "Rest_Overtime.dll"]