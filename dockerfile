# DotNet
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS dotnet
COPY source ./source
RUN dotnet publish ./source/Web/Architecture.Web.csproj --configuration Release --output /dist

# Frontend
FROM node:alpine AS frontend
RUN npm install -g pnpm
WORKDIR /source/Web/Frontend
COPY source/Web/Frontend/package.json .
RUN pnpm install
COPY source/Web/Frontend .
RUN npm run build

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=dotnet /dist .
COPY --from=frontend /source/Web/Frontend/dist/browser ./wwwroot
ENTRYPOINT ["dotnet", "Architecture.Web.dll"]
