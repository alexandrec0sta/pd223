# Executar base de dados
# Use the official PostgreSQL image as the base image
FROM postgres:latest

# Set environment variables for PostgreSQL
ENV POSTGRES_USER admin
ENV POSTGRES_PASSWORD 12345
ENV POSTGRES_DB PGDB

# Copy the SQL script to create the table into the container
WORKDIR /db
COPY ./be-nasa/DataBase/create_table1.sql /db/docker-entrypoint-initdb.d/
COPY ./be-nasa/DataBase/create_table2.sql /db/docker-entrypoint-initdb.d/

# Expose the PostgreSQL default port (5432)
EXPOSE 5432

# -------------------------------------------------------------------------------------------------

# Web Crawler
FROM mcr.microsoft.com/dotnet/runtime:5.0 AS basewc
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS buildwc
WORKDIR /src
COPY ["WebCrawler/WebCrawler.csproj", "WebCrawler/"]
RUN dotnet restore "WebCrawler/WebCrawler.csproj"
COPY . .
WORKDIR "/src/WebCrawler"
RUN dotnet build "WebCrawler.csproj" -c Release -o /app/build

FROM buildwc AS publishwc
RUN dotnet publish "WebCrawler.csproj" -c Release -o /app/publish

FROM basewc AS finalwc
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebCrawler.dll"]

# -------------------------------------------------------------------------------------------------

# Executar BE
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS basebe
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS buildbe
WORKDIR /src
COPY ["WebAppiBE/WebAppiBE.csproj", "WebAppiBE/"]
RUN dotnet restore "WebAppiBE/WebAppiBE.csproj"
COPY . .
WORKDIR "/src/WebAppiBE"
RUN dotnet build "WebAppiBE.csproj" -c Release -o /app/build

FROM buildbe AS publishbe
RUN dotnet publish "WebAppiBE.csproj" -c Release -o /app/publish

FROM basebe AS finalbe
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppiBE.dll"]

# Executar FE 
FROM node:16
# Set the working directory to /app inside the container
WORKDIR /fe-nasa
# Copy app files
COPY ./fe-nasa /fe-nasa
# COPY . .
# ==== BUILD =====
# Install dependencies (npm ci makes sure the exact versions in the lockfile gets installed)
RUN npm i 
# Build the app
RUN npm run build
# ==== RUN =======
# Set the env to "production"
ENV NODE_ENV production
# Expose the port on which the app will be running (3000 is the default that `serve` uses)
EXPOSE 3000
# Start the app
CMD [ "npm", "start"]