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

build_and_load_image "HouseApp.Backend.API" "api"
build_and_load_image "HouseApp.Backend.JobRunner" "jobrunner"
build_and_load_image "HouseApp.Frontend.UI" "ui"

sudo docker image prune -f

minikube kubectl -- apply -f Deployment/Kubernetes/Environment/Config.yaml
minikube kubectl -- apply -f Deployment/Kubernetes/Environment/Ingress-Deployment-Local.yaml
minikube kubectl -- apply -f Deployment/Kubernetes/HouseApps
minikube kubectl -- apply -f Deployment/Kubernetes/External