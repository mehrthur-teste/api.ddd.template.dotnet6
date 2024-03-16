# api.ddd.template.dotnet6
git init
git add .
git commit -m "recreate stack api sln"
git remote add origin https://github.com/mehrthur-teste/api.ddd.template.dotnet6.git
git branch -M main
git push -u origin main

[1]
dotnet new sln  --name api.headphones.template

[2]
cd src\1-Application

[3]
dotnet new webapi -n api.application.template -o api.application.template --no-https --framework net6.0  

[4]
cd..
[5]
cd..

[6]
dotnet sln add src\1-Application\api.application.template\

[10]
dotnet build 

[11]
cd src\2-Domain

[12]
dotnet new classlib -n api.domain.template -o api.domain.template -f net6.0

[13]
cd..
[14]
cd..

[15]
dotnet sln add src\2-Domain\api.domain.template\

[16]
dotnet build 