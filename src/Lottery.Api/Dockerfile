#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Lottery.Api/Lottery.Api.csproj", "src/Lottery.Api/"]
COPY ["src/Lottery.Data/Lottery.Data.csproj", "src/Lottery.Data/"]
RUN dotnet restore "src/Lottery.Api/Lottery.Api.csproj"
COPY . .
WORKDIR "/src/src/Lottery.Api"
RUN dotnet build "Lottery.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lottery.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lottery.Api.dll"]