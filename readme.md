# Internal Resource Booking System

A simple ASP.NET Core MVC web application that allows employees to efficiently view and book internal company resources such as meeting rooms, company vehicles and specialized equipment. This web application mitigates the manual process of duplicate booking records.

## Features

- View, create, update, and delete resources
- Book resources with time conflict prevention
- View upcoming bookings per resource
- Server-side and basic client-side validation
- Uses Entity Framework Core with SQLite or SQL Server

## Tech Stack

- ASP.NET Core MVC
- Entity Framework Core
- C#
- Bootstrap (for UI)
- SQL Server, Azure Data Studio, & Docker

## Getting Started

1. **Clone the repository**
   """bash"""
   git clone <https://github.com/your-username/internal-booking-system.git>
   cd internal-booking-system

<!-- Application Directory and Files -->
## Project Structure

1. Controllers{
   - DashboardController: implementation of statics
   - BookingsController: implementation of booking of resources
   - Resources: implementation of resources
}

2. Data{
   - ApplicationDbContext: implementation of database connection and mapping of entities
   - Migrations: database migrations
}

3. DTOS:{
   - Resources: implementation of attribute records for the resource entity.
   - Booking: implementation of attribute records for the booking entity.
}

4. Interfaces{
   - holds the backbone structure of database repositories querying functions and the services backbones to logic implementation{
      -IBookingRepo,
      -IBookingService
      -IResourceRepo
      -IResourceService
      -IStatsService
   }
}

5. Models{
   - Booking Model (Database Entity)
   - Dashboard Model (for the statistics on the dashboard),
   - Resource Model (Database Entity)
}

6. Repositories{
   - BookingRepo: database querying logic for bookings
   - ResourceRepo: database querying logic for resources
}

7. Services{
   - BookingService: database querying logic for bookings
   - ResourceService: database querying logic for resources
   - DashboardService: database querying logic for resources
}

8. Views(UI){
   - Dashboard: stats UI
   - Bookings: CRUD UI for bookings
   - Resources: CRUD UI for resources
}

## Why I chose this structure?

- To allow separation of concerns by centralizing data access and business logic to their own files.
""" Controller (HTTP Layer)
   ↓
Service (Business Logic)
   ↓
Repository (Data Access)
   ↓
DbContext (Database) """

- MVC pattern Reasons:

1. Routing is easier
2. Separation of concerns
3. Reusable logic
<!--

Message to Reviewer: Please note due to time, I couldn't add much comments into the project.

-->