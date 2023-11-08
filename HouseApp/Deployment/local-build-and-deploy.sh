#!/bin/bash
kubectl delete deployment --all

docker build -f HouseApp.Backend.FormulaOne/Dockerfile -t madworld/houseapp/formulaone .
minikube image load --overwrite madworld/houseapp/formulaone
echo "FormulaOne image loaded"

docker build -f HouseApp.Backend.Weather/Dockerfile -t madworld/houseapp/weather .
minikube image load --overwrite madworld/houseapp/weather 
echo "Weather image loaded"

docker build -f HouseApp.Backend.Light/Dockerfile -t madworld/houseapp/light .
minikube image load --overwrite madworld/houseapp/light
echo "Light image loaded"

docker build -f HouseApp.Frontend.UI/Dockerfile -t madworld/houseapp/ui .
minikube image load --overwrite madworld/houseapp/ui
echo "UI image loaded"

minikube kubectl -- apply -f Deployement/Kubernetes