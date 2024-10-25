# Customer Relationship Management (CRM) System

This CRM project is built using **C# with .NET Core 8** and **PostgreSQL** for robust customer management. The project adopts **CQRS** and **Onion Architecture** for clear separation of concerns and maintainability.

## 📖 Project Overview

This CRM system provides a user-friendly interface to manage customer data, supporting CRUD operations, user authentication, and advanced filtering.

## 🛠️ Technology Stack

### Backend

-   **Language**: C# with .NET Core 8
-   **Database**: PostgreSQL
-   **Architecture**: CQRS pattern with Onion Architecture

### Frontend

-   **Technology**: Choose either Razor Pages (with .NET Core) or React.js for a responsive user interface

## 📋 Features

### Backend Functionality

-   **CRUD Operations**: Create, Read, Update, Delete for customer data management.
-   **User Authentication and Authorization**: Uses JWT or Identity framework for secure login/logout with role-based access control.
-   **API Endpoints**: RESTful API endpoints to filter customers by various criteria like name, email, registration date, and region.
-   **Error Handling**: Implements robust error handling and input validation.
-   **Logging**: Logs significant actions (e.g., login attempts, CRUD operations, filtering) using `ILogger`.

### Database Entities

#### User Table

-   **Fields**: `Id`, `Username`, `Password`, `Role`, `CreatedAt`, `UpdatedAt`
-   **Purpose**: Manages authentication and role-based access.

#### Customer Table

-   **Fields**: `Id`, `FirstName`, `LastName`, `Email`, `Region`, `RegistrationDate`
-   **Purpose**: Stores customer information.

### Frontend Functionality

-   **Login Page**: Allows users to log in to access the CRM dashboard.
-   **Customer Management Page**:
    -   Lists customers in a table with search and filtering options.
    -   Forms for adding new customers, editing, and deleting existing ones.
    -   Filter options by name, region, and registration date.
    -   Responsive design for both mobile and desktop views.

## 🚀 Additional Requirements

-   **RESTful API**: All CRUD and filtering functionalities are available through REST API endpoints.
-   **Code Quality**: Adheres to best practices, code structure, and naming conventions, using the Repository Pattern for data handling.

## 📄 Mock Data

Use the following mock data for initial testing:

sql

Kodu kopyala

`INSERT INTO customer (FirstName, LastName, Email, Region, RegistrationDate) VALUES
('John', 'Doe', 'john.doe@example.com', 'North America', '2023-06-15'),
('Jane', 'Smith', 'jane.smith@example.com', 'Europe', '2023-05-10'),
('Carlos', 'Gomez', 'carlos.gomez@example.com', 'South America', '2023-07-22');` 

## 🎯 Evaluation Criteria

1.  **Efficient Use of .NET Core**: Correct use of C# collections, LINQ, and PostgreSQL integration.
2.  **Frontend Design**: Clean, user-friendly, responsive, and functional CRUD operations and filtering.
3.  **Authentication and Authorization**: Proper user authentication, authorization, and access control.
4.  **Code Quality**: Well-structured, maintainable, and efficient code with design patterns like Repository Pattern.
