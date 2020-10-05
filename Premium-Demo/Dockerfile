#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./Premium-Demo.csproj", "Premium-Demo/"]
RUN dotnet restore "Premium-Demo/Premium-Demo.csproj"
COPY . Premium-Demo/
WORKDIR "/src/Premium-Demo"
RUN dotnet build "Premium-Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Premium-Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Premium-Demo.dll"]