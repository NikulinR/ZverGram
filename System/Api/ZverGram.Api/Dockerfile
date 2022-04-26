#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["System/Api/ZverGram.Api/ZverGram.Api.csproj", "System/Api/ZverGram.Api/"]
COPY ["Services/ZverGram.CategoryService/ZverGram.CategoryService.csproj", "Services/ZverGram.CategoryService/"]
COPY ["Shared/ZverGram.Common/ZverGram.Common.csproj", "Shared/ZverGram.Common/"]
COPY ["Data/ZverGram.Db.Context/ZverGram.Db.Context.csproj", "Data/ZverGram.Db.Context/"]
COPY ["Data/ZverGram.Db.Entities/ZverGram.Db.Entities.csproj", "Data/ZverGram.Db.Entities/"]
COPY ["Services/ZverGram.Settings/ZverGram.Settings.csproj", "Services/ZverGram.Settings/"]
COPY ["Services/ZverGram.CommentService/ZverGram.CommentService.csproj", "Services/ZverGram.CommentService/"]
COPY ["Services/ZverGram.ExhibitionService/ZverGram.ExhibitionService.csproj", "Services/ZverGram.ExhibitionService/"]
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