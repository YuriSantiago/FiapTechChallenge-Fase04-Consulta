FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Core ./Core
COPY Infrastructure ./Infrastructure
COPY Consulta ./Consulta

WORKDIR /src/Consulta

RUN dotnet restore Consulta.csproj
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "Consulta.dll"]