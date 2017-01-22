## Containerized ASP.NET application

Example ASP.NET project and its build and deployment with Docker (Windows Container) 

build.ps1 does following:
* prepare container "msbuild" which contains all requirements for build 
* build and publish the project to "BinPublished"
* prepare container with the app