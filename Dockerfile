FROM node:16

# Executar base de dados
# Use the official PostgreSQL image as the base image
FROM postgres:latest

# Set environment variables for PostgreSQL
ENV POSTGRES_USER admin
ENV POSTGRES_PASSWORD 12345
ENV POSTGRES_DB PGDB

# Copy the SQL script to create the table into the container
COPY ./be-nasa/DataBase/create_table1.sql /docker-entrypoint-initdb.d/
COPY ./be-nasa/DataBase/create_table2.sql /docker-entrypoint-initdb.d/

# Expose the PostgreSQL default port (5432)
EXPOSE 5432

# Executar BE

# Executar FE 

# Set the working directory to /app inside the container
WORKDIR /app
# Copy app files
COPY ./fe-nasa/package.json /app
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
CMD [ "npx", "start"]