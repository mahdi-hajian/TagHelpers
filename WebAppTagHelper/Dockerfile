FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WebAppTagHelper/WebAppTagHelper.csproj", "WebAppTagHelper/"]
COPY ["TagHelpersLib/TagHelpersLib.csproj", "TagHelpersLib/"]
RUN dotnet restore "WebAppTagHelper/WebAppTagHelper.csproj"
COPY . .
WORKDIR "/src/WebAppTagHelper"
RUN dotnet build "WebAppTagHelper.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebAppTagHelper.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAppTagHelper.dll"]