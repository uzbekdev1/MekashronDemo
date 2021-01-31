# Start application:

- Go to source folder (`cd .\src\`)
- Navigate to Web project (` cd .\MekashronWeb\`)
- Install npm packages (`dotnet restore`)
- Build source (`dotnet build`)
- Run source (`dotnet run`)
- Open this `http://localhost:5000` link

# Build application:

- Go to source folder (`cd .\src\`)
- Navigate to Web project (` cd .\MekashronWeb\`)
- Publish API source (`dotnet publish`)
- Go to root folder (`cd .\wwwroot\`) 
- Back on publish directory (`cd ..\..\bin\Debug\net3.1\publish\`) 
- Run application (`dotnet MekashronWeb.dll --urls "http://localhost:5000"`)
- Open in this portal `http://localhost:5000`
