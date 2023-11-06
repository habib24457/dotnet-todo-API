Create API project on VSCode: Microsoft Documentation: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio

-Open a folder on VSCode

-Open Terminal in that folder

-Run command: dotnet new webapi -o ProjectName

-Run commands:

i)cd TodoApi

ii)dotnet add package Microsoft.EntityFrameworkCore.InMemory

iii)dotnet dev-certs https --trust

iv)dotnet run --launch-profile https

Cmd+Click on the localhost link: https://localhost:7038

Note: It will show ‘Page not found’. To solve this,
Add the following:

https://localhost:7038/swagger
