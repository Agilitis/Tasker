FROM mcr.microsoft.com/dotnet/core/sdk:2.2
EXPOSE 80
EXPOSE 443
WORKDIR /src

RUN apt-get update
RUN apt-get -y install curl gnupg
RUN curl -sL https://deb.nodesource.com/setup_11.x  | bash -
RUN apt-get -y install nodejs

COPY ["Tasker.WebApp/Tasker.WebApp.csproj", "Tasker.WebApp/"]
COPY ["Tasker.Repository/Tasker.Repository.csproj", "Tasker.Repository/"]
COPY ["Tasker.DataAccessLayer/Tasker.DataAccessLayer.csproj", "Tasker.DataAccessLayer/"]
COPY ["Tasker.Model/Tasker.Model.csproj", "Tasker.Model/"]
RUN dotnet restore "Tasker.WebApp/Tasker.WebApp.csproj"
COPY ["Tasker.WebApp/ClientApp/package.json", "ClientApp/"]
COPY ["Tasker.WebApp/ClientApp/package-lock.json", "ClientApp/"]


COPY . .

WORKDIR "/src/Tasker.WebApp"

RUN dotnet build "Tasker.WebApp.csproj" -c Release -o /app/build

WORKDIR "/app/build"

ENTRYPOINT ["dotnet", "Tasker.WebApp.dll"]
