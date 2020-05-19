using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEscola.Migrations
{
    public partial class AddEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Aluno",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Aluno");
        }
    }
}
