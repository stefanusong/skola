# Skola Web API

# CQRS Pattern
This project is built with CQRS (Command Query Responsibility Segregation) Design Pattern.

# Folder Structure
- Application : Contain all bussiness logic. Inside this folder there will be subfolders for each group of task (ex: Application/User will contain all the logic for the user controller)
- Controllers : Contain all controller of the API.
- Database    : Contain Dbcontext and entities.
- Migrations  : Contain all migration file record.
- Helpers     : Contain all helper like Auto Mapper.

# Setup
1. Make sure .NET 5 SDK is installed
2. Clone this project
3. Open the .sln file to open the web api solution
4. Run the solution
5. Done, you will be redirected to https://localhost:5001/swagger/index.html which contains a complete documentation of the API
