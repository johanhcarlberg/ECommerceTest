FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY ./ECommerceTest.API/*.csproj ECommerceTest.API/
COPY ./ECommerce.DataAccess/*.csproj ECommerce.DataAccess/
COPY ./Shared/*.csproj Shared/

RUN dotnet restore ./ECommerceTest.API/ECommerceTest.API.csproj

COPY . ./
RUN dotnet publish ./ECommerceTest.API -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "ECommerceTest.API.dll"]