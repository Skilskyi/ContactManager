# ContactManager

Contact Manager is a web application developed in ASP.NET Core MVC that allows users to manage contact information. The project implements functions for viewing, creating, editing, deleting contacts, and uploading data from CSV files.

## Architecture
The project uses the Clean Architecture architecture divided into four main layers:

Application Layer:

Contains the business logic services. For example, ContactService.cs, which is responsible for operations with contacts.

Domain Layer:

Contains domain models and interfaces. Contact.cs, which represents contact data, and IContactRepository.cs, which defines data operations.

Infrastructure Layer:

Contains interface implementations and database access. ContactRepository.cs, which implements the IContactRepository.cs interface, and ContactDbContext.cs, which is responsible for interacting with the database.

Web Layer:
Contains controllers and views, which processes requests from the user, and the corresponding views for displaying data.
