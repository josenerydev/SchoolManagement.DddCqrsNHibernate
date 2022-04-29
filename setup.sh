# Set execute permission
# chmod +x script-name-here.sh

# To run script
# ./setup.sh

mkdir SchoolManagement.DddCqrsNHibernate
cd SchoolManagement.DddCqrsNHibernate
dotnet new sln -n SchoolManagement
mkdir src
cd src
mkdir core
mkdir infrastructure
mkdir presentation
cd core
dotnet new classlib -f net6.0 --name SchoolManagement.Domain
dotnet new classlib -f net6.0 --name SchoolManagement.Application
cd SchoolManagement.Application
dotnet add reference ../SchoolManagement.Domain/SchoolManagement.Domain.csproj
cd ../../infrastructure
dotnet new classlib -f net6.0 --name SchoolManagement.Data
dotnet new classlib -f net6.0 --name SchoolManagement.Shared
cd SchoolManagement.Data
dotnet add reference ../../core/SchoolManagement.Domain/SchoolManagement.Domain.csproj
dotnet add reference ../../core/SchoolManagement.Application/SchoolManagement.Application.csproj
cd ../SchoolManagement.Shared
dotnet add reference ../../core/SchoolManagement.Application/SchoolManagement.Application.csproj
cd ../../presentation
dotnet new webapi --name SchoolManagement.WebApi
cd SchoolManagement.WebApi
dotnet add reference ../../core/SchoolManagement.Application/SchoolManagement.Application.csproj
dotnet add reference ../../infrastructure/SchoolManagement.Data/SchoolManagement.Data.csproj
dotnet add reference ../../infrastructure/SchoolManagement.Shared/SchoolManagement.Shared.csproj
cd ../../../
dotnet sln add src/core/SchoolManagement.Domain/SchoolManagement.Domain.csproj
dotnet sln add src/core/SchoolManagement.Application/SchoolManagement.Application.csproj
dotnet sln add src/infrastructure/SchoolManagement.Data/SchoolManagement.Data.csproj
dotnet sln add src/infrastructure/SchoolManagement.Shared/SchoolManagement.Shared.csproj
dotnet sln add src/presentation/SchoolManagement.WebApi/SchoolManagement.WebApi.csproj