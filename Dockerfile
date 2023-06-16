FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7121
ENV ASPNETCORE_URLS=http://+:7121

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .


FROM build AS publish
RUN dotnet publish "FarmCommerce/FarmCommerce.csproj" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "FarmCommerce.dll"]