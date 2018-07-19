FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 49893
EXPOSE 44361

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY GroceryAPI/GroceryAPI.csproj GroceryAPI/
RUN dotnet restore GroceryAPI/GroceryAPI.csproj
COPY . .
WORKDIR /src/GroceryAPI
RUN dotnet build GroceryAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish GroceryAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GroceryAPI.dll"]
