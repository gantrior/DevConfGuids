# restore nuget on sln in current folder
Invoke-Expression "nuget restore $((Get-Item "*.sln").FullName)" 

# build
Invoke-Expression "& `"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe`" $((Get-Item "*.sln").FullName) /p:DeployOnBuild=true /p:PublishProfile=Default /t:Clean,Build"