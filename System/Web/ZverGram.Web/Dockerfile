FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/Web/ZverGram.Web/ZverGram.Web.csproj", "Systems/Web/ZverGram.Web/ZverGram.Web.csproj"]
RUN dotnet restore "Systems/Web/ZverGram.Web/ZverGram.Web.csproj"
COPY . .
WORKDIR "/src/Systems/Web/ZverGram.Web"
RUN dotnet build "ZverGram.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZverGram.Web.csproj" -c Release -o /app/publish

FROM nginx:alpine
WORKDIR /var/www/web

COPY --from=publish /app/publish/wwwroot .
COPY Systems/Web/ZverGram.Web/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80