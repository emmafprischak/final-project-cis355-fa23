# Tasks

## Add Installation Guide to README - 1
Create a detailed and user-friendly Installation Guide section for the CIS 355 Lab 2 README file.
### Content Requirements:
#### Software and Tools
- List all software, tools, and libraries required for the project, including links to downloads/external guides where applicable.
#### Step-by-Step Instructions
- Provide clear, sequential instructions for installing each piece of software and setting up the development environment.
#### Verification Steps
- Offer simple steps to verify that the installation was successful (e.g., running a project or checking the status of Docker).

## Document Endpoints with Summaries and Response Codes - 1
Document each API endpoint in the project with detailed summaries and associated response codes.
### Requirements
- For each endpoint in each controller, add an endpoint summary.
- For each endpoint in each controller, add all response codes either currently in use or that will be available in the future (if working with a group changing responses).
- Common codes include 200 (OK), 400 (Bad Request), 401 (Unauthorized), 404 (Not Found), and 500 (Internal Server Error).
#### Related Documentation
[Swashbuckle.AspNetCore Documentation](https://github.com/domaindrivendev/Swashbuckle.AspNetCore#include-descriptions-from-xml-comments)

## Add a New LastLoginTime Property to the User Entity Class - 2
Add a `DateTime` property named `LastLoginTime` to the User entity class. This property will store the timestamp of the user's last successful login.
### Requirements:
- Update the Login Method.
- Update Database Schema.
- Test the updated login functionality to verify that `LastLoginTime` is correctly recorded.
- Ensure that the database migration is compatible with the existing database structure.

## Implement Logging for Authentication - 2
Implement logging for the authentication process. This will allow the application to track login attempts and record the results of each attempt.
### Requirements:
- Capture Timestamp of the event.
- Capture User ID (if available).
- Capture Event type (e.g., successful login, failed login).
- Capture Details about the event (e.g., reason for login failure).

## Implement a Custom Exception Handler - 1
Implement a custom exception handler that will catch any unhandled exceptions and return a custom error message to the client.
### Requirements:
- Include Timestamp of the event.
- Include General error message.
- Implement as a middleware component.

## Add Build and Test Automation to the Project - 1
Add build and test automation to the project using GitHub Actions.
### Requirements:
- Build the project.
- Run the unit tests.
- Report the results of the build and tests.

## Enforce Password Complexity Requirements for New User Accounts - 1
Implement password complexity requirements for new user accounts.
### Requirements:
- Provide a clear and helpful error message when requirements are not met.
- Test the functionality thoroughly.

## Improved Server-Side Validation For New User Accounts - 2
Implement improved server-side validation for new user accounts.
### Requirements:
- Ensure username and email address are unique.
- Ensure password meets complexity requirements.
- Provide a clear and helpful error message when requirements are not met.

## Improve Test Coverage for the User Service - 1
Ensure that our UserService class is fully covered by unit tests.
### Requirements:
- Test Authenticate method.
- Test RegisterAsync method.

## Implement Integration Testing Using Postman - 1
Implement integration testing using Postman to test the API endpoints.
### Requirements:
- Test Login endpoint with valid and invalid credentials.
- Test Register endpoint with valid and invalid credentials.

## Implement Bulk User Import Functionality - 1
Implement bulk user import functionality.
### Requirements:
- Choose implementation method (JSON or CSV).
- Ensure user validation logic is included.

## Implement New MVP for Chat Service - 2+
Implement a chat service for members.
### Requirements:
- Ensure chat is stored in the database.
- Ensure chat is accessible to both users until deleted.
- Utilize User API service for authentication and authorization.

## Implement 2FA for User Accounts - 2
Implement 2FA for user accounts to add an extra layer of security.
### Requirements:
- Add new database columns or tables for 2FA code.
- Add methods for generating, verifying, enabling, disabling, and checking 2FA.
- Throw meaningful error messages.

## Rate Limiting for User Login Attempts - 2
Implement rate limiting for user login attempts.
### Requirements:
- Add new database columns or tables for failed login attempts.
- Add methods for incrementing failed login attempts and checking limits.
- Add timeout period.

## Implement Disable User Account Functionality - 1
Implement disable user account functionality.
### Requirements:
- Add new database columns or tables for account status.
- Add methods for disabling and enabling user accounts.
