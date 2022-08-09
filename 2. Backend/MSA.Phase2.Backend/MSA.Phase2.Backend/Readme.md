## Section One
You will need to:

- Create at least one controller that implements CRUD operations for a resource (Create, Read, Update, Delete).
  - Location controller
- Call at least one other API.
  - Weather API in weather controller
- Create at least two configuration files, and demonstrate the differences between starting the project with one file over another.
  - Default, deployment and US. 
  - Only the deployment configuration will load swagger page at /swagger
  - The three configurations will return temperature data in units of Celcius, Kelvin, and Fahrenheit respectively (See Units in each configuration)


## Section Two

You will need to:

- Demonstrate an understanding of how these middleware via DI (dependency injection) simplifies your code.
  - An example would be within the weather controller. The weather controller has a dependency on httpClient and configurations including environemnt variables and api keys. Without DI, the controller has to manage all its dependencies by itself potentially through interface. However the dependencies may be reused across several controller and managing the dependency within the controller cause them to be scattered over all the files and dulplicated. DI follows the principle of inversion of control and its dependency (client and configs, etc) would be supplied through the constructor.

Section Three
You will need to:

- Demonstrate the use of NUnit to unit test your code.
  - See UnitTestingLocation
- Use at least one substitute to test your code.
  - See UnitTestingWeather
- Demonstrate an understanding of why the middleware libraries made your code easier to test.
  - NUnit test provides attributes like [test] and [SetUp]. The `test` labeled functions are automatically detected, called and provided summary detail so we don't have to set up boiler plate code. The `SetUp` labeled function provide fresh copies of fixtures for each test and also reduces the amount of setup work required for testing.