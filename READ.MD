 # This project is a simple study to undestand basic of consumers and publishers .


To run this project you need have Docker installed

## Installing RABBIT MQ 
- You can access the docker hub [RabbitMQ-DockerHub](https://hub.docker.com/_/rabbitmq/)
 or just run the following code in your terminal to got a container image of RabbitMQ 
 ```
 docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672  -p 15672:15672 -e RABBITMQ_DEFAULT_USER=usuario -e RABBITMQ_DEFAULT_PASS=Senha@123 rabbitmq:3-management
 ```

