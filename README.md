<h3>GOLocal API</h3>

<b>Summary:</b> This is a `.NET Core 2.1` backend for the GOLocal application. It is a REST API which does not serve any views.

<b>Run:</b> You can run the application in Visual Studio on `IIS` or `Kestrel`. Alternatively, you can run it in a container via either of the options below.

Docker:
 - `docker build -t golocalapi -f ./deployment/docker/Dockerfile . --no-cache`
 - `docker run -p 8080:80 golocalapi`

Docker-compose:
 - `docker-compose -f deployment/docker/docker-compose.yml build --no-cache`
 - `docker-compose -f deployment/docker/docker-compose.yml up`  

<b>Swagger</b>: https://localhost:44305/swagger/index.html

<b>Int endpoint</b>: https://api-int.crossroads.net/golocal/api/health/status
