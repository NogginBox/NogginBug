# NogginBug

A simple bug tracking sample web app using .NET Core MVC and EF Core.

## Data
To get started run the migrations in NogginBug.Data. You will need to create a database called NogginBug on your local SQL Server Express, or change the connection strings in DataContext constructor and appsettings.json.

I'm injecting the DataContext and using it directly. The EF data context uses the Unit of Work pattern and each DBSet uses the repository pattern. As you can test controllers and services using the context with an in memory version I don't normally create my own repositories. I create extension methods on IQueryable to share any data access logic and unit test these. I find this really neat and it does not hide any of EF's features from you and makes it easy to use the correct include statements for any query.

The data layer contains the models for bugs and users. They enforce the business logic of the app and are not anemic models just used for EF.

## Testing
There are some unit tests, but I've used this project to learn how to use SpecFlow and BDD so all features are tested through this and there are fewer unit tests than I would normally write. As this is my first time using SpecFlow I'd love any feedback. I've setup the data for tests through the API. This has worked well, but not sure if it is best practice. Would also like feedback on my use of given/when/then and if this could be refined. If I had more time I'd add more scenarios to my feature files and I'd add more unit tests for error cases.

## JavaScript
I've been experimenting with vanilla JS recently to see how much you really need frameworks and what comes in the box. I've included my own libraries _dom and _ajax that provide a nice interface for playing with the dom and sending ajax requests.

I chose to make this site using mainly server driven HTML pages. For the actions that don't take you away from the same page I've used ajax.

## API
The app has a simple API which is documented using Swagger. The homepage of the app includes a link to the documentation.

# Todo

* Feature: Change user's name
* New js driven notifications on page should replace old ones
* AJAX progress spinners, make it clear that an AJAX action is in progress
* Add more scenarios to feature files
* Input validation on create bug (required fields and input length)
* Improve error messages from API
* Improve swagger metadata
* Refactor: Repeated code to check a guid is valid, get an entity and return 404 if either not possible (look at ways to make DRY) #td1
* Move specflow tests into their own project so the other tests can run concurrently.

# Suggested new features

* A user has to login to see any page with data entered into the app
* A user can view closed bugs
* A user can edit a bug
* A user can see when a bug was closed
* A user can log in
* A user can see who created a bug
