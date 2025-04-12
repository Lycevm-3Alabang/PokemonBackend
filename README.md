# PokemonBackend
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
WebAPI -->|config = 'EFCore'| EFCoreRepo
WebAPI -->|config = 'List'| ListRepo
