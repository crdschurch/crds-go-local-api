# Step 0: build, test, and publish application 
FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app 
 
# Copy files to /app 
COPY ./ ./ 
 
# Change working directory to CrdsGoLocalApi 
WORKDIR /app/CrdsGoLocalApi
 
# Declare args
ARG CRDS_EMBED_ENV
 
# Change work directory back to /app - root of proj 
WORKDIR /app

WORKDIR /app/CrdsGoLocalApi

# Run Unit Tests
RUN dotnet test CrdsGoLocalApi.Tests/CrdsGoLocalApi.Tests.csproj

# Publish build to out directory 
RUN dotnet publish -c Release -o out

# Step 1: Build runtime image 
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app

# Copy over the build from the previous step 
COPY --from=build-env /app/CrdsGoLocalApi/out ./
 
# Run the dotnet entrypoint for the CrdsGoLocalApi dll 
ENTRYPOINT ["dotnet", "CrdsGoLocalApi.dll"]