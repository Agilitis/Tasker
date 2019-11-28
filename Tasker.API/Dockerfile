FROM mcr.microsoft.com/dotnet/core/sdk:2.2
EXPOSE 80
EXPOSE 443

RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -y build-essential nodejs

WORKDIR /src

COPY ../ .

WORKDIR /src/Tasker.API

RUN dotnet publish -c Release -o /out

ENTRYPOINT ["dotnet", "/out/Tasker.API.dll"]