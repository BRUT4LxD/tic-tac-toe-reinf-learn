# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

##`REST communication`
server url : http://185.243.54.57
Endpoints
- sent GET request `/start` to start new game or reset the current game (if it will be first request after starting the server, it can take a while) 
- sent POST request `/move` with request body (body should contain position chosen by player - field number in the range from 1 to 9) as a response you should receive current game board
    - example request body - {"position":5}
    - example response body - {"board":"X 00X   X"}

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://www.visualstudio.com/en-us/docs/git/create-a-readme). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)