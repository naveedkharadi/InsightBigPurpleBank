# Insight Big Purple Bank

The solution consists of the following 4 projects.

 1. InsightBigPurpleBank.Api
 2. InsightBigPurpleBank.ApiTests
 3. InsightBigPurpleBank.Domain
 4. InsightBigPurpleBank.Infrastructure

All the projects are built on .NET 6.0.

### 1. InsightBigPurpleBank.Api

This is an Asp.Net Core MVC project that contains the API endpoint controllers and HTTP middleware/pipeline setup.

There is only one controller having one endpoint "GetProducts".

### 2. InsightBigPurpleBank.ApiTests

This project contains unit tests for the solution. Currently, there tests only for GetProducts endpoint.

### 3. InsightBigPurpleBank.Domain

This project contains domain entities, enums and repository interfaces.

### 4. InsightBigPurpleBank.Infrastructure

This project contains imlpementation for repositories. Currently, the repository returns hardcoded data; however, it can easily be modified to integrate with relevant data sources.


## Application Architecture

![image](https://user-images.githubusercontent.com/14067309/170437654-c1c68208-2023-44ac-b559-6f28fd762a85.png)

### API Layer
API layer will work with interfaces defined in the Application Core at compile time and wouldn’t know about the concrete implementation types defined in the infrastructure layer. The implementation types would be wired up to the Application Core interfaces via dependency injection.

### Infrastructure Layer
This layer would implement infrastructure layer Repositories and Services. Database / backend integration would be wired up here.

### Application Core Layer
Application Core doesn’t have any dependencies on other layers and will contain the application’s Domain model and repository interfaces are at the center. Both API and the infrastructure layers depend on the Application Core.

### Tests Layer
Application Core and API layers would be unit tested. ‘dotnet test’ and MS Unit would be used for unit testing.

