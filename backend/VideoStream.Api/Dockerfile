
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files
COPY VideoStream.slnx ./
COPY VideoStream.Api/VideoStream.Api.csproj VideoStream.Api/
COPY VideoStream.Application/VideoStream.Application.csproj VideoStream.Application/
COPY VideoStream.Domain/VideoStream.Domain.csproj VideoStream.Domain/
COPY VideoStream.InfraStructure/VideoStream.InfraStructure.csproj VideoStream.InfraStructure/
COPY VideoStream.Contracts/VideoStream.Contracts.csproj VideoStream.Contracts/
COPY VideoStream.Tests/VideoStream.Tests.csproj VideoStream.Tests/

# Restore dependencies
RUN dotnet restore VideoStream.slnx

# Copy source code
COPY . .

# Publish the API
RUN dotnet publish VideoStream.Api/VideoStream.Api.csproj \
    --configuration Release \
    --output /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "VideoStream.Api.dll"]
