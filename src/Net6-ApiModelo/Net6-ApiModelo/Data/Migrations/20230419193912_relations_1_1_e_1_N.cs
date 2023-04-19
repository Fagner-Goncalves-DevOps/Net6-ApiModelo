using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net6_ApiModelo.Migrations
{
    /// <inheritdoc />
    public partial class relations_1_1_e_1_N : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Classes_IdPersoagem",
                table: "Classes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Classes",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Classes",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ArmasPorClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(100)", nullable: true),
                    IdClasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmasPorClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmasPorClasses_Classes_IdClasses",
                        column: x => x.IdClasses,
                        principalTable: "Classes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Habilidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdClasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habilidade_Classes_IdClasses",
                        column: x => x.IdClasses,
                        principalTable: "Classes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdPersoagem",
                table: "Classes",
                column: "IdPersoagem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArmasPorClasses_IdClasses",
                table: "ArmasPorClasses",
                column: "IdClasses",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habilidade_IdClasses",
                table: "Habilidade",
                column: "IdClasses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmasPorClasses");

            migrationBuilder.DropTable(
                name: "Habilidade");

            migrationBuilder.DropIndex(
                name: "IX_Classes_IdPersoagem",
                table: "Classes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Classes",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Classes",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_IdPersoagem",
                table: "Classes",
                column: "IdPersoagem");
        }
    }
}
