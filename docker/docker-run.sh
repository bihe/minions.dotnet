#!/bin/bash

docker run -d -p 3000:3000 \
-e "ASPNETCORE_ENVIRONMENT=Production"
minions