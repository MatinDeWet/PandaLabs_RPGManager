## Add Migration
| Action | Command |
| --- | --- |
| Add-Migration | EntityFrameworkCore\Add-Migration xxx -Context ManagerContext -Project Persistence -StartupProject API -verbose -o Data/Migrations |

## Remove Migration
| Action | Command |
| --- | --- |
| Remove-Migration | EntityFrameworkCore\Remove-Migration -Context ManagerContext -Project Persistence -StartupProject API -verbose -o Data/Migrations |

## Update Database
| Action | Command |
| --- | --- |
| Update-Database | EntityFrameworkCore\Update-Database -Context ManagerContext -Project Persistence -StartupProject API -verbose -o Data/Migrations |