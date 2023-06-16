FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
ARG BUILD_TARGET="Release"

WORKDIR /src
COPY ./src/NAGP.DevOps.WebApi.sln ./
COPY ./src/NAGP.DevOps.Api/NAGP.DevOps.Api.csproj ./NAGP.DevOps.Api/
COPY ./src/NAGP.DevOps.Services/NAGP.DevOps.Services.csproj ./NAGP.DevOps.Services/
COPY ./src/NAGP.DevOps.Dto/NAGP.DevOps.Dto.csproj ./NAGP.DevOps.Dto/
COPY ./src/NAGP.DevOps.Data/NAGP.DevOps.Data.csproj ./NAGP.DevOps.Data/
RUN dotnet restore
ENTRYPOINT "/bin/sh"


COPY ./src ./
RUN dotnet publish -c $BUILD_TARGET -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
ARG ARG_ENVT
ARG BUILD_TARGET="Release"
ENV ASPNETCORE_ENVIRONMENT="Development"
WORKDIR /src
COPY --from=build /src/NAGP.DevOps.Api/bin/${BUILD_TARGET}/net6.0 .
ENTRYPOINT ["dotnet", "NAGP.DevOps.Api.dll"]