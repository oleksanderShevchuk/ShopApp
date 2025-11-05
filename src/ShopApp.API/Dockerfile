# Use official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj files and restore
COPY ./ShopApp.API/*.csproj ./ShopApp.API/
COPY ../../ShopApp.Infrastructure/*.csproj ./ShopApp.Infrastructure/
COPY ../../ShopApp.Application/*.csproj ./ShopApp.Application/
COPY ../../ShopApp.Domain/*.csproj ./ShopApp.Domain/
RUN dotnet restore ./ShopApp.API/ShopApp.API.csproj

# Copy all files and build
COPY ../../ ./
WORKDIR /app/ShopApp.API
RUN dotnet publish -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/ShopApp.API/out ./
EXPOSE 5000
EXPOSE 5001
ENTRYPOINT ["dotnet", "ShopApp.API.dll"]
