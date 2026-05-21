# 1. Aşama: Çalışma zamanı
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# 2. Aşama: Derleme (Build)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["BasketbolAPI.csproj", "./"]
RUN dotnet restore "./BasketbolAPI.csproj"

COPY . .
WORKDIR "/src/"
RUN dotnet build "BasketbolAPI.csproj" -c Release -o /app/build

# 3. Aşama: Yayınlama (Publish)
FROM build AS publish
RUN dotnet publish "BasketbolAPI.csproj" -c Release -o /app/publish

# 4. Aşama: Son imajı oluşturma
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketbolAPI.dll"]