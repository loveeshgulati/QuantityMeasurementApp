# Multi-stage build for .NET 10 Web API
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files first for better layer caching
COPY QuantityMeasurementApp/QuantityMeasurementApp.sln ./
COPY QuantityMeasurementApp/QuantityMeasurementWebAPI/QuantityMeasurementWebAPI.csproj QuantityMeasurementApp/QuantityMeasurementWebAPI/
COPY QuantityMeasurementApp/QuantityMeasurementBusinessLayer/QuantityMeasurementBusinessLayer.csproj QuantityMeasurementApp/QuantityMeasurementBusinessLayer/
COPY QuantityMeasurementApp/QuantityMeasurementRepositoryLayer/QuantityMeasurementRepositoryLayer.csproj QuantityMeasurementApp/QuantityMeasurementRepositoryLayer/
COPY QuantityMeasurementApp/QuantityMeasurementModelLayer/QuantityMeasurementModelLayer.csproj QuantityMeasurementApp/QuantityMeasurementModelLayer/

# Restore dependencies
RUN dotnet restore QuantityMeasurementApp/QuantityMeasurementWebAPI/QuantityMeasurementWebAPI.csproj

# Copy the rest of the source code
COPY QuantityMeasurementApp/ .

# Build and publish
RUN dotnet publish QuantityMeasurementApp/QuantityMeasurementWebAPI/QuantityMeasurementWebAPI.csproj -c Release -o /app/publish --no-restore --no-self-contained

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Create non-root user for security
RUN groupadd --system --gid 1001 appgroup && \
    useradd --system --uid 1001 --gid 1001 appuser

# Copy published files
COPY --from=build /app/publish .

# Change ownership to non-root user
RUN chown -R appuser:appgroup /app
USER appuser

# Expose port
EXPOSE 8080

ENTRYPOINT ["dotnet", "QuantityMeasurementWebAPI.dll"]
