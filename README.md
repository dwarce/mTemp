









 <div align="center">      
  <h1>mTEMP</h1>      
</div>      


- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
- [Run](#run)


<table>      
<tr>      
This repository contains a full-stack demo temperature monitoring application with:

- **Backend API**: Built with .NET Core 8 (`mTemp-API` folder)
- **Frontend App**: Built with Vue 3 + TypeScript + PrimeVue (`mtemp-webapp` folder)</tr>      
</table>      
The frontend communicates with the backend API to manage temperature measurements.




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

- **Vite** — A modern, fast build tool for Vue.js projects.
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

