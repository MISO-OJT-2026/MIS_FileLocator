# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["MIS_FileLocator.csproj", "./"]
RUN dotnet restore "MIS_FileLocator.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "MIS_FileLocator.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Railway uses port 8080 by default for containers
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MIS_FileLocator.dll"]
