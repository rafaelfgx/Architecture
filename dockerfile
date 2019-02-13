# .NET Core SDK
FROM microsoft/dotnet:2.2-sdk-alpine AS dotnetcore-sdk

WORKDIR /source

# Copy Projects Files
COPY source/Application/DotNetCoreArchitecture.Application.csproj ./Application/
COPY source/CrossCutting/DotNetCoreArchitecture.CrossCutting.csproj ./CrossCutting/
COPY source/Database/DotNetCoreArchitecture.Database.csproj ./Database/
COPY source/Domain/DotNetCoreArchitecture.Domain.csproj ./Domain/
COPY source/IoC/DotNetCoreArchitecture.IoC.csproj ./IoC/
COPY source/Model/DotNetCoreArchitecture.Model.csproj ./Model/
COPY source/Web/DotNetCoreArchitecture.Web.csproj ./Web/

# ASP.NET Core Restore
RUN dotnet restore ./Web/DotNetCoreArchitecture.Web.csproj

# Copy All Files
COPY source .

# ASP.NET Core Build
RUN dotnet build ./Web/DotNetCoreArchitecture.Web.csproj -c Release -o /app

# ASP.NET Core Publish
FROM dotnetcore-sdk AS dotnetcore-publish
RUN dotnet publish ./Web/DotNetCoreArchitecture.Web.csproj -c Release -o /app

# Angular
FROM node:11.8.0-alpine AS angular-build
ARG ANGULAR_ENVIRONMENT
WORKDIR /frontend
ENV PATH /frontend/node_modules/.bin:$PATH
COPY source/Web/Frontend/package.json .
RUN npm run restore
COPY source/Web/Frontend .
RUN npm run $ANGULAR_ENVIRONMENT

# ASP.NET Core Runtime
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS aspnetcore-runtime
WORKDIR /app
EXPOSE 80

# ASP.NET Core and Angular
FROM aspnetcore-runtime AS aspnetcore-angular
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
WORKDIR /app
COPY --from=dotnetcore-publish /app .
COPY --from=angular-build /frontend/dist ./Frontend/dist
ENTRYPOINT ["dotnet", "DotNetCoreArchitecture.Web.dll"]
