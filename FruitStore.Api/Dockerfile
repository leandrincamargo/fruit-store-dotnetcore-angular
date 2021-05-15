#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FruitStore.Api/FruitStore.Api.csproj", "FruitStore.Api/"]
COPY ["FruitStore.Infrastructure.IoC/FruitStore.Infrastructure.IoC.csproj", "FruitStore.Infrastructure.IoC/"]
COPY ["FruitStore.Infrastructure/FruitStore.Infrastructure.csproj", "FruitStore.Infrastructure/"]
COPY ["FruitStore.Infrastructure.Interfaces/FruitStore.Infrastructure.Interfaces.csproj", "FruitStore.Infrastructure.Interfaces/"]
COPY ["FruitStore.Domain/FruitStore.Domain.csproj", "FruitStore.Domain/"]
COPY ["FruitStore.Application.IoC/FruitStore.Application.IoC.csproj", "FruitStore.Application.IoC/"]
COPY ["FruitStore.Application/FruitStore.Application.csproj", "FruitStore.Application/"]
COPY ["FruitStore.Application.Interfaces/FruitStore.Application.Interfaces.csproj", "FruitStore.Application.Interfaces/"]
RUN dotnet restore "FruitStore.Api/FruitStore.Api.csproj"
COPY . .
WORKDIR "/src/FruitStore.Api"
RUN dotnet build "FruitStore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FruitStore.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FruitStore.Api.dll"]