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

# Publish build to out directory 
RUN dotnet publish -c Release -o out

# Step 1: Build runtime image 
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app

# Copy over the build from the previous step 
COPY --from=build-env /app/CrdsGoLocalApi/out ./
 
# Run the dotnet entrypoint for the CrdsGoLocalApi dll 
###ENTRYPOINT ["dotnet", "CrdsGoLocalApi.dll"]

# Install wget
RUN echo 'installing wget' \
&& apt-get update \
&& apt-get install -y wget

RUN echo 'installing gnupg' \
&& apt-get install -y gnupg

# Install new relic
RUN echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
&& wget -O- https://download.newrelic.com/548C16BF.gpg | apt-key add - \
&& apt-get update \
&& apt-get install newrelic-netcore20-agent

# Make sure this is running in production
ENV ASPNETCORE_ENVIRONMENT=Production

ENV CORECLR_NEWRELIC_HOME=/usr/local/newrelic-netcore20-agent

CMD $CORECLR_NEWRELIC_HOME/run.sh dotnet CrdsGoLocalApi.dll



