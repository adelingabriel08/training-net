FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Training.Backend.API2/Training.Backend.API2.csproj", "Training.Backend.API2/"]
RUN dotnet restore "Training.Backend.API2/Training.Backend.API2.csproj"
COPY . .
WORKDIR "/src/Training.Backend.API2"
RUN dotnet build "Training.Backend.API2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Training.Backend.API2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Training.Backend.API2.dll"]
