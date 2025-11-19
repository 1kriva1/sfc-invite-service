#base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
LABEL service="SFC.Invite.Api" author="Kryvoruk Andrii" email="krivorukandrey@gmail.com"
USER root
WORKDIR /app

#restore & build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV HUSKY=False
WORKDIR /source
COPY ["Directory.Build.props", "."]
COPY ["nuget.config", "."]
COPY ["src/API/SFC.Invite.Api/SFC.Invite.Api.csproj", "src/API/SFC.Invite.Api/"]
COPY ["src/Core/SFC.Invite.Application/SFC.Invite.Application.csproj", "src/Core/SFC.Invite.Application/"]
COPY ["src/Core/SFC.Invite.Domain/SFC.Invite.Domain.csproj", "src/Core/SFC.Invite.Domain/"]
COPY ["src/Infrastructure/SFC.Invite.Infrastructure/SFC.Invite.Infrastructure.csproj", "src/Infrastructure/SFC.Invite.Infrastructure/"]
COPY ["src/Infrastructure/SFC.Invite.Infrastructure.Persistence/SFC.Invite.Infrastructure.Persistence.csproj", "src/Infrastructure/SFC.Invite.Infrastructure.Persistence/"]
COPY ["src/Contracts/SFC.Invite.Contracts/SFC.Invite.Contracts.csproj", "src/Contracts/SFC.Invite.Contracts/"]
COPY ["src/Contracts/SFC.Invite.Messages/SFC.Invite.Messages.csproj", "src/Contracts/SFC.Invite.Messages/"]
RUN dotnet restore "./src/API/SFC.Invite.Api/SFC.Invite.Api.csproj" --property:HUSKY=$HUSKY
COPY [".", "."]
WORKDIR "/source/src/API/SFC.Invite.Api"
RUN dotnet build "./SFC.Invite.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --output /app/build

#publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SFC.Invite.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --property:UseAppHost=false --output /app/publish

#final
FROM base AS final
ARG HTTP_PORT=8080
ARG HTTPS_PORT=8081
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE $HTTP_PORT
EXPOSE $HTTPS_PORT
ENTRYPOINT ["bash", "entrypoint.sh"]