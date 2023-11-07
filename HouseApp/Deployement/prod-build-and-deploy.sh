#!/bin/bash
mkdir -p Deployment/Kubernetes/images
sudo microk8s kubectl delete deployment --all

docker build -f HouseApp.Backend.FormulaOne/Dockerfile -t madworld/houseapp/formulaone .
docker save madworld/houseapp/formulaone > Deployment/Kubernetes/images/madworld-houseapp-formulaone.tar
sudo microk8s.ctr -n k8s.io image import Deployment/Kubernetes/images/madworld-houseapp-formulaone.tar
echo "FormulaOne image loaded"

docker build -f HouseApp.Backend.Weather/Dockerfile -t madworld/houseapp/weather .
docker save madworld/houseapp/formulaone > Deployment/Kubernetes/images/madworld-houseapp-weather.tar
sudo microk8s.ctr -n k8s.io image import Deployment/Kubernetes/images/madworld-houseapp-weather.tar
echo "Weather image loaded"

docker build -f HouseApp.Backend.Light/Dockerfile -t madworld/houseapp/light .
docker save madworld/houseapp/formulaone > Deployment/Kubernetes/images/madworld-houseapp-light.tar
sudo microk8s.ctr -n k8s.io image import Deployment/Kubernetes/images/madworld-houseapp-light.tar
echo "Light image loaded"

docker build -f HouseApp.Frontend.UI/Dockerfile -t madworld/houseapp/ui .
docker save madworld/houseapp/formulaone > Deployment/Kubernetes/images/madworld-houseapp-ui.tar
sudo microk8s.ctr -n k8s.io image import Deployment/Kubernetes/images/madworld-houseapp-ui.tar
echo "UI image loaded"

sudo microk8s kubectl -- apply -f Deployement/Kubernetes

sudo rm -r Deployment/Kubernetes/images