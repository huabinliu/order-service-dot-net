#!/usr/bin/env bash

set -ex

TAG=$SERVICE-$BRANCH_NAME-$BUILD_NUMBER

sudo docker build -t $TEAM:$TAG .
sudo docker tag $TEAM:$TAG $ECR_HOST/$TEAM:$TAG
sudo docker push $ECR_HOST/$TEAM:$TAG
