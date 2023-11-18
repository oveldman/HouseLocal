#!/bin/bash
build_and_load_image () {
  docker build -f $1/Dockerfile -t madworld/houseapp/$2 .
  docker save madworld/houseapp/$2 > Deployment/Kubernetes/images/madworld-houseapp-$2.tar
  sudo microk8s images import < Deployment/Kubernetes/images/madworld-houseapp-$2.tar
  echo "$2 image loaded"
}

#This removes the error of nginx image not found while building the image
sudo docker pull nginx

mkdir -p Deployment/Kubernetes/images
sudo microk8s kubectl delete deployment,pods --all -n houseapp
sudo microk8s kubectl delete deployment,pods --all -n default

build_and_load_image "HouseApp.Backend.API" "api"
build_and_load_image "HouseApp.Backend.JobRunner" "jobrunner"
build_and_load_image "HouseApp.Frontend.UI" "ui"

sudo docker image prune -f

sudo microk8s kubectl apply -f Deployment/Kubernetes/Environment/Config.yaml
sudo microk8s kubectl apply -f Deployment/Kubernetes/Environment/Ingress-Deployment-Prod.yaml
sudo microk8s kubectl apply -f Deployment/Kubernetes/HouseApps
sudo microk8s kubectl apply -f Deployment/Kubernetes/External

sudo rm -r Deployment/Kubernetes/images