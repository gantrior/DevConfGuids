FROM microsoft/windowsservercore:10.0.14393.206  
MAINTAINER Tomas Panik

SHELL ["powershell"]

# Add .NET + ASP.NET
RUN Install-WindowsFeature NET-Framework-45-ASPNET ; \  
    Install-WindowsFeature Web-Asp-Net45

# install chocolatey
RUN iwr https://chocolatey.org/install.ps1 -UseBasicParsing | iex
    
# install MSBuild
RUN choco install microsoft-build-tools -y

# install Nuget
RUN choco install nuget.commandline -y

# install .NET 4.5.2 targets
RUN choco install netfx-4.5.2-devpack -y

# install WebDeploy (to be able to publish ASP.NET app)
RUN choco install webdeploy -y

WORKDIR "C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0"

# Install Web Targets (to be able to build ASPNET app without VisualStudio
RUN nuget Install MSBuild.Microsoft.VisualStudio.Web.targets -Version 14.0.0.3  
RUN mv 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\MSBuild.Microsoft.VisualStudio.Web.targets.14.0.0.3\tools\VSToolsPath\*' 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\'  

# Add Msbuild to path
RUN setx PATH '%PATH%;C:\Program Files (x86)\MSBuild\14.0\Bin\'  

WORKDIR "C:\src"

COPY . 'c:\\build\\'

CMD ["powershell.exe", "c:\\build\\Build.ps1"]