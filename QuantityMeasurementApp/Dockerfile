# Multi-stage build for .NET 10 Web API
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files first for better layer caching
COPY QuantityMeasurementApp.sln ./
COPY QuantityMeasurementWebAPI/QuantityMeasurementWebAPI.csproj QuantityMeasurementWebAPI/
COPY QuantityMeasurementBusinessLayer/QuantityMeasurementBusinessLayer.csproj QuantityMeasurementBusinessLayer/
COPY QuantityMeasurementRepositoryLayer/QuantityMeasurementRepositoryLayer.csproj QuantityMeasurementRepositoryLayer/
COPY QuantityMeasurementModelLayer/QuantityMeasurementModelLayer.csproj QuantityMeasurementModelLayer/

# Restore dependencies
RUN dotnet restore QuantityMeasurementWebAPI/QuantityMeasurementWebAPI.csproj

# Copy the rest of the source code
COPY . .

# Build and publish
RUN dotnet publish QuantityMeasurementWebAPI/QuantityMeasurementWebAPI.csproj -c Release -o /app/publish --no-restore

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Create non-root user for security
RUN addgroup --system --gid 1000 appgroup && \
    adduser --system --uid 1000 --gid 1000 appuser

# Copy published files
COPY --from=build /app/publish .

# Change ownership to non-root user
RUN chown -R appuser:appgroup /app
USER appuser

# Expose port
EXPOSE 8080

ENTRYPOINT ["dotnet", "QuantityMeasurementWebAPI.dll"]
