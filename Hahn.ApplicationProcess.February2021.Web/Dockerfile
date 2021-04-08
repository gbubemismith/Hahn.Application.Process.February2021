FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Hahn.ApplicationProcess.February2021.Web/Hahn.ApplicationProcess.February2021.Web.csproj", "Hahn.ApplicationProcess.February2021.Web/"]
COPY ["Hahn.ApplicationProcess.February2021.Data/Hahn.ApplicationProcess.February2021.Data.csproj", "Hahn.ApplicationProcess.February2021.Data/"]
COPY ["Hahn.ApplicationProcess.February2021.Domain/Hahn.ApplicationProcess.February2021.Domain.csproj", "Hahn.ApplicationProcess.February2021.Domain/"]
RUN dotnet restore "Hahn.ApplicationProcess.February2021.Web/Hahn.ApplicationProcess.February2021.Web.csproj"
COPY . .
WORKDIR "/src/Hahn.ApplicationProcess.February2021.Web"
RUN dotnet build "Hahn.ApplicationProcess.February2021.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hahn.ApplicationProcess.February2021.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hahn.ApplicationProcess.February2021.Web.dll"]
