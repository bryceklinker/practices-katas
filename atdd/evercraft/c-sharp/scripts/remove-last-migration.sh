#!/usr/bin/env bash

set -ex

dotnet tool run dotnet-ef migrations remove --project ./src/Evercraft.Web/Evercraft.Web.csproj