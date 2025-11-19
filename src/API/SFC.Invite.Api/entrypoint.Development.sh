#!/bin/sh

./src/API/SFC.Invite.Api/entrypoint.Common.sh
dotnet run --project /app/src/API/SFC.Invite.Api/SFC.Invite.Api.csproj --no-launch-profile