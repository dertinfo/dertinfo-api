#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["dertinfo-api/dertinfo-api.csproj", "dertinfo-api/"]
COPY ["dertinfo-models/dertinfo-models.csproj", "dertinfo-models/"]
COPY ["dertinfo-repository/dertinfo-repository.csproj", "dertinfo-repository/"]
COPY ["dertinfo-crosscutting/dertinfo-crosscutting.csproj", "dertinfo-crosscutting/"]
COPY ["dertinfo-services/dertinfo-services.csproj", "dertinfo-services/"]
RUN dotnet restore "dertinfo-api/dertinfo-api.csproj"
COPY . .
WORKDIR "/src/dertinfo-api"
RUN dotnet build "dertinfo-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dertinfo-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DertInfo.Api.dll"]