
This is a demo and practice code 

# Online Store

App for online store ... 

Demo UI 
https://onlineshopui.azurewebsites.net/

Demo API 
https://onlineshopapi.azurewebsites.net/api/product 

Angular 4+ 
Bootstrap 4 
.net core  

## Pre req's 

  1. Install .net core -> https://www.microsoft.com/net/learn/get-started/windows 
  2. Install nodejs ->  https://nodejs.org/en/download/
  3. Get bootstrap ->  https://getbootstrap.com/
  4. Install angular cli -> https://github.com/angular/angular-cli
 
## Running api 

  1. cd to IFarmer.api 
  2. dotnet build 
  3. dotnet run 

## Running UI 
   1. cd to IFarmer.Ui 
   2. npm install 
   3. ng serve 

Make sure run api first then UI. 

# DB Migration & Connection 

To get latest appsetting.json for connection or update your db with migration script email @ : vigu.yedakad@gmail.com 

# Initial create 

dotnet ef migrations add InitialCreate 

# To undo this action 

ef migrations remove

# apply the migration to the database to create the schema

Update-Database

dotnet ef database update
