FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy sln and csproj files to restore dependencies
COPY ["AeC.sln", "./"]
COPY ["src/AeC.Domain/AeC.Domain.csproj", "src/AeC.Domain/"]
COPY ["src/AeC.Application/AeC.Application.csproj", "src/AeC.Application/"]
COPY ["src/AeC.Infrastructure/AeC.Infrastructure.csproj", "src/AeC.Infrastructure/"]
COPY ["src/AeC.Web/AeC.Web.csproj", "src/AeC.Web/"]
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /src/src/AeC.Web
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "AeC.Web.dll"]
