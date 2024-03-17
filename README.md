# api.ddd.template.dotnet6
git init
git add .
git commit -m "create stack data"
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

[17]
dotnet new classlib -n api.cross-cutting.template -o api.cross-cutting.template -f net6.0

[18]
dotnet sln add src\5-CrossCutting\api.cross-cutting.template\

[19]
cd ..

[20]
cd ..

[21]
dotnet sln add src\5-CrossCutting\api.cross-cutting.template\

[22]
cd src\3-Data

[23]
dotnet new classlib -n api.data.template -o api.data.template -f net6.0

[27]
cd ..

[28]
cd ..

[29]
dotnet sln add src\3-Data\api.data.template\

[30]
cd ..

[31]
cd ..

[32]
cd src\4-Service

[31]
dotnet new classlib -n api.service.template -o api.service.template -f net6.0

[32]
cd ..

[33]
cd ..

[34]
dotnet sln add src\4-Service\api.service.template\

