FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime
WORKDIR /minions
COPY ./dist ./

ENV ASPNETCORE_ENVIRONMENT="Production" ASPNETCORE_URLS="http://*:3000"
EXPOSE 3000

RUN ls -la /minions

ENTRYPOINT ["dotnet", "api.dll"]