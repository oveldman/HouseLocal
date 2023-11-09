#!/bin/bash

build_and_load_image () {
   sudo docker build -f $1/Dockerfile -t madworld/houseapp/$2 .
   sudo minikube image load --overwrite madworld/houseapp/$2
   echo "$2 image loaded"
}

kubectl delete deployment --all

build_and_load_image "HouseApp.Backend.FormulaOne" "formulaone"
build_and_load_image "HouseApp.Backend.Weather" "weather"
build_and_load_image "HouseApp.Backend.Light" "light"
build_and_load_image "HouseApp.Frontend.UI" "ui"

minikube kubectl -- apply -f Deployment/Kubernetes/Environment/Ingress-Deployment-Local.yaml
minikube kubectl -- apply -f Deployment/Kubernetes