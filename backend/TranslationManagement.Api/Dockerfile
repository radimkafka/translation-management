#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT="production"

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TranslationManagement.Api/TranslationManagement.Api.csproj", "TranslationManagement.Api/"]
COPY ["TranslationManagement.Business/TranslationManagement.Business.csproj", "TranslationManagement.Business/"]
COPY ["External.ThirdParty.Services/External.ThirdParty.Services.csproj", "External.ThirdParty.Services/"]
COPY ["TranslationManagement.Data/TranslationManagement.Data.csproj", "TranslationManagement.Data/"]
RUN dotnet restore "TranslationManagement.Api/TranslationManagement.Api.csproj"
COPY . .
WORKDIR "/src/TranslationManagement.Api"
RUN dotnet build "TranslationManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "TranslationManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TranslationManagement.Api.dll"]