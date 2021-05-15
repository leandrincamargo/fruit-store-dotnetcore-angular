using FruitStore.Domain.Utility;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitStore.Infrastructure.Migrations
{
    public partial class InsertRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql(@$"insert into dbo.Role (Id, Name)
                        values('{RoleIdentify.Administrator.Id}', '{RoleIdentify.Administrator.Name}'),
                              ('{RoleIdentify.Common.Id}', '{RoleIdentify.Common.Name}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
               .Sql(@$"delete from dbo.Role where Id in ('{RoleIdentify.Administrator.Id}', '{RoleIdentify.Common.Id}')");
        }
    }
}
