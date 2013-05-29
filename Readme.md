# F'n Easy Eventing

The goal of this project is to provide a simple API for real-time eventing between any number of clients. Using SinalR for communication, events can easily be dispatched to any number of clients, both .NET and JavaScript.

###How It Works

Events are dispatched between clients via an event brokerage server which by default is a self-hosted SignalR hub. The server can be hosted in a console application or Windows service. Clients then connect to the server and subscribe to named events. All handlers are specific to the client, the server has no knowledge of the actual method that will be invoked or the message being dispatched. It simply provides all clients who have subsribed to the event the message and the appropriate handler is executed by each client.

###The Server

// TODO: add server example

###.NET Clients

// TODO: add .net client example

###JavaScript Clients

// TODO: add javascript client example