cd build
docker build -t msbuild .
cd ..

Invoke-Expression "docker run -v $($PWD):c:/src msbuild"


docker build -f Dockerfile -t devconfguid .

