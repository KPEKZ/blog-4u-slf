FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY backend/Directory.Packages.props ./
COPY backend/Blog4uSlf.sln ./

COPY backend/Blog4uSlf.Application/Blog4uSlf.Application.csproj Blog4uSlf.Application/
COPY backend/Blog4uSlf.Domain/Blog4uSlf.Domain.csproj Blog4uSlf.Domain/
COPY backend/Blog4uSlf.Infrastructure/Blog4uSlf.Infrastructure.csproj Blog4uSlf.Infrastructure/
COPY backend/Blog4uSlf.Web/Blog4uSlf.Web.csproj Blog4uSlf.Web/

RUN dotnet restore Blog4uSlf.Web/Blog4uSlf.Web.csproj

COPY backend/ .

RUN dotnet publish Blog4uSlf.Web/Blog4uSlf.Web.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5125
EXPOSE 5125

ENTRYPOINT ["dotnet", "Blog4uSlf.Web.dll"]
