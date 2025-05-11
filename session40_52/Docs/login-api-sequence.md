# Login API Sequence Diagram

## Overview
This document describes the sequence of operations when a user attempts to log in to the system.

## Sequence Diagram

```mermaid
sequenceDiagram
    participant Client
    participant AuthController
    participant UserService
    participant UserRepository
    participant Database
    participant JWT

    %% Login Flow
    Client->>AuthController: POST /api/auth/login
    Note over Client,AuthController: Request body: {email, password}
    
    AuthController->>UserService: LoginAsync(loginRequest)
    
    UserService->>UserRepository: LoginAsync(loginRequest)
    
    UserRepository->>Database: FirstOrDefaultAsync(u => u.Email == request.Email)
    Database-->>UserRepository: User or null
    
    alt User not found
        UserRepository-->>UserService: Throw Exception("User not found")
        UserService-->>AuthController: Throw Exception
        AuthController-->>Client: 400 Bad Request
    else User found
        UserRepository->>UserRepository: Verify password with BCrypt
        alt Password incorrect
            UserRepository-->>UserService: Throw Exception("Invalid password")
            UserService-->>AuthController: Throw Exception
            AuthController-->>Client: 400 Bad Request
        else Password correct
            alt Email not verified
                UserRepository-->>UserService: Throw Exception("Email not verified")
                UserService-->>AuthController: Throw Exception
                AuthController-->>Client: 400 Bad Request
            else Email verified
                UserRepository-->>UserService: Return User
                UserService->>JWT: GenerateJwtToken(user)
                JWT-->>UserService: JWT token
                UserService-->>AuthController: Return token
                AuthController-->>Client: 200 OK {token}
            end
        end
    end
```

## Flow Explanation

1. **Client Request**:
   - Client sends a POST request to `/api/auth/login`
   - Request body contains email and password

2. **Controller Layer**:
   - `AuthController` receives the request
   - Calls `UserService.LoginAsync()`

3. **Service Layer**:
   - `UserService` calls `UserRepository.LoginAsync()`
   - If login successful, generates JWT token
   - Returns token to controller

4. **Repository Layer**:
   - `UserRepository` performs database operations
   - Finds user by email
   - Verifies password with BCrypt
   - Checks email verification status
   - Returns user if all checks pass

5. **Database**:
   - Executes query to find user by email
   - Returns user or null

6. **JWT Generation**:
   - Creates claims from user information
   - Signs token with secret key
   - Returns JWT token

7. **Response**:
   - Success (200 OK): Returns JWT token
   - Error (400 Bad Request): Returns error message

## Error Cases

1. **User Not Found**:
   ```json
   {
       "message": "User not found"
   }
   ```

2. **Invalid Password**:
   ```json
   {
       "message": "Invalid password"
   }
   ```

3. **Email Not Verified**:
   ```json
   {
       "message": "Email not verified"
   }
   ```

## Security Features

1. **Password Security**:
   - Passwords are hashed using BCrypt
   - Salt is automatically generated and stored with the hash

2. **Token Security**:
   - JWT tokens are signed with a secret key
   - Tokens expire after 1 hour
   - Tokens contain minimal necessary user information

3. **Email Verification**:
   - Email verification is required before login
   - Prevents unauthorized access

4. **Error Handling**:
   - Clear error messages for different failure cases
   - No sensitive information is exposed in error responses 