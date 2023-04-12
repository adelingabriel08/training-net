# Training .NET

Create a similar controller to the **StudentsController**. Example: **ProfessorController**

## PREREQs:
Make sure you have installed the following:
1. Rider
2. .NET 7 SDK (https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
3. After installing the SDK, install the entity framework tool running the following command in a terminal:
`dotnet tool install --global dotnet-ef`

4. A MySQL server (with docker recommended)

Steps:
1. Create the **Professor** entity in the **Entities** folder
2. Declare the **Professor** table in the **ApplicationDbContext** class
3. Open a terminal in the **Training.Backend.API2** folder and run the following command to create a migration: 
`dotnet ef migrations add <give-a-name-here>`
4. Apply the migration to the database using the following command:
`dotnet ef database update`
5. Implement the controller with the CRUD operation for your Entity you defined, the Professor in our case
