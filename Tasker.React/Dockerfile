FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get install nodejs -y && apt-get install npm -y


WORKDIR /src

COPY . .
RUN dotnet restore
WORKDIR "/src/Tasker.API"
RUN dotnet publish "Tasker.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
RUN apt-get update && apt-get install nodejs -y && apt-get install npm -y
WORKDIR /app
COPY --from=build-env /app/publish .
COPY --from=build-env /src/Tasker.React/ClientApp .
ENTRYPOINT ["dotnet", "TeamGuide.WebApp.dll"]