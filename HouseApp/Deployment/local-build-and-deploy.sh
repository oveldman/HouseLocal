#!/bin/bash
build_and_load_image () {
  sudo minikube image rm docker.io/madworld/houseapp/$2
  sudo docker build -f $1/Dockerfile -t madworld/houseapp/$2 .
  sudo minikube image load --overwrite madworld/houseapp/$2
  echo "$2 image loaded"
}

#This removes the error of nginx image not found while building the image
sudo docker pull nginx

sudo kubectl delete deployment,pods --all -n houseapp
sudo kubectl delete deployment,pods --all -n default

build_and_load_image "HouseApp.Backend.FormulaOne" "formulaone"
build_and_load_image "HouseApp.Backend.Weather" "weather"
build_and_load_image "HouseApp.Backend.Light" "light"
build_and_load_image "HouseApp.Frontend.UI" "ui"

minikube kubectl -- apply -f Deployment/Kubernetes/Environment/Config.yaml
minikube kubectl -- apply -f Deployment/Kubernetes/Environment/Ingress-Deployment-Local.yaml
minikube kubectl -- apply -f Deployment/Kubernetes/HouseApps
minikube kubectl -- apply -f Deployment/Kubernetes/External