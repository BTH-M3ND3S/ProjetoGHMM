using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGHMM.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaPeca",
                columns: table => new
                {
                    CategoriaPecaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaPecaNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaPeca", x => x.CategoriaPecaId);
                });

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    FabricanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FabricanteNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.FabricanteId);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FornecedorCnpj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.FornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "Peca",
                columns: table => new
                {
                    PecaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PecaNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peca", x => x.PecaId);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    SetorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetorNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.SetorId);
                });

            migrationBuilder.CreateTable(
                name: "TipoManutencao",
                columns: table => new
                {
                    TipoManutencaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoManutencaoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoManutencao", x => x.TipoManutencaoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMaquina",
                columns: table => new
                {
                    TipoMaquinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMaquinaNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMaquina", x => x.TipoMaquinaId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncionarioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioCpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioDataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioEscolaridade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    SetorId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "SetorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manutencao",
                columns: table => new
                {
                    ManutencaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoManutencaoId = table.Column<int>(type: "int", nullable: false),
                    ManutencaoData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManutencaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManutencaoCusto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencao", x => x.ManutencaoId);
                    table.ForeignKey(
                        name: "FK_Manutencao_TipoManutencao_TipoManutencaoId",
                        column: x => x.TipoManutencaoId,
                        principalTable: "TipoManutencao",
                        principalColumn: "TipoManutencaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    MaquinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TipoMaquinaId = table.Column<int>(type: "int", nullable: false),
                    SetorId = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumeroSerie = table.Column<int>(type: "int", nullable: false),
                    FabricanteId = table.Column<int>(type: "int", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Voltagem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.MaquinaId);
                    table.ForeignKey(
                        name: "FK_Maquina_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "FabricanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maquina_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "SetorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maquina_TipoMaquina_TipoMaquinaId",
                        column: x => x.TipoMaquinaId,
                        principalTable: "TipoMaquina",
                        principalColumn: "TipoMaquinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio",
                columns: table => new
                {
                    RelatorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatorioConteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio", x => x.RelatorioId);
                    table.ForeignKey(
                        name: "FK_Relatorio_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManutencaoEPecas",
                columns: table => new
                {
                    ManutencaoEPecasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManutencaoId = table.Column<int>(type: "int", nullable: false),
                    PecaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManutencaoEPecas", x => x.ManutencaoEPecasId);
                    table.ForeignKey(
                        name: "FK_ManutencaoEPecas_Manutencao_ManutencaoId",
                        column: x => x.ManutencaoId,
                        principalTable: "Manutencao",
                        principalColumn: "ManutencaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManutencaoEPecas_Peca_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Peca",
                        principalColumn: "PecaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_SetorId",
                table: "Funcionario",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_TipoManutencaoId",
                table: "Manutencao",
                column: "TipoManutencaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManutencaoEPecas_ManutencaoId",
                table: "ManutencaoEPecas",
                column: "ManutencaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManutencaoEPecas_PecaId",
                table: "ManutencaoEPecas",
                column: "PecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_FabricanteId",
                table: "Maquina",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_SetorId",
                table: "Maquina",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_TipoMaquinaId",
                table: "Maquina",
                column: "TipoMaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_FuncionarioId",
                table: "Relatorio",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaPeca");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "ManutencaoEPecas");

            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "Relatorio");

            migrationBuilder.DropTable(
                name: "Manutencao");

            migrationBuilder.DropTable(
                name: "Peca");

            migrationBuilder.DropTable(
                name: "Fabricante");

            migrationBuilder.DropTable(
                name: "TipoMaquina");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "TipoManutencao");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Setor");
        }
    }
}
