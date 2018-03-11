FROM microsoft/aspnetcore:2.1.0-preview1  AS runtime
WORKDIR /app
COPY ./dist ./

ENV ASPNETCORE_ENVIRONMENT="Production" ASPNETCORE_URLS="http://*:3000"
EXPOSE 3000

ENTRYPOINT ["dotnet", "api.dll"]