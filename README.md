# EventEase Booking System

The EventEase Booking System is a web-based application developed using ASP.NET Core and Entity Framework Core. 
It allows users to manage venues, events, and bookings in an event management environment.

## Project Overview

This application was developed as part of a software development assignment. 
The system allows administrators to:

- Manage venues
- Create and manage events
- Create bookings linking events and venues

The application uses ASP.NET Core MVC and Entity Framework Core with a SQL Server database hosted on Azure.

## Technologies Used

- ASP.NET Core MVC (.NET 8)
- C#
- Entity Framework Core
- SQL Server
- Azure SQL Database
- Azure App Service
- Visual Studio

## Features

- Create, edit, and delete venues
- Create, edit, and delete events
- Create bookings linking events and venues
- Image support for venues
- Database hosted on Azure SQL
- Cloud deployment via Azure App Service

## Database Structure

The system contains three main entities:

Venue
- VenueId (Primary Key)
- VenueName
- Location
- Capacity
- ImageUrl

Event
- EventId (Primary Key)
- EventName
- Description
- EventDate
- VenueId (Foreign Key)

Booking
- BookingId (Primary Key)
- EventId (Foreign Key)
- VenueId (Foreign Key)
- BookingDate

## Running the Project Locally

1. Clone the repository
2. Open the project in Visual Studio
3. Restore NuGet packages
4. Update the database using:

Update-Database

5. Run the project using Ctrl + F5

## Azure Deployment

The application is deployed using Azure App Service and Azure SQL Database.

Live Web App:
https://eventeasebookingsystem10496124-f0awb4cmb5cnb0hp.southafricanorth-01.azurewebsites.net

## Author

Lené Prinsloo  
Advanced Diploma in Application Development Student
