#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApiHello/WebApiHello.csproj", "WebApiHello/"]
RUN dotnet restore "WebApiHello/WebApiHello.csproj"
COPY . .
WORKDIR "/src/WebApiHello"
RUN dotnet build "WebApiHello.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiHello.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiHello.dll"]