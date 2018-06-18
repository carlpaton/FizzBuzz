#!/bin/bash
docker pull carlpaton/fizzbuzz:v1.0.0
sudo docker container kill fizzbuzz
sudo docker rm fizzbuzz

sudo docker run --env-file=env_file_name.env -d --name fizzbuzz carlpaton/fizzbuzz:v1.0.0

sudo docker start fizzbuzz
sudo docker ps --all