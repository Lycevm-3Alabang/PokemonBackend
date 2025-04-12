# Architecture Overview

This project is structured into the following layers and projects:

- **Application Layer**  
  Contains the core contracts and data structures:
  - **IRepository<T>**: A generic interface that defines data access methods.
  - **DTOs**: Data Transfer Objects (e.g., `StudentDto`, `SubjectDto`, etc.) for transferring data between layers.

- **Repository Implementations**  
  Provides concrete implementations of the **IRepository<T>**:
  - **EFCoreRepository**: Implements `IRepository<T>` using Entity Framework Core.
  - **ListRepository**: Implements `IRepository<T>` using an in-memory list, suitable for lightweight scenarios or testing.
  
- **Web API**  
  The entry point of the application:
  - Exposes endpoints and interacts with the Application Layer.
  - Consumes the `IRepository<T>` and DTOs from the Application Layer.
  - The repository implementation (either **EFCoreRepository** or **ListRepository**) is injected at runtime based on configuration settings (found in `appsettings.json`).

The diagram below illustrates this architecture.

```mermaid
flowchart TD

%% Application Layer
subgraph Application_Layer [Application Layer]
    IRepository["<<interface>> IRepository<T>"]
    DTOs["DTOs (StudentDto, SubjectDto, etc.)"]
end

%% Repositories
subgraph Repository_Implementations [Repository Implementations]
    EFCoreRepo["EFCoreRepository"]
    ListRepo["ListRepository"]
end

%% Web API
subgraph Web_API [Web API]
    WebAPI["WebAPI Controller/Service"]
end

%% Relationships
EFCoreRepo -.-> IRepository
ListRepo -.-> IRepository

WebAPI --> IRepository
WebAPI --> DTOs
