#!/bin/bash
kubectl delete deployment --all

docker build -f HouseApp.Backend.Weather/Dockerfile -t madworld/houseapp/weather .
minikube image load --overwrite madworld/houseapp/weather 
echo "Weather image loaded"

docker build -f HouseApp.Backend.Light/Dockerfile -t madworld/houseapp/light .
minikube image load --overwrite madworld/houseapp/light
echo "Light image loaded"

minikube kubectl -- apply -f Deployement/Kubernetes