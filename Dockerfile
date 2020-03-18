FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-nanoserver-1903 AS build
WORKDIR /src
COPY SalaryCalculator.sln ./
COPY ["SalaryCalculator.Domain/SalaryCalculator.Domain.csproj", "SalaryCalculator.Domain/"]
COPY ["SalaryCalculator.Domain.EF/SalaryCalculator.Domain.EF.csproj", "SalaryCalculator.Domain.EF/"]
COPY ["SalaryCalculator.DAL/SalaryCalculator.DAL.csproj", "SalaryCalculator.DAL/"]
COPY ["SalaryCalculator.Web/SalaryCalculator.Web.csproj", "SalaryCalculator.Web/"]

COPY . .
RUN dotnet restore
WORKDIR "/src/SalaryCalculator.Domain"
RUN dotnet build "SalaryCalculator.Domain.csproj" -c Release -o /app
WORKDIR "/src/SalaryCalculator.Domain.EF"
RUN dotnet build "SalaryCalculator.Domain.EF.csproj" -c Release -o /app
WORKDIR "/src/SalaryCalculator.DAL"
RUN dotnet build "SalaryCalculator.DAL.csproj" -c Release -o /app
WORKDIR "/src/SalaryCalculator.Web"
RUN dotnet build "SalaryCalculator.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SalaryCalculator.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalaryCalculator.Web.dll"]