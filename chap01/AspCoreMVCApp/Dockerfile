FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AspCoreMVCApp/AspCoreMVCApp.csproj", "AspCoreMVCApp/"]
RUN dotnet restore "AspCoreMVCApp/AspCoreMVCApp.csproj"
COPY . .
WORKDIR "/src/AspCoreMVCApp"
RUN dotnet build "AspCoreMVCApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspCoreMVCApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspCoreMVCApp.dll"]
