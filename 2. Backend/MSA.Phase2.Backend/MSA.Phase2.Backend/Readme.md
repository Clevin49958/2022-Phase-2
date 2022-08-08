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
  - An example would be within the controller. We inherit the ControllerBase class, to enable access to attributes like "ApiController", "Route", and HttpGet/Put/Post/Delete. Using these attributes, we can easily configure the route, method, and default behaviour such as parameter inferencing, automatic error-handling without having to rewrite long and duplicate code.

Section Three
You will need to:

Demonstrate the use of NUnit to unit test your code.
Use at least one substitute to test your code.
Demonstrate an understanding of why the middleware libraries made your code easier to test.