FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./WebApi/WebApi.csproj" --disable-parallel
RUN dotnet publish "./WebApi/WebApi.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./
COPY ./connection.env ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "WebApi.dll"]