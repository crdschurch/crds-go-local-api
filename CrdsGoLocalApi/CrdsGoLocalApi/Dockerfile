FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CrdsGoLocalApi/CrdsGoLocalApi.csproj", "CrdsGoLocalApi/"]
RUN dotnet restore "CrdsGoLocalApi/CrdsGoLocalApi.csproj"
COPY . .
WORKDIR "/src/CrdsGoLocalApi"
RUN dotnet build "CrdsGoLocalApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CrdsGoLocalApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CrdsGoLocalApi.dll"]