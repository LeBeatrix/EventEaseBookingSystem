# EventEase Booking System

## Overview

The EventEase Booking System is a cloud-based web application developed using ASP.NET Core MVC and Entity Framework Core. The system enables booking specialists to manage venues, events, and bookings through an intuitive web interface integrated with Microsoft Azure cloud services.

This project was developed as part of the Advanced Diploma in Application Development and demonstrates practical implementation of cloud computing, database management, validation, secure file storage, and continuous deployment using Microsoft Azure.

---

## Project Objectives

The system was designed to:

* Manage venues, events, and bookings
* Store venue images using Azure Blob Storage
* Prevent double bookings
* Restrict deletion of records linked to active bookings
* Provide search and filtering capabilities
* Demonstrate cloud deployment using Azure services
* Implement automated deployment through GitHub Actions

---

## Technologies Used

* ASP.NET Core MVC (.NET 8)
* C#
* Entity Framework Core
* SQL Server
* Azure SQL Database
* Azure Blob Storage
* Azure App Service
* GitHub Actions
* Bootstrap 5
* Visual Studio 2022
* Visual Studio Code

---

## System Features

### Venue Management

* Create, edit, and delete venues
* Upload venue images to Azure Blob Storage
* Search venues by venue name or location
* Venue availability tracking
* Image replacement during editing
* Validation for required fields and image uploads

### Event Management

* Create, edit, and delete events
* Associate events with venues
* Search events by event name or venue
* Restrict deletion when bookings exist

### Booking Management

* Create bookings linking venues and events
* Search bookings by Booking ID or Event Name
* Prevent double bookings for the same venue and date
* Consolidated booking information display
* Validation to ensure data integrity

### Cloud Integration

* Azure SQL Database for persistent data storage
* Azure Blob Storage for venue image management
* Azure App Service hosting
* GitHub Actions CI/CD deployment pipeline

---

## Database Structure

### Venue Entity

| Field       | Description                  |
| ----------- | ---------------------------- |
| VenueId     | Primary Key                  |
| VenueName   | Venue name                   |
| Location    | Venue location               |
| Capacity    | Maximum venue capacity       |
| ImageUrl    | Azure Blob Storage image URL |
| IsAvailable | Venue availability status    |

### Event Entity

| Field       | Description          |
| ----------- | -------------------- |
| EventId     | Primary Key          |
| EventName   | Event name           |
| Description | Event description    |
| EventDate   | Date of event        |
| VenueId     | Foreign Key to Venue |

### Booking Entity

| Field       | Description          |
| ----------- | -------------------- |
| BookingId   | Primary Key          |
| EventId     | Foreign Key to Event |
| VenueId     | Foreign Key to Venue |
| BookingDate | Booking date         |

---

## Azure Blob Storage Integration

Venue images are stored in Azure Blob Storage instead of being saved locally.

### Features

* Secure cloud image storage
* Automatic image upload
* Image retrieval through stored URLs
* Image replacement during venue editing
* Automatic image deletion when venue records are removed
* File type validation for image uploads

---

## Search Functionality

Search functionality is available throughout the system.

| Module   | Search Criteria        |
| -------- | ---------------------- |
| Venues   | Venue name, location   |
| Events   | Event name, venue      |
| Bookings | Booking ID, event name |

---

## Business Rules and Validation

### Venue Validation

* Venue name is required
* Location is required
* Capacity must be greater than zero
* Only JPG and PNG images are accepted

### Booking Validation

* Prevents double bookings for the same venue and date
* Ensures venue availability before booking
* Validates required booking information

### Delete Restrictions

* Venues linked to active bookings cannot be deleted
* Events linked to active bookings cannot be deleted

---

## Running the Project Locally

### Prerequisites

* Visual Studio 2022 or Visual Studio Code
* .NET 8 SDK
* SQL Server LocalDB
* Azure Storage Account (optional for image uploads)

### Installation Steps

1. Clone the repository:

```bash
git clone https://github.com/LeBeatrix/EventEaseBookingSystem.git
```

2. Navigate to the project directory:

```bash
cd EventEaseBookingSystem
```

3. Restore NuGet packages:

```bash
dotnet restore
```

4. Apply database migrations:

```bash
dotnet ef database update
```

5. Run the application:

```bash
dotnet run
```

---

## Azure Deployment

The application is deployed using Microsoft Azure cloud services:

* Azure App Service
* Azure SQL Database
* Azure Blob Storage
* GitHub Actions Continuous Deployment

### Live Application

https://st10496124v2.azurewebsites.net/

---

## Continuous Integration and Deployment (CI/CD)

GitHub Actions automates:

* Source code build
* Application publishing
* Azure deployment
* Continuous integration validation

The deployment workflow automatically publishes updates whenever changes are pushed to the `master` branch.

---

## Author

**Lené Prinsloo**
ST10496124
Advanced Diploma in Application Development
IIE Rosebank College

---

## References

Microsoft. (2025) *Entity Framework Core Documentation*. Available at: https://learn.microsoft.com/en-us/ef/core/ (Accessed: 12 June 2026).

Microsoft. (2025) *ASP.NET Core MVC Documentation*. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/ (Accessed: 12 June 2026).

Microsoft. (2025) *Azure App Service Documentation*. Available at: https://learn.microsoft.com/en-us/azure/app-service/ (Accessed: 12 June 2026).

Microsoft. (2025) *Azure Blob Storage Documentation*. Available at: https://learn.microsoft.com/en-us/azure/storage/blobs/ (Accessed: 12 June 2026).

Microsoft. (2025) *Azure SQL Database Documentation*. Available at: https://learn.microsoft.com/en-us/azure/azure-sql/ (Accessed: 12 June 2026).
