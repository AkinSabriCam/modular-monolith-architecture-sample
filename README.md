# Modular Monolith Architecture Sample

This repository is a basic sample to describe modular monolith architecture. This sample is built by the three modules.
### Modules
		
- **Reservation**: This module has the responsibility to manage all reservations and other related domains in the same bounded context.
-  **Profile**: This module has the responsibility to manage all profiles and other related domains in the same bounded context.
-  **Folio**: This module has the responsibility to manage all folio and other related domains in the same bounded context.

> **Note**: Folio is an entity which includes the profile's charge balance.

# How To Run The Project

 - [x] go to under the Sample folder and run this command
        `docker build -t sampleapiimage .`
    
 - [x] run this command in the same root
      `docker-compose up`

then you can go to the this address "http://localhost:3452/swagger/index.html"

![SampleApi](https://github.com/AkinSabriCam/modular-monolith-architecture-sample/blob/main/pics/SampleApi.png)

## Deep To The Project

#### What Are The Responsibilities Of Each Layer In The Module?

 - **Domain Layer**: This layer must keep the domain and domain logic inside. It describes the domain rules and interfaces which affect the domain directly.

  - **Application Layer**: This layer actaully includes application logic inside. The layer use the domain logic and it performs use cases.

  - **Application.Contract Layer**: This layer is an interface of the use cases which we use in the system. This layer also includes the interface of the integration service to reach other modules use cases also includes a contract to present some use cases to other modules.

  - **Infrastructure Layer**: This layer is a place which we define all configurations which belong to the module. This layer includes all registration of interfaces inside. If we have an interface that includes a third party includes we keep the concrete class of that interface in Infrastructure.

  - **Infrastructure.Shared Layer**: This layer has the autofac container provider inside. We use a single container per module that's why we use a provider which presents that container in that layer.

  - **Integration.OtherModule Layer**: A module might need data from another module sometimes. In this situation, we can use an integration project to present these use cases for other modules' use.
  
  #### Let's Look At The Diagram To Understand The Architecture.
  ![Modular-Monolith](https://github.com/AkinSabriCam/modular-monolith-architecture-sample/blob/main/pics/Modular-Monolith.png)
