FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /app
COPY . .
RUN dotnet restore && \
    dotnet publish -c Release -o /app/output

FROM mcr.microsoft.com/azure-functions/dotnet-isolated:4-dotnet-isolated8.0
WORKDIR /home/site/wwwroot
COPY --from=builder /app/output .

# Configurações ESSENCIAIS corrigidas:
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true \
    FUNCTIONS_WORKER_RUNTIME=dotnet-isolated \
    #Functions__Worker__HostEndpoint=http://0.0.0.0:80 \
    DOTNET_RUNNING_IN_CONTAINER=true

EXPOSE 80
#ENTRYPOINT ["dotnet", "ConsultaFunction.dll"]