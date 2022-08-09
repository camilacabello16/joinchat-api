#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JoinChatApi/JoinChatApi.csproj", "JoinChatApi/"]
RUN dotnet restore "JoinChatApi/JoinChatApi.csproj"
COPY . .
WORKDIR "/src/JoinChatApi"
RUN dotnet build "JoinChatApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JoinChatApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JoinChatApi.dll"]