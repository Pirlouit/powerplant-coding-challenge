FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ["PowerplantChallenge.Core/PowerplantChallenge.Core.csproj", "PowerplantChallenge.Core/"]
COPY ["PowerplantChallenge.WebApi/PowerplantChallenge.WebApi.csproj", "PowerplantChallenge.WebApi/"]
RUN dotnet restore "PowerplantChallenge.WebApi/PowerplantChallenge.WebApi.csproj"
COPY . .
RUN dotnet publish "PowerplantChallenge.WebApi/PowerplantChallenge.WebApi.csproj" -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PowerplantChallenge.WebApi.dll"]