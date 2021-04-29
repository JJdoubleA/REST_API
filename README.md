# Rocket-Elevators-Rest-API

This repo serves as the Rocket Elevators REST API developed for CodeBoxx's week 9 of the Odyssey program. Last week we were tasked with developing a REST API to interact with the MYSQL database that already exists, and provide the appropriate requests for queries. This week we need to add additonal functionality to our RestAPI to develop our informations system further through the use of PUT & GET requests that change the statuses' for our Interventions through the use of a program called Postman

The queries for the REST API are found in a public PostMan workspace at: https://app.getpostman.com/join-team?invite_code=5d0b4faee94fb95dd13ea6256cd9fe19
A working example of the the REST API URL is: https://rocket-api-boom.azurewebsites.net//api/interventions/pending , or you can join the postman link above and get the links.

You will have to test the PUT request yourself to check that a 'pending' intervention can be changed to 'In-progress' and eventually 'Completed'. More about that below.



--- Intervention Request: ---

1. GET Select All Interventions - Returns all the interventions and the informations pertaining to them that are in the backoffice. 

2. Get Select One Intervention - Returns one intervention by ID from the backoffice.

3. Get Pending Interventions - Returns all interventions that are currently 'pending' and need to be processed by the employee.

4. Put #1 -In-Progress - Changes the status of an intervention from 'pending' to 'in-progress'. Note: you will need goto the Postman link above and underneath the url for the requests, click body and change it to RAW and the dropdown bar should change from TEXT to JSON  

5. Put #2 -Completed - Changes the status of an intervention from 'pending' to 'Completed. Note: Follow the same instruction above in (#4) but inside the JSON text change the status to 'Completed' instead of 'In-progress'.



--- Older requests for the RestApi they work as well. ---

Each request works as follows:

1. GET Batteries - Returns the information for a specific battery, and different batteries can be returned by changing the number at the end of the API request.

2. GET Batteries Status - Returns the current status of the queried battery.

3. PUT Batteries Status - Changes the status of the queried battery to either 'Active', 'Inactive', or 'Intervention'.

4. GET Columns - Returns the information for a specific column, and different columns can be returned by changing the number at the end of the API request.

5. GET Columns Status - Returns the current status of the queried column.

6. PUT Columns Status - Changes the status of the queried column to either 'Active', 'Inactive', or 'Intervention'.

7. GET Elevators - Returns the information for a specific elevator, and different elevators can be returned by changing the number at the end of the API request.

8. GET Elevators Status - Returns the current status of the queried elevator.

9. PUT Elevators Status - Changes the status of the queried elevator to either 'Active', 'Inactive', or 'Intervention'.

10. GET Elevators List Not Active - Returns a list of elevators that do not have a status of 'Active'.

11. GET Buildings List Intervention - Returns a list of all the buildings that have a battery, column, or elevator with a status of 'Intervention'.

12. Get Leads (all) - Returns a list of all the leads in the database.

13. GET Leads (Last 30 Days) - Returns a list of all leads submitted in the last 30 days, where the submitted lead is not also linked to a customer.
