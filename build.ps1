cd build
docker build --build-arg HTTP_PROXY=%HTTP_PROXY% --build-arg HTTPS_PROXY=%HTTPS_PROXY% -t msbuild .
cd ..

Invoke-Expression "docker run -v $($PWD):c:/src msbuild"


docker build -f Dockerfile -t guid-generator:0.1 .

