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

## Additional notes:
- The project was set to run only with https at https://localhost:44394
- For using in postman you should disable SSL verification as the https certificate is not signed. (File > Settings > turn off SSL certificate verification)

