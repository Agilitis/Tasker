FROM mcr.microsoft.com/dotnet/core/sdk:2.2
EXPOSE 80
EXPOSE 443
WORKDIR /src

RUN apt-get update
RUN apt-get -y install curl gnupg
RUN curl -sL https://deb.nodesource.com/setup_11.x  | bash -
RUN apt-get -y install nodejs

COPY ["Tasker.Reactfrontend/Tasker.Reactfrontend.csproj", "Tasker.Reactfrontend/"]
COPY ["Tasker.Repository/Tasker.Repository.csproj", "Tasker.Repository/"]
COPY ["Tasker.DataAccessLayer/Tasker.DataAccessLayer.csproj", "Tasker.DataAccessLayer/"]
COPY ["Tasker.Model/Tasker.Model.csproj", "Tasker.Model/"]
RUN dotnet restore "Tasker.Reactfrontend/Tasker.Reactfrontend.csproj"
COPY ["Tasker.Reactfrontend/ClientApp/package.json", "ClientApp/"]
COPY ["Tasker.Reactfrontend/ClientApp/package-lock.json", "ClientApp/"]

RUN npm install

COPY . .

WORKDIR "/src/Tasker.Reactfrontend"

RUN dotnet build "Tasker.Reactfrontend.csproj" -c Release -o /app/build

ENTRYPOINT ["dotnet", "run"]
