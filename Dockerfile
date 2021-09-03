FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LSSDPasswordGenCore/LSSDPasswordGenCore.csproj", "LSSDPasswordGenCore/"]
COPY ["LSSDPasswordGenerators/LSSDPasswordGenerators.csproj", "LSSDPasswordGenerators/"]
RUN dotnet restore "LSSDPasswordGenCore/LSSDPasswordGenCore.csproj"
COPY . .
WORKDIR "/src/LSSDPasswordGenCore"
RUN dotnet build "LSSDPasswordGenCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LSSDPasswordGenCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LSSDPasswordGenCore.dll"]