$day= Read-Host -Prompt "Day number"

$projectName = "Day"+$day

dotnet new console -o $projectName
dotnet sln add $projectName
cp .\Template\Program.cs .\$projectName\Program.cs 
# curl -o .\$projectName\input.txt https://adventofcode.com/2021/day/$day/input

cd .\$projectName
nvim Program.cs
