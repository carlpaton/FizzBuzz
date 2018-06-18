#!/bin/bash
docker pull carlpaton/fizzbuzz
sudo docker container kill fizzbuzz
sudo docker rm fizzbuzz

sudo docker run --env-file=env_file_name.env -d -p 81:80 --name fizzbuzz carlpaton/fizzbuzz

sudo docker start fizzbuzz
sudo docker ps --all