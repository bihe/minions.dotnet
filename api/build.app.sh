#!/bin/bash

echo "Clean solution"

dotnet clean -c Debug
dotnet clean -c Release

dotnet build -c Release 

rm -rf "$PWD/../docker/dist"

dotnet publish ./api.csproj -c Release -v m -o "$PWD/../docker/dist"
