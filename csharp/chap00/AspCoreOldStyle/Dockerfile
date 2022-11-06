FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AspCoreOldStyle/AspCoreOldStyle.csproj", "AspCoreOldStyle/"]
RUN dotnet restore "AspCoreOldStyle/AspCoreOldStyle.csproj"
COPY . .
WORKDIR "/src/AspCoreOldStyle"
RUN dotnet build "AspCoreOldStyle.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspCoreOldStyle.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspCoreOldStyle.dll"]