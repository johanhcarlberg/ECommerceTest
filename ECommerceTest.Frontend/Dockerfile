FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY ./ECommerceTest.Frontend/*.csproj ECommerceTest.Frontend/
COPY ./Shared/*.csproj Shared/

RUN dotnet restore ./ECommerceTest.Frontend/ECommerceTest.Frontend.csproj

COPY . ./
RUN dotnet publish ./ECommerceTest.Frontend -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "ECommerceTest.Frontend.dll"]