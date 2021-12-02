##### BACKEND
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-backend
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./src/dotnet-backend .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out


##### FRONTEND
FROM node:14.15-alpine3.13 AS build-frontend
WORKDIR /app
COPY ./src/angular-frontend/package*.json ./
RUN npm install
COPY ./src/angular-frontend/ .
RUN npx ng build --output-path ./dist/


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-backend /app/out .
COPY --from=build-frontend /app/dist/ ./dist/
ENTRYPOINT ["dotnet", "WebApi.dll"]
EXPOSE 80