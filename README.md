# Todo Sample Application

This repo tree contains a sample app illustrating the use of some of the Steeltoe components together in a ASP.NET Core application. 

Following are the main components in this app :

* Config server - acting as registry for config.
* Eureka server - for service discovery.
* MySql server - for storing Todo inventory.
* Web frontend - Todo UI 
* Web Backend - RESTful Service exposing interface to get Todo Data. Taking with MySql on the backend.   

This application makes use of the following Steeltoe components:

* Spring Cloud Config Server Client for centralized application configuration
* Spring Cloud Eureka Server Client for service discovery
* Steeltoe Connector for connecting to MySql using EFCore

# Getting Started

* Clone the Samples repo. (i.e.  git clone https://github.com/harshal-j/TodoApp)

# Using Docker compose

1. 'docker compose up' - To start all the services in docker compose.
2. 'docker compose down -v' - To tear down all the resources. 
