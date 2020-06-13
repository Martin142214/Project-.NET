# Project-.NET
 
Tennis players Website:
A Tennis players Website that is built with ASP.NET Framework 4.7.2 MVC.

Skeleton of the project:
The whole solution is made of one project :
DataStructure, DataAccess and Tennis players website.
DataStructure - Contains all of the Models (Players, Comments, Users, Products).
DataAccess - Contains the migrations added to the project, the Repositories which make CRUD operations linked to the models.
Tennis players Website - Here we can find the Controllers, Views, Services, ViewModels and the Photo folder where the images from the news are stored.

Functionality of the project:
We can create, read, update and delete(Players, comments and products) in the project if we have Admin privileges.
The normal user can register an account in which he can log in to read information on the website and create players or products. He can also apply the CRUD operations on the comments, products and on the players, but cannot edit/delete other users' comments/products.