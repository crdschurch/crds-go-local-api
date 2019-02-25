# Step 0: build, test, and publish application 
FROM microsoft/aspnetcore-build:2.0 AS build-env 
WORKDIR /app 
 
# Copy files to /app 
COPY . ./ 
 
# Change working directory to CrdsGoLocalApi 
WORKDIR /app/CrdsGoLocalApi 
 
# Declare args
ARG CRDS_EMBED_ENV

# NPM Install from w/in the CrdsGoLocalApi dir 
RUN npm install 
 
# Change work directory back to /app - root of proj 
WORKDIR /app 
 
# Run Unit Tests 
# RUN dotnet test CrdsFred.Tests/CrdsFred.Tests.csproj 
 
# Publish build to out directory 
RUN dotnet publish -c Release -o out 
 
# Step 1: Build runtime image 
FROM microsoft/aspnetcore:2.0 
WORKDIR /app 
 
# Copy over the build from the previous step 
COPY --from=build-env /app/CrdsGoLocalApi/out . 
 
# Run the dotnet entrypoint for the CrdsGoLocalApi dll 
ENTRYPOINT ["dotnet", "CrdsGoLocalApi.dll"]