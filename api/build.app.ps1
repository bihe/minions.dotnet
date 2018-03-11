echo "Clean solution"

dotnet clean -c Debug
dotnet clean -c Release

dotnet build -c Release 

Remove-Item -Recurse -Force "$pwd\..\docker\dist"

dotnet publish .\api.csproj -c Release -v m -o "$pwd\..\docker\dist"