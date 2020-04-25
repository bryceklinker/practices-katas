#!/usr/bin/env bash

set -ex

export MIGRATION_NAME=$1

dotnet tool run dotnet-ef migrations add ${MIGRATION_NAME} \
    --project ./src/Evercraft.Web/Evercraft.Web.csproj \
    --context Evercraft.Web.Common.Storage.EvercraftContext \
    --output-dir Common/Storage/Migrations