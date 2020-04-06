

[![License](http://img.shields.io/badge/Licence-MIT-brightgreen.svg)](LICENSE.md)

# Introduction

microservices architecture with API gateway applications.

Currently runs with:

- dotnet v3.1.102
- ocelot v14.1.0

With this sample, you can :

- Run your app in a local development environment 
- Run your app in a production environment
- Package your app into an executable file for Linux, Windows & Mac

## Getting Started

Clone this repository locally :

``` bash
git@github.com:rud9321/microservices-core.git
```

Install dependencies with nuget :

``` bash
dotnet restore
```



Ocelot is aimed at people using .NET running a micro services / service orientated architecture that need a unified point of entry into their system. , you **MUST** install `Install-Package Ocelot` from nuget.
Please follow [Ocelot documentation](https://ocelot.readthedocs.io/en/latest/introduction/bigpicture.html) 

``` bash
dotnet add package ocelot
```



## Included Commands

|Command|Description|
|--|--|
|`https://localhost:5782/user`| Execute the user API(service) |
|`https://localhost:5882/student`| Execure the student API(service) |
|`https://localhost:5001/everything`| Execute your api gateway |


## Branch & Packages version


microservices-core: [(master)](https://github.com/rud9321/microservices-core/tree/master)


