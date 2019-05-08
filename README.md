# RandomImageGeneratorAPI
RESTful back-end for working with the react RandomImage project client

## Project type
ASP.NET Core 2.1 Backend

## Description /features
- RestFull API using the ION Specification Schema and HATEOAS best practices implementation that allows you navigate through de API 
using links included in the responses .
- Pagination in API Image and History responses that allows navigate  through  different pages by setting limit and offset 
in the link request.
- OpenIddict implementation for token Authentication.
- Swagger UI implementation for API documentation and endpoint testing (accessing through https://localhost:44394/swagger)
- Aws S3 for storing images
- Sql Server in the cloud using AWS RDS 
- Forcing Https in the server for security 
- ASP.NET Core Identity implementation for information related with user account, with password hash etc

### History
- The history is user based, so it will display only the history of the connected user

## Additional notes:
- The project was set to run only with https at https://localhost:44394
- For using in postman you should disable SSL verification as the https certificate is not signed. (File > Settings > turn off SSL certificate verification)
- For getting random images is not necessary to use token (it is open), but for history token is required


## Database
The database is hosted on AWS using aws RDS, if you need to access it the connection string with my credential is in appsettings.json


## Improvements 
- Now the random image endpoint display images that the user have already liked/disliked as the requirements did'nt specify how to do it.
## Other posibles implementetion of this
- Could be filtering the liked/disliked images and only show new images
