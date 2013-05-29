# F'n Easy Eventing

The goal of this project is to provide a simple API for real-time eventing between any number of clients. Using SinalR for communication, events can easily be dispatched to any number of clients, both .NET and JavaScript.

###How It Works

Events are dispatched between clients via an event brokerage server which by default is a self-hosted SignalR hub. The server can be hosted in a console application or Windows service.