# CIS 355 Lab 2 

## Getting Started

### Initial Setup
1. Open Visual Studio Code
2. Open Docker
3. Open Postman

## Using GitHub
1. Clone the repository from github, if you need it. (If not open, folder with code)

## Visual Studio Code Dev Container Connection
1.  On the bottom left of the Visual Code screen, click on the green square to then connect to the dev container.

## Opening Docker
1. Open Docker to make sure dev containers are running.


## Postman
1. Connect to the database
2. send a post user request
3. Make sure you can recieve the request as a Status Code 200 OK, if not troubleshoot.


## Visual Studio Code Dev Container Connection
1. On the bottom left of the Visual Code screen, click on the green square to then connect to the dev container.

### Database Configuration
1. **Restore Dotnet Tools**: 
   Run `dotnet tools restore` in the terminal to install the Entity Framework (EF) CLI, necessary for applying EF migrations.

2. **Apply Database Migrations**: 
   Use `dotnet ef update` to apply all EF migrations and create the database if it doesn't exist.

### Running the Application
After setting up the database, start the application using `dotnet run` or through your IDE. It will automatically create a default admin account.

See the "Default Admin Account" section for more information on using this account.

## Default Admin Account

### Overview
A default admin account is created automatically on the first startup in a development environment. It's designed for immediate access to administrative features.

### Account Details
- **Username**: `postgres`
- **Email**: `admin@admin.com`
- **Password**: `password`
- **Role**: `postgres`

### Usage
Use this account to sign in and access administrative areas. It's fully enabled for all features and settings, ideal for setup and testing.

### Troubleshooting
If you can't access the application with the admin account, check if the database has been seeded correctly and look for any startup errors in the application logs.
