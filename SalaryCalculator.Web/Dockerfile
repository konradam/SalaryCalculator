FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SalaryCalculator.Web/SalaryCalculator.Web.csproj", "SalaryCalculator.Web/"]
RUN dotnet restore "SalaryCalculator.Web/SalaryCalculator.Web.csproj"
COPY . .
WORKDIR "/src/SalaryCalculator.Web"
RUN dotnet build "SalaryCalculator.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SalaryCalculator.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalaryCalculator.Web.dll"]