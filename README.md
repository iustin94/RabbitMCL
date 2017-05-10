
# RabbitMQ-WebApi-Wrapper
HTTP API wrapper library for RabbitMQ's management plugin done for C#.

This is a small library that I made to wrap the HTTP api funcitonality of RabbitMQ's server in version 3.6.6.

# THE LIBRARI CURRENTLY HANDELS ONLY THE "GET" API CALLS. NOTHING MORE.

I used this library to retrieve information about the actual rabbitmq server/cluster status since I did not find any way to do it from the
RabbitMQ.Client library.

The library api consists of several classes, each class representing on API domain from the rabbitmq api. 

ex:

/api/bindings => Bindings.cs
/api/users => Users.cs

Some api calls that I did not see to be grouped up might be in the miscelaneous calls.

You can see the api use in the test Program.cs. 

The model object returned by each model maps the json response form rabbitmq so everything is in the response object.
