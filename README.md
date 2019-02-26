<h3>GOLocal API</h3>

<b>Summary:</b> This is a `.NET Core 2.1` backend for the GOLocal application.

<b>Run:</b> You can run the application in Visual Studio on `IIS` or `Kestrel`. Alternatively, you can run the container by itself or via docker-compose.

Docker:
 - `docker build -t golocalapi -f .\deployment\docker\Dockerfile . --no-cache`
 - `docker run -p 8080:80 golocalapi`

Docker compose:
 - `docker-compose -f deployment/docker/docker-compose.yml build --no-cache`
 - `docker-compose -f deployment/docker/docker-compose.yml up`  
