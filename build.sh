#!/usr/bin/env bash

set -ex

username=$(cat /etc/docker-registry/username)
password=$(cat /etc/docker-registry/password)
endpoint=$(cat /etc/docker-registry/endpoint)

sudo docker login -u $username -p $password $endpoint

TAG=$SERVICE-$BRANCH_NAME-$BUILD_NUMBER

sudo docker build -t $TEAM:$TAG .
sudo docker tag $TEAM:$TAG $ECR_HOST/$TEAM:$TAG
sudo docker push $ECR_HOST/cloud-native-$TEAM:$TAG
