using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGHMM.Migrations
{
    /// <inheritdoc />
    public partial class Alteraçõesnapecamodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peca_CategoriaPeca_CategoriaPeca",
                table: "Peca");

            migrationBuilder.DropForeignKey(
                name: "FK_Peca_Fornecedor_Fornecedor",
                table: "Peca");

            migrationBuilder.RenameColumn(
                name: "Fornecedor",
                table: "Peca",
                newName: "FornecedorId");

            migrationBuilder.RenameColumn(
                name: "CategoriaPeca",
                table: "Peca",
                newName: "CategoriaPecaId");

            migrationBuilder.RenameIndex(
                name: "IX_Peca_Fornecedor",
                table: "Peca",
                newName: "IX_Peca_FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Peca_CategoriaPeca",
                table: "Peca",
                newName: "IX_Peca_CategoriaPecaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peca_CategoriaPeca_CategoriaPecaId",
                table: "Peca",
                column: "CategoriaPecaId",
                principalTable: "CategoriaPeca",
                principalColumn: "CategoriaPecaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Peca_Fornecedor_FornecedorId",
                table: "Peca",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peca_CategoriaPeca_CategoriaPecaId",
                table: "Peca");

            migrationBuilder.DropForeignKey(
                name: "FK_Peca_Fornecedor_FornecedorId",
                table: "Peca");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "Peca",
                newName: "Fornecedor");

            migrationBuilder.RenameColumn(
                name: "CategoriaPecaId",
                table: "Peca",
                newName: "CategoriaPeca");

            migrationBuilder.RenameIndex(
                name: "IX_Peca_FornecedorId",
                table: "Peca",
                newName: "IX_Peca_Fornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_Peca_CategoriaPecaId",
                table: "Peca",
                newName: "IX_Peca_CategoriaPeca");

            migrationBuilder.AddForeignKey(
                name: "FK_Peca_CategoriaPeca_CategoriaPeca",
                table: "Peca",
                column: "CategoriaPeca",
                principalTable: "CategoriaPeca",
                principalColumn: "CategoriaPecaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Peca_Fornecedor_Fornecedor",
                table: "Peca",
                column: "Fornecedor",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
