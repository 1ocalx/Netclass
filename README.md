dotnet --version

cd "C:\Users\11111\Desktop"

dotnet new console -n ProcessManager
cd ProcessManager

Copy-Item "C:\Users\11111\Desktop\Net.cs" -Destination "Program.cs"

dotnet build

dotnet run
