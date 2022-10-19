#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TestDynamo/TestDynamo.csproj", "TestDynamo/"]
RUN dotnet restore "TestDynamo/TestDynamo.csproj"
COPY . .
WORKDIR "/src/TestDynamo"
RUN dotnet build "TestDynamo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestDynamo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestDynamo.dll"]