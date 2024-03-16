# api.ddd.template.dotnet6
git init
git add .
git commit -m "text"
git remote add origin https://github.com/mehrthur-teste/api.ddd.template.dotnet6.git
git branch -M main
git push -u origin main

[1]
dotnet new sln  --name api.headphones.template

[2]
cd src\1-Application

[3]
dotnet new webapi -n application -o api.application.template --no-https --framework net6.0  

[4]
cd..
[5]
cd..

[6]
dotnet sln add src\1-Application\api.application.template\

[10]
dotnet build