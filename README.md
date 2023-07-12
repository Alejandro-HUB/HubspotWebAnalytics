# HubspotWebAnalytics

This repository contains a C# ASP.NET Core application called HubspotWebAnalytics, which is a user-friendly and concise tool for tracking user interactions on a website and integrating with the HubSpot CRM.

## Functionality

The HubspotWebAnalytics application performs two main functions:

- **Tracking:** The application enables tracking and analytics of user interactions on a website. It captures various events and user behaviors like page views, clicks, form submissions, and custom events. These tracked events can be sent to a tracking service or analytics platform for analysis and reporting.
- **Adding a Contact:** The application provides a contact page where users can enter their contact information. This includes fields such as first name, last name, email, phone number, company, lead status, and life cycle stage. When the user submits the contact form, the application sends a request to the HubSpot API to create a new contact with the provided details. This integration allows businesses to manage and track their customer interactions and relationships through the HubSpot CRM.

## Setup and Usage

To set up and run this application, follow these steps:

### Prerequisites

- Ensure you have the necessary prerequisites installed, such as the .NET Core SDK and an IDE like Visual Studio or Visual Studio Code.

### Clone or Download

- Clone the repository to your local machine or download the source code files.

### Open the Project

- Open the project in your chosen IDE.

### Configure HubSpot API Key

- Retrieve your HubSpot API key and add it to the "HubspotWebAnalyticsSettings" section of the appsettings.json file. This allows the application to connect to the HubSpot CRM.

### Build the Project

- Build the project using your IDE's build option or by running `dotnet build` in the terminal.

### Run the Application

- Run the application using your IDE's run option or by executing `dotnet run` in the terminal.

### Access the Contact Page

- Once the application is running, access the contact page by navigating to the appropriate URL in your web browser. The URL should be `http://localhost:<port>/Home/Index` or `https://localhost:<port>/Home/Index`, depending on your setup.

### Enter Contact Details

- Fill in the required contact information fields, such as first name, last name, email, etc., on the contact page.

### Submit the Form

- Click the "Submit" button to send the contact form data to the server.

### Contact Creation

- The application will use the provided contact details to make an API request to the HubSpot CRM API. If the request is successful, a new contact will be created in the CRM. The application will log the success or failure of the contact creation process.

Please note that the specific implementation details related to tracking and API integration can be found in additional files not provided in this description.

Feel free to explore the HubspotWebAnalytics repository and leverage its capabilities for website tracking and HubSpot CRM integration.
