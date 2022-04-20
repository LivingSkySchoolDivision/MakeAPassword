FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MakeAPassword/MakeAPassword.csproj", "MakeAPassword/"]
RUN dotnet restore "MakeAPassword/MakeAPassword.csproj"
COPY . .
WORKDIR "/src/MakeAPassword"
RUN dotnet build "MakeAPassword.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MakeAPassword.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MakeAPassword.dll"]