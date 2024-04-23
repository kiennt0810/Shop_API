using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class updateDb20240409 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupStaff_Group_IdNhom",
                table: "GroupStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStaff_Staff_IdNhanVien",
                table: "GroupStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Function_IdCn",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Group_IdNhom",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStaff",
                table: "GroupStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Function",
                table: "Function");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "SYS_Staff");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "SYS_Role");

            migrationBuilder.RenameTable(
                name: "GroupStaff",
                newName: "SYS_GroupStaff");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "SYS_Group");

            migrationBuilder.RenameTable(
                name: "Function",
                newName: "SYS_Function");

            migrationBuilder.RenameIndex(
                name: "IX_Role_IdNhom",
                table: "SYS_Role",
                newName: "IX_SYS_Role_IdNhom");

            migrationBuilder.RenameIndex(
                name: "IX_Role_IdCn",
                table: "SYS_Role",
                newName: "IX_SYS_Role_IdCn");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStaff_IdNhom",
                table: "SYS_GroupStaff",
                newName: "IX_SYS_GroupStaff_IdNhom");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStaff_IdNhanVien",
                table: "SYS_GroupStaff",
                newName: "IX_SYS_GroupStaff_IdNhanVien");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SYS_Staff",
                table: "SYS_Staff",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SYS_Role",
                table: "SYS_Role",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SYS_GroupStaff",
                table: "SYS_GroupStaff",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SYS_Group",
                table: "SYS_Group",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SYS_Function",
                table: "SYS_Function",
                column: "MaCN");

            migrationBuilder.AddForeignKey(
                name: "FK_SYS_GroupStaff_SYS_Group_IdNhom",
                table: "SYS_GroupStaff",
                column: "IdNhom",
                principalTable: "SYS_Group",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SYS_GroupStaff_SYS_Staff_IdNhanVien",
                table: "SYS_GroupStaff",
                column: "IdNhanVien",
                principalTable: "SYS_Staff",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SYS_Role_SYS_Function_IdCn",
                table: "SYS_Role",
                column: "IdCn",
                principalTable: "SYS_Function",
                principalColumn: "MaCN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SYS_Role_SYS_Group_IdNhom",
                table: "SYS_Role",
                column: "IdNhom",
                principalTable: "SYS_Group",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SYS_GroupStaff_SYS_Group_IdNhom",
                table: "SYS_GroupStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_SYS_GroupStaff_SYS_Staff_IdNhanVien",
                table: "SYS_GroupStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_SYS_Role_SYS_Function_IdCn",
                table: "SYS_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_SYS_Role_SYS_Group_IdNhom",
                table: "SYS_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SYS_Staff",
                table: "SYS_Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SYS_Role",
                table: "SYS_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SYS_GroupStaff",
                table: "SYS_GroupStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SYS_Group",
                table: "SYS_Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SYS_Function",
                table: "SYS_Function");

            migrationBuilder.RenameTable(
                name: "SYS_Staff",
                newName: "Staff");

            migrationBuilder.RenameTable(
                name: "SYS_Role",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "SYS_GroupStaff",
                newName: "GroupStaff");

            migrationBuilder.RenameTable(
                name: "SYS_Group",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "SYS_Function",
                newName: "Function");

            migrationBuilder.RenameIndex(
                name: "IX_SYS_Role_IdNhom",
                table: "Role",
                newName: "IX_Role_IdNhom");

            migrationBuilder.RenameIndex(
                name: "IX_SYS_Role_IdCn",
                table: "Role",
                newName: "IX_Role_IdCn");

            migrationBuilder.RenameIndex(
                name: "IX_SYS_GroupStaff_IdNhom",
                table: "GroupStaff",
                newName: "IX_GroupStaff_IdNhom");

            migrationBuilder.RenameIndex(
                name: "IX_SYS_GroupStaff_IdNhanVien",
                table: "GroupStaff",
                newName: "IX_GroupStaff_IdNhanVien");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStaff",
                table: "GroupStaff",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Function",
                table: "Function",
                column: "MaCN");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStaff_Group_IdNhom",
                table: "GroupStaff",
                column: "IdNhom",
                principalTable: "Group",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStaff_Staff_IdNhanVien",
                table: "GroupStaff",
                column: "IdNhanVien",
                principalTable: "Staff",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Function_IdCn",
                table: "Role",
                column: "IdCn",
                principalTable: "Function",
                principalColumn: "MaCN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Group_IdNhom",
                table: "Role",
                column: "IdNhom",
                principalTable: "Group",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
