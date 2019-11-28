FROM mcr.microsoft.com/dotnet/core/sdk:2.2
EXPOSE 80
EXPOSE 443


WORKDIR /src

COPY . .

WORKDIR /src/Tasker.API

RUN dotnet publish -c Release -o /out

ENTRYPOINT ["dotnet", "/out/Tasker.API.dll"]