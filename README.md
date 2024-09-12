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

Contains controllers and views, which processes requests from the user, and display the data.

## Functionality

View contacts: 
The main page that displays a list of all the contacts with data in the table. 

![image](https://github.com/user-attachments/assets/ba568be4-6284-45c3-9a7f-9c1b5d7dd1b6)

Opposite each of the contacts there is an option to edit and delete. 

Edit contact: A form for editing an existing contact.

![image](https://github.com/user-attachments/assets/82e27a1b-749e-4d21-ae38-5bde0f0eea26)

Delete contact: A form to confirm that you want to delete a contact.

![image](https://github.com/user-attachments/assets/7fc42e29-9857-4fc6-9488-9856ef114a25)

Below the list there is "Create New Contact" button which redirects to form for adding a new contact. Every field is required!

![image](https://github.com/user-attachments/assets/bb9fbb70-27c7-45ab-abac-9edefe2f74eb)

In the end of the page there is field for upload .csv file 

![image](https://github.com/user-attachments/assets/96029f1c-89ef-4379-a0e4-7cffc64c0a9d)

Example of the mocked file

![image](https://github.com/user-attachments/assets/49099cb1-ca31-47bc-ae94-e377e212dda9)

