#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

#The file is needed to start the application and connect to the database
COPY connection.env .

#For Linux and Windows the property used on HOST_IP is different: docker.host.internal
ENV HOST_IP=docker.for.mac.host.internal

#If we run the project on docker and use a local database, we need to replace the database server ip address with our ip address(ifconfig/ipconfig)
RUN sed -i "s/127.0.0.1/$HOST_IP/g" /app/connection.env

#http
EXPOSE 80
#https
EXPOSE 443
#mysql
EXPOSE 3306

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["BussinessLogicLayer/BussinessLogicLayer.csproj", "BussinessLogicLayer/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
COPY ["Utilities/Utilities.csproj", "Utilities/"]

RUN dotnet restore "WebApi/WebApi.csproj"

COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#Set the environment variables for the database connection
#DB_HOST should contain your ip address
ENV DB_HOST=$HOST_IP
ENV DB_PORT=3306
ENV DB_NAME=AIBESTDB
ENV DB_USER=AIBESTUser
ENV DB_PASSWORD=DevPass

ENTRYPOINT ["dotnet", "WebApi.dll"]
