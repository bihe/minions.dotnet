#!/bin/bash

docker run -d -p 3000:3000 \
-e "ASPNETCORE_ENVIRONMENT=Production" \
-e "APP_NAME=one-eyed-minion" \
-e "APP_VERSION=0.1" \
minions