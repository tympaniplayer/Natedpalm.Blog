FROM mcr.microsoft.com/dotnet/aspnet:5.0 as base
WORKDIR /DockerSource
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /DockerSource

COPY Natedpalm.Blog.sln .
COPY src/Natedpalm.Blog.Core/*.csproj ./src/Natedpalm.Blog.Core/
COPY src/Natedpalm.Blog.Infrastructure/*.csproj ./src/Natedpalm.Blog.Infrastructure/
COPY src/Natedpalm.Blog.Web/*.csproj ./src/Natedpalm.Blog.Web/
COPY tests/Natedpalm.Blog.FunctionalTests/*.csproj ./tests/Natedpalm.Blog.FunctionalTests/
COPY tests/Natedpalm.Blog.IntegrationTests/*.csproj ./tests/Natedpalm.Blog.IntegrationTests/
COPY tests/Natedpalm.Blog.UnitTests/*.csproj ./tests/Natedpalm.Blog.UnitTests/

RUN dotnet restore
COPY . .
WORKDIR /DockerSource/src/Natedpalm.Blog.Core
RUN dotnet build -c Release -o /app

WORKDIR /DockerSource/src/Natedpalm.Blog.Infrastructure
RUN dotnet build -c Release -o /app

FROM build AS publish
WORKDIR /DockerSource/src/Natedpalm.Blog.Web
RUN dotnet publish -c Release -o /app

FROM base as final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Natedpalm.Blog.Web.dll"]
