FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FitnessApp.API/FitnessApp.API.csproj", "FitnessApp.API/"]
COPY ["FitnessApp.Service/FitnessApp.Service.csproj", "FitnessApp.Service/"]
COPY ["FitnessApp.DAL/FitnessApp.DAL.csproj", "FitnessApp.DAL/"]
COPY ["FitnessApp.Core/FitnessApp.Core.csproj", "FitnessApp.Core/"]
RUN dotnet restore "FitnessApp.API/FitnessApp.API.csproj"
COPY . .
WORKDIR "/src/FitnessApp.API"
RUN dotnet build "FitnessApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FitnessApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitnessApp.API.dll"]
