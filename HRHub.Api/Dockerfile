#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HRHub.Api/HRHub.Api.csproj", "HRHub.Api/"]
COPY ["HRHub.Application/HRHub.Application.csproj", "HRHub.Application/"]
COPY ["HRHub.Domain/HRHub.Domain.csproj", "HRHub.Domain/"]
COPY ["HRHub.Infrastructure/HRHub.Infrastructure.csproj", "HRHub.Infrastructure/"]
RUN dotnet restore "./HRHub.Api/HRHub.Api.csproj"
COPY . .
WORKDIR "/src/HRHub.Api"
RUN dotnet build "./HRHub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HRHub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRHub.Api.dll"]