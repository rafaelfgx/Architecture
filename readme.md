# ARCHITECTURE

![](https://github.com/rafaelfgx/Architecture/actions/workflows/build.yaml/badge.svg)

This project is an example of architecture using new technologies and best practices.

The goal is to learn and share knowledge and use it as reference for new projects.

## PRINCIPLES and PATTERNS

* Clean Architecture
* Clean Code
* SOLID Principles
* KISS Principle
* DRY Principle
* Fail Fast Principle
* Common Closure Principle
* Common Reuse Principle
* Acyclic Dependencies Principle
* Mediator Pattern
* Result Pattern
* Folder-by-Feature Structure
* Separation of Concerns

## BENEFITS

* Simple and evolutionary architecture.
* Standardized and centralized flow for validation, log, security, return, etc.
* Avoid cyclical references.
* Avoid unnecessary dependency injection.
* Segregation by feature instead of technical type.
* Single responsibility for each request and response.
* Simplicity of unit testing.

## TECHNOLOGIES

* [.NET](https://dotnet.microsoft.com/download)
* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp)
* [Angular](https://angular.io/docs)
* [UIkit](https://getuikit.com/docs/introduction)

## RUN

<details>
<summary>Command Line</summary>

#### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download/dotnet)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)
* [Node](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps

1. Open directory **source\Web\Frontend** in command line and execute **npm i**.
2. Open directory **source\Web** in command line and execute **dotnet run**.
3. Open <https://localhost:8090>.

</details>

<details>
<summary>Visual Studio Code</summary>

#### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download/dotnet)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)
* [Node](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)
* [Visual Studio Code](https://code.visualstudio.com)
* [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

#### Steps

1. Open directory **source\Web\Frontend** in command line and execute **npm i**.
2. Open **source** directory in Visual Studio Code.
3. Press **F5**.

</details>

<details>
<summary>Visual Studio</summary>

#### Prerequisites

* [Visual Studio](https://visualstudio.microsoft.com)
* [Node](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps

1. Open directory **source\Web\Frontend** in command line and execute **npm i**.
2. Open **source\Architecture.sln** in Visual Studio.
3. Set **Architecture.Web** as startup project.
4. Press **F5**.

</details>

<details>
<summary>Docker</summary>

#### Prerequisites

* [Docker](https://www.docker.com/get-started)

#### Steps

1. Execute **docker compose up --build -d** in docker directory.
2. Open <http://localhost:8090>.

</details>

## PACKAGES

**Source:** [https://github.com/rafaelfgx/DotNetCore](https://github.com/rafaelfgx/DotNetCore)

**Published:** [https://www.nuget.org/profiles/rafaelfgx](https://www.nuget.org/profiles/rafaelfgx)

## LAYERS

**Web:** Frontend and Backend.

**Application:** Flow control.

**Domain:** Business rules and domain logic.

**Model:** Data transfer objects.

**Database:** Data persistence.

## WEB

### FRONTEND

### Service

It is the interface between frontend and backend and has logic that does not belong in components.

### Guard

It validates if a route can be activated.

### ErrorHandler

It provides a hook for centralized exception handling.

### HttpInterceptor

It intercepts and handles an HttpRequest or HttpResponse.

### BACKEND

### Controller

It has no any logic, business rules or dependencies other than mediator.

## APPLICATION

It has only business flow, not business rules.

### Request

It has properties representing the request.

### Request Validator

It has rules for validating the request.

### Response

It has properties representing the response.

### Handler

It is responsible for the business flow and processing a request to return a response.

It call factories, repositories, unit of work, services or mediator, but it has no business rules.

### Factory

It creates a complex object.

Any change to object affects compile time rather than runtime.

## DOMAIN

It has no any references to any layer.

It has aggregates, entities, value objects and services.

### Aggregate

It defines a consistency boundary around one or more entities.

The purpose is to model transactional invariants.

One entity in an aggregate is the root, any other entities in the aggregate are children of the root.

### Entity

It has unique identity. Identity may span multiple bounded contexts and may endure beyond the lifetime.

Changing properties is only allowed through internal business methods in the entity, not through direct access to the properties.

### Value Object

It has no identity and it is immutable.

It is defined only by the values ​​of its properties.

To update a value object, you must create a new instance to replace the old one.

It can have methods that encapsulate domain logic, but these methods must have no side effects on the state.

### Services

It performs domain operations and business rules.

It is stateless and has no operations that are not a part of an entity or value object.

## MODEL

It has properties to transport and return data.

## DATABASE

It encapsulates data persistence.

### Context

It configures the connection and represents the database.

### Entity Configuration

It configures the entity and its properties in the database.

### Repository

It inherits from the generic repository and only implements specific methods.