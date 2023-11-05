#!/bin/bash
docker build -f HouseApp.Backend.Weather/Dockerfile -t madworld/houseapp/weather .
minikube image load madworld/houseapp/weather:lastest