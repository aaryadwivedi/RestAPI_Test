using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiDbConnect1502.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginMasters_RoleMasters_RoleId",
                table: "LoginMasters");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "LoginMasters",
                newName: "RolesRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginMasters_RoleId",
                table: "LoginMasters",
                newName: "IX_LoginMasters_RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginMasters_RoleMasters_RolesRoleId",
                table: "LoginMasters",
                column: "RolesRoleId",
                principalTable: "RoleMasters",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginMasters_RoleMasters_RolesRoleId",
                table: "LoginMasters");

            migrationBuilder.RenameColumn(
                name: "RolesRoleId",
                table: "LoginMasters",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginMasters_RolesRoleId",
                table: "LoginMasters",
                newName: "IX_LoginMasters_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginMasters_RoleMasters_RoleId",
                table: "LoginMasters",
                column: "RoleId",
                principalTable: "RoleMasters",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
