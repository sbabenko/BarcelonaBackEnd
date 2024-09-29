# Use the latest .NET 8.0 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the project files
COPY . . 

# Restore the dependencies
RUN dotnet restore

# Build the project
RUN dotnet publish -c Release -o /out

# Use the ASP.NET Core runtime image for the final build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "BarcelonaBackEnd.dll"]
