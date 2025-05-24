# Kiến Trúc Microservice với Gateway, Authentication và Email Service

## 1. Component Diagram

```mermaid
graph TB
    Client[Client Application]
    Gateway[Gateway Service<br/>YARP Reverse Proxy<br/>Port: 5000]
    Auth[Authentication Service<br/>Port: 5001]
    Email[Email Service<br/>Port: 5002]
    Kafka[Kafka Message Broker]
    DB1[(Auth Database)]

    Client -->|HTTP Requests| Gateway
    Gateway -->|/api/auth/*| Auth
    Gateway -->|/api/email/*| Email
    Auth -->|Publish Events| Kafka
    Kafka -->|Consume Events| Email
    Auth -->|CRUD| DB1
    Email -->|Send Email| SMTP

    style Client fill:#f9f,stroke:#333,stroke-width:2px
    style Gateway fill:#bbf,stroke:#333,stroke-width:2px
    style Auth fill:#bfb,stroke:#333,stroke-width:2px
    style Email fill:#bfb,stroke:#333,stroke-width:2px
    style Kafka fill:#fbb,stroke:#333,stroke-width:2px
    style DB1 fill:#ddd,stroke:#333,stroke-width:2px
```

## 2. Sequence Diagram - User Registration Flow

```mermaid
sequenceDiagram
    participant Client
    participant Gateway
    participant Auth
    participant Kafka
    participant Email
    participant DB1

    Client->>Gateway: POST /api/auth/register
    Gateway->>Auth: Forward Request
    Auth->>DB1: Save User
    Auth->>Kafka: Publish UserRegistered Event
    Auth-->>Gateway: Return Success
    Gateway-->>Client: Return Response
    Kafka->>Email: Consume UserRegistered Event
    Email->>Email: Send Welcome Email
```

## 3. Data Flow Diagram

```mermaid
flowchart LR
    subgraph Client Layer
        C[Client]
    end

    subgraph Gateway Layer
        G[YARP Gateway]
    end

    subgraph Service Layer
        A[Auth Service]
        E[Email Service]
    end

    subgraph Message Layer
        K[Kafka]
    end

    subgraph Data Layer
        D1[(Auth DB)]
    end

    C -->|HTTP| G
    G -->|/api/auth/*| A
    G -->|/api/email/*| E
    A -->|Events| K
    K -->|Events| E
    A -->|CRUD| D1
    E -->|Send| SMTP
```

## 4. Deployment Diagram

```mermaid
graph TB
    subgraph Development Environment
        G[Gateway Service<br/>localhost:5000]
        A[Auth Service<br/>localhost:5001]
        E[Email Service<br/>localhost:5002]
        K[Kafka<br/>localhost:9092]
    end

    subgraph Production Environment
        G2[Gateway Service<br/>Load Balancer]
        A2[Auth Service<br/>Multiple Instances]
        E2[Email Service<br/>Multiple Instances]
        K2[Kafka Cluster]
    end

    style G fill:#bbf,stroke:#333,stroke-width:2px
    style A fill:#bfb,stroke:#333,stroke-width:2px
    style E fill:#bfb,stroke:#333,stroke-width:2px
    style K fill:#fbb,stroke:#333,stroke-width:2px
    style G2 fill:#bbf,stroke:#333,stroke-width:2px
    style A2 fill:#bfb,stroke:#333,stroke-width:2px
    style E2 fill:#bfb,stroke:#333,stroke-width:2px
    style K2 fill:#fbb,stroke:#333,stroke-width:2px
```

## 5. API Gateway Routes

```mermaid
graph LR
    G[Gateway<br/>:5000]
    A[Auth Service<br/>:5001]
    E[Email Service<br/>:5002]

    G -->|/api/auth/register| A
    G -->|/api/auth/login| A
    G -->|/api/email/send| E

    style G fill:#bbf,stroke:#333,stroke-width:2px
    style A fill:#bfb,stroke:#333,stroke-width:2px
    style E fill:#bfb,stroke:#333,stroke-width:2px
```

## 6. Event Flow Diagram

```mermaid
stateDiagram-v2
    [*] --> UserRegistration
    UserRegistration --> AuthService
    AuthService --> SaveToDatabase
    SaveToDatabase --> PublishEvent
    PublishEvent --> Kafka
    Kafka --> EmailService
    EmailService --> SendWelcomeEmail
    SendWelcomeEmail --> [*]

    state UserRegistration {
        [*] --> ValidateInput
        ValidateInput --> CheckExisting
        CheckExisting --> CreateUser
        CreateUser --> [*]
    }

    state EmailService {
        [*] --> ConsumeEvent
        ConsumeEvent --> PrepareEmail
        PrepareEmail --> SendEmail
        SendEmail --> [*]
    }
```

## 7. Scaling Strategy

```mermaid
graph TB
    subgraph Load Balancer
        LB[HAProxy/Nginx]
    end

    subgraph Gateway Layer
        G1[Gateway 1]
        G2[Gateway 2]
        G3[Gateway 3]
    end

    subgraph Service Layer
        A1[Auth 1]
        A2[Auth 2]
        E1[Email 1]
        E2[Email 2]
    end

    subgraph Message Layer
        K1[Kafka 1]
        K2[Kafka 2]
        K3[Kafka 3]
    end

    LB --> G1
    LB --> G2
    LB --> G3
    G1 --> A1
    G1 --> A2
    G2 --> E1
    G2 --> E2
    A1 --> K1
    A2 --> K2
    E1 --> K3
    E2 --> K1

    style LB fill:#f9f,stroke:#333,stroke-width:2px
    style G1 fill:#bbf,stroke:#333,stroke-width:2px
    style G2 fill:#bbf,stroke:#333,stroke-width:2px
    style G3 fill:#bbf,stroke:#333,stroke-width:2px
    style A1 fill:#bfb,stroke:#333,stroke-width:2px
    style A2 fill:#bfb,stroke:#333,stroke-width:2px
    style E1 fill:#bfb,stroke:#333,stroke-width:2px
    style E2 fill:#bfb,stroke:#333,stroke-width:2px
    style K1 fill:#fbb,stroke:#333,stroke-width:2px
    style K2 fill:#fbb,stroke:#333,stroke-width:2px
    style K3 fill:#fbb,stroke:#333,stroke-width:2px
``` 