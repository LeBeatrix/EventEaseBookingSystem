# EventEase Booking System

The EventEase Booking System is a cloud-based web application developed using ASP.NET Core MVC and Entity Framework Core. The system allows booking specialists to manage venues, events, and bookings through a modern web interface integrated with Microsoft Azure cloud services.

The application was developed as part of an Advanced Diploma in Application Development project and demonstrates practical implementation of cloud computing, database management, validation, and secure file storage.

---
## Project Overview

The system allows administrators and booking specialists to:

- Manage venues
- Create and manage events
- Create bookings linking events and venues
- Upload and manage venue images using Azure Blob Storage
- Search bookings, events, and venues
- Prevent double bookings
- Restrict deletion of venues and events associated with active bookings

The application uses ASP.NET Core MVC together with Entity Framework Core and SQL Server hosted on Azure.

---
## Technologies Used

- ASP.NET Core MVC (.NET 8)
- C#
- Entity Framework Core
- SQL Server
- Azure SQL Database
- Azure Blob Storage
- Azure App Service
- GitHub Actions
- Bootstrap 5
- Visual Studio / VS Code

---
## Features

### Venue Management
- Create, edit, and delete venues
- Upload venue images to Azure Blob Storage
- Venue search functionality
- Validation for required fields

### Event Management
- Create, edit, and delete events
- Link events to venues
- Event search functionality
- Restrict deletion when bookings exist

### Booking Management
- Create bookings linking events and venues
- Prevent double bookings for the same venue and date
- Consolidated booking summary display
- Search bookings by Booking ID or Event Name

### Cloud Integration
- Azure SQL Database integration
- Azure Blob Storage image management
- Azure App Service deployment
- GitHub Actions CI/CD deployment pipeline

---
## Database Structure
The system contains three primary entities.

## Venue

| Field | Description |
|---|---|
| VenueId | Primary Key |
| VenueName | Venue name |
| Location | Venue location |
| Capacity | Maximum venue capacity |
| ImageUrl | Azure Blob Storage image URL |

---

## Event

| Field | Description |
|---|---|
| EventId | Primary Key |
| EventName | Event name |
| Description | Event description |
| EventDate | Date of event |
| VenueId | Foreign Key to Venue |

---

## Booking

| Field | Description |
|---|---|
| BookingId | Primary Key |
| EventId | Foreign Key to Event |
| VenueId | Foreign Key to Venue |
| BookingDate | Booking date |

---
## Azure Blob Storage Integration

Venue images are uploaded directly to Azure Blob Storage instead of storing placeholder URLs.

Features include:

- Secure image upload
- Blob image retrieval
- Image replacement during editing
- Blob deletion when venue records are deleted
- File type validation
---
# Search Functionality

Search functionality was added across the system:

| Module | Search Criteria |
|---|---|
| Venues | Venue name, location |
| Events | Event name, venue |
| Bookings | Booking ID, event name |

---
## Running the Project Locally
### Prerequisites
- Visual Studio 2022 or VS Code
- .NET 8 SDK
- SQL Server LocalDB
- Azure Storage Account (optional for image upload)
---
### Steps
1. Clone the repository
```bash
git clone https://github.com/LeBeatrix/EventEaseBookingSystem.git
```
2. Open the project
3. Restore packages
```bash
dotnet restore
```
4. Apply database migrations
```bash
dotnet ef database update
```
5. Run the application
```bash
dotnet run
```
---
## Azure Deployment

The application is deployed using:

- Azure App Service
- Azure SQL Database
- Azure Blob Storage
- GitHub Actions CI/CD
---
### Live Web Application
https://st10496124.azurewebsites.net/

---
## CI/CD Deployment

GitHub Actions is used to automate:

- Build process
- Publish process
- Azure deployment

The workflow automatically deploys the application whenever changes are pushed to the master branch.

---
## Author

Lené Prinsloo  
Advanced Diploma in Application Development Student
IIE Rosebank College

---
## References

- Microsoft Documentation – Entity Framework Core  
  https://learn.microsoft.com/en-us/ef/core/

- Microsoft Documentation – ASP.NET Core MVC  
  https://learn.microsoft.com/en-us/aspnet/core/mvc/

- Azure Documentation – App Service Deployment  
  https://learn.microsoft.com/en-us/azure/app-service/
