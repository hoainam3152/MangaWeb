# ![MangaWebsite](https://github.com/user-attachments/assets/b33d19f8-a1d4-4256-a5f3-0f56f137a323)

<h1 align="center"> Manga Website </h1>

> Welcome to my manga website! This is a personal project, built simply for the love of sharing and discovering manga. Please keep in mind that this is a basic website, independently developed website, so you might encounter some limitations. If you are interested in trying it out or developing additional features, please read the instructions below.

## Prerequisites
This project requires .Net Core 8.0 and IDE for languages, database and website interface. Please ensure you have them installed on your machine.

<h3 align="left">Languages and Tools:</h3>
<p align="left"> 
  <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> 
  <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a> 
  <a href="https://getbootstrap.com" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/bootstrap/bootstrap-plain-wordmark.svg" alt="bootstrap" width="40" height="40"/> </a> 
</p>

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

## Installation
**BEFORE YOU INSTALL:** This project utilizes the EF Core framework with Code First approach. Please learn about it!
1. Clone this repo on your local machine:
```sh
$ git clone https://github.com/hoainam3152/MangaWeb.git
```
2. Use Visual Studio (or another tool) to open the MangaAPI.sln file in the MangaAPI folder.
3. In the appsettings.json file, replace the AppDb value with a connection string to your database.
Example:
```sh
"ConnectionStrings": {
    "AppDb": "Data Source=Server_Name;Initial Catalog=Database_Name;Persist Security Info=True;User ID=sa;Password=123;Encrypt=True;Trust Server Certificate=True"
},
```
4. Open the Package Manager Console, then type the Update-Database command.
```sh
Tools -> NutGet Package Manager -> Package Manager Console.
Update-Database
```
5. Sample Data: Execute the "data.sql" script to load the initial dataset.
6. Concurrently run the project and the index.html file in the 'web' folder (using Visual Studio Code).

**RESULT:**
Backend
![Image](https://github.com/user-attachments/assets/a19dfda9-c3ad-4ddc-bfe7-f04b1dd3c579)

Frontend
![Image](https://github.com/user-attachments/assets/b33d19f8-a1d4-4256-a5f3-0f56f137a323)

## Notes ##
1. If you receive the error 'Attackers might be trying to steal your information from localhost (for example, passwords, messages, or credit cards)' on your first project startup while testing the API in Swagger, open cmd and run the command below:
```sh
//create SSL certificate if SSL security error occurs at startup
dotnet dev-certs https --trust
```
