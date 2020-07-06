#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ApiTaxaJuros/ApiTaxaJuros.csproj", "ApiTaxaJuros/"]
RUN dotnet restore "ApiTaxaJuros/ApiTaxaJuros.csproj"
COPY . .
WORKDIR "/src/ApiTaxaJuros"
RUN dotnet build "ApiTaxaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiTaxaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiTaxaJuros.dll"]