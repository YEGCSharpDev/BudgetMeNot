FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BudgetMeNot.Web/BudgetMeNot.Web.csproj", "BudgetMeNot.Web/"]
COPY ["BudgetMeNot.Core/BudgetMeNot.Core.csproj", "BudgetMeNot.Core/"]
COPY ["BudgetMeNot.Infrastructure/BudgetMeNot.Infrastructure.csproj", "BudgetMeNot.Infrastructure/"]
RUN dotnet restore "BudgetMeNot.Web/BudgetMeNot.Web.csproj"
COPY . .
WORKDIR "/src/BudgetMeNot.Web"
RUN dotnet build "BudgetMeNot.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BudgetMeNot.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir /app/keys && chown -R 1000:1000 /app/keys

EXPOSE 80

ENTRYPOINT ["dotnet", "BudgetMeNot.Web.dll"]
