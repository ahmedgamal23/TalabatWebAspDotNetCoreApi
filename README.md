# Talabat Project - ASP.NET Core 8 API

## Description: 
   #### Developed a robust API for a food delivery service, Talabat, using ASP.NET Core 8. The project includes various controllers and a class library to manage different aspects of the service.

## Key Features:
  ### Account Management: Implemented user registration and login with JWT authentication, supporting roles such as Customer, Admin, and DeliveryPerson.
  ### Delivery Management: CRUD operations for delivery data.
  ### Menu Management: CRUD operations for menu items.
  ### Order Management: CRUD operations for orders and order items.
  ### Payment Management: CRUD operations for payments.
  ### Restaurant Management: CRUD operations for restaurant data.
  ### Review Management: CRUD operations for reviews.

# Technical Details:
  ## Controllers: Account, Delivery, MenuItem, Order, OrderItem, Payment, Restaurant, Review.
  ## Data Layer:
     ### DbContext: Managed database context and migrations.
     ### Models: Defined entities such as ApplicationUser, Delivery, MenuItem, Order, OrderItem, Payment, Restaurant, Review.
     ### ModelViews: Utilized DTOs to optimize data transfer.
     ### Repositories: Created a main repository for common functions and specific repositories for additional functionalities.

# Technologies Used:
  ### ASP.NET Core 8
  ### Entity Framework Core
  ### JWT Authentication
  ### RESTful API Design

### ------------------------------
### ------------------------------

# Overview :
  ## This project is a comprehensive API for a food delivery service, Talabat, developed using ASP.NET Core 8. It includes various controllers to manage different aspects of the service, such as user accounts, deliveries, menu items, orders, payments, restaurants, and reviews.

# Features
  ## Account Management
    - Register and Login: Users can register and log in using JWT for authentication.
    - Roles: Supports multiple roles including Customer, Admin, and DeliveryPerson.
  ## Delivery Management
    ### CRUD Operations:
      - Get all delivery data
      - Get specific delivery data
      - Add new delivery data
      - Update existing delivery data
      - Delete delivery data
  ## Menu Management
    ### CRUD Operations:
      - Get all menu items
      - Get specific menu item
      - Add new menu item
      - Update existing menu item
      - Delete menu item
  ## Order Management
    ### CRUD Operations:
      - Get all orders
      - Get specific order
      - Add new order
      - Update existing order
      - Delete order
  ## Order Item Management
    ### CRUD Operations:
      - Get all order items
      - Get specific order item
      - Add new order item
      - Update existing order item
      - Delete order item
  ## Payment Management
    ### CRUD Operations:
      - Get all payments
      - Get specific payment
      - Add new payment
      - Update existing payment
      - Delete payment
  ## Restaurant Management
    ### CRUD Operations:
      - Get all restaurants
      - Get specific restaurant
      - Add new restaurant
      - Update existing restaurant
      - Delete restaurant
  ## Review Management
    ### CRUD Operations:
      - Get all reviews
      - Get specific review
      - Add new review
      - Update existing review
      - Delete review
# Technical Details
  ##Controllers
    ### AccountController: Manages user registration, login, and role assignments.
    ### DeliveryController: Handles CRUD operations for delivery data.
    ### MenuItemController: Manages CRUD operations for menu items.
    ### OrderController: Handles CRUD operations for orders.
    ### OrderItemController: Manages CRUD operations for order items.
    ### PaymentController: Handles CRUD operations for payments.
    ### RestaurantController: Manages CRUD operations for restaurants.
    ### ReviewController: Handles CRUD operations for reviews.
# Data Layer
  ## DbContext: Manages the database context and migrations.
  ## Models: Defines the entities used in the application, including:
    - ApplicationUser
    - Delivery
    - MenuItem
    - Order
    - OrderItem
    - Payment
    - Restaurant
    - Review
  ## ModelViews: Utilizes Data Transfer Objects (DTOs) to optimize data transfer and ensure only necessary data is exposed.
  ## Repositories:
    ## Main Repository: Contains common functions used across different modules.
    ## Specific Repositories: Created for modules requiring additional functionalities.
## Technologies Used
  ### ASP.NET Core 8
  ### Entity Framework Core
  ### JWT Authentication
  ### RESTful API Design
# Getting Started
  ## Prerequisites
    - .NET 8 SDK
    - SQL Server
  ## Installation
    ### Clone the repository:
      - git clone https://github.com/yourusername/talabat-project.git
    
    ### Navigate to the project directory:
      - cd talabat-project
    
    ### Restore the dependencies:
      - dotnet restore
    
    ### Update the database:
      - dotnet ef database update
    
    ### Run the application:
      - dotnet run
  
  ## Usage
    - Use Postman or any other API client to interact with the endpoints.
    - Ensure to include the JWT token in the Authorization header for endpoints that require authentication.


## Sample:
![Screenshot (592)](https://github.com/user-attachments/assets/cae91543-b41f-4908-967c-393b8a440988)

![Screenshot (593)](https://github.com/user-attachments/assets/42358afd-e93b-453b-b23b-445fdcdb9c55)





