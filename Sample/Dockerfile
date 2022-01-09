FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src/Sample
COPY . "/src/Sample/"
RUN dotnet restore "Api/Sample.Api/Sample.Api.csproj"
RUN dotnet build "Api/Sample.Api/Sample.Api.csproj"

FROM build AS publish
RUN dotnet publish "../Sample/Api/Sample.Api/Sample.Api.csproj" -c Release -o ../../publish

FROM base AS final
COPY --from=publish ../../publish .

ENTRYPOINT ["dotnet", "Sample.Api.dll"]
