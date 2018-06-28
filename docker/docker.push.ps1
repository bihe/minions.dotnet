. .\_environment.ps1

docker tag minions $env:DOCKER_ID_USER/minions-dotnet
docker push $env:DOCKER_ID_USER/minions-dotnet