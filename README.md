
<div align="center">      
  <h1>mTEMP</h1>      
</div>      

<table>      
<tr>      
This repository contains a full-stack demo temperature monitoring application with:

- **Backend API**: Built with .NET Core 8 (`mTemp-API` folder)
- **Frontend App**: Built with Vue 3 + TypeScript + PrimeVue (`mtemp-webapp` folder)</tr>      
</table>      
The frontend communicates with the backend API to manage temperature measurements.




- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
- [Run](#run)
- [Application description](#application-description)





## Prerequisites

Before running the projects, make sure you have the following installed:

### Backend (mTemp-API):
- **.NET Core 8** (or later) — Make sure the .NET SDK is installed:
  - Download from the official [Microsoft website](https://dotnet.microsoft.com/download/dotnet).

### Frontend (mtemp-webapp):
- **Node.js v18.x (LTS)** — Recommended version for compatibility with the Vue.js frontend.
  - Install using [nvm](https://github.com/nvm-sh/nvm) (Node Version Manager) to manage multiple Node.js versions:
    ```bash
    nvm install 18
    nvm use 18
    ```

- **npm v10.x** — Node.js package manager, which comes with Node.js 18.x by default.
  - You can check the npm version using:
    ```bash
    npm -v
    ```

- **Optional: Vite** — A modern, fast build tool for Vue.js projects.
  - Install globally with npm:
    ```bash
    npm install -g create-vite
    ```

- **Visual Studio Code (VS Code)** or **Visual Studio**:
  - It's recommended to use VS Code or Visual Studio for development:
    - **VS Code**: [Download VS Code](https://code.visualstudio.com/)
    - **Visual Studio**: [Download Visual Studio](https://visualstudio.microsoft.com/)




## Setup Instructions

### 1. Clone the repository

### 2. Backend Setup (mTemp-API)

1.  Open the `mTemp-API` folder in Visual Studio.
    
2.  Restore dependencies and build the project:
    
    -   Open **Terminal** in Visual Studio and use the commands:
    ```bash
    dotnet restore
    dotnet build
    ```
        
3.  Run the backend API:
    
    -   Start the API using Visual Studio, or run it via the terminal:
      ```bash
    dotnet run
    ```
    -   The API should now be running at `http://localhost:5007`.

### 3. Frontend Setup (mtemp-webapp)

1.  Navigate to the `mtemp-webapp` folder with your terminal
     ```bash
    cd mtemp-webapp
    ```
    
2.  Install Node.js dependencies:
    ```bash
    npm install
    ```    
3.  Start the frontend development server using Vite:
    
    ```bash
    npm run dev
    ```   
    
    -   This will start the Vue.js app and typically run at `http://localhost:5173/`.

#### Running Unit-tests
1.  Open the `mTemp-API` or `mTemp-API.Test` folder in Visual Studio.
    
2.  Run tests:
    
    -   Open **Terminal** in Visual Studio and use the commands:
    ```bash
    dotnet test
    ```
    - Results will display at the bottom of input

## Application description

### Backend
The mTemp-API project provides REST endpoints to handle requests and manage temperature measurements and patient data.
Database is implemented as in-memory database, all database table representations are implemented as arrays.

1. Folder structure:
  - Adapters
    - Controllers (contains REST endpoints that use domain services)
    - DTO (contains DTO classes which are used for data communication between backend and frontend)
    - Middleware (contains ExceptionHandlingMiddleware, that handles all exceptions thrown by API and specifies what data is written to response in case of exception)
    - Util (contains util services that provide static methods, such as: converting domain models to DTOs, time value converters)
  - Domain
    - Exceptions (contains all Exception classes that are used in the domain services)
    - Models (contains all domain data classes - database table representations)
    - Repositories (contains the interfaces of the data persistence logic with implementations of in-memory database)
    - Services (contains all domain services that hold domain logic and are used by REST controllers. services use repositories to fetch and write data. These services also do domain data validation)


### Frontend
The mtemp-webapp provides a vue web application that uses REST services, exposed by mTemp-API.