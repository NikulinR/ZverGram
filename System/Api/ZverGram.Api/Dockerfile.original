#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["System/Api/ZverGram.Api/ZverGram.Api.csproj", "System/Api/ZverGram.Api/"]
RUN dotnet restore "System/Api/ZverGram.Api/ZverGram.Api.csproj"
COPY . .
WORKDIR "/src/System/Api/ZverGram.Api"
RUN dotnet build "ZverGram.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZverGram.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZverGram.Api.dll"]