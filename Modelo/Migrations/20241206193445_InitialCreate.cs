using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoGrupos",
                columns: table => new
                {
                    EstadoGrupoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoGrupos", x => x.EstadoGrupoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoNotaCompras",
                columns: table => new
                {
                    EstadoNotaCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoNotaCompras", x => x.EstadoNotaCompraId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoUsuarios",
                columns: table => new
                {
                    EstadoUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoUsuarios", x => x.EstadoUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    ModuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.ModuloId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreyApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DNI = table.Column<long>(type: "bigint", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    Proveedor_RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministradorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Formularios",
                columns: table => new
                {
                    FormularioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formularios", x => x.FormularioId);
                    table.ForeignKey(
                        name: "FK_Formularios_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "ModuloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotaCompras",
                columns: table => new
                {
                    NotaCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroNotaCompra = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientePersonaId = table.Column<int>(type: "int", nullable: false),
                    ProveedorPersonaId = table.Column<int>(type: "int", nullable: false),
                    MedioPago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaCompras", x => x.NotaCompraId);
                    table.ForeignKey(
                        name: "FK_NotaCompras_Personas_ClientePersonaId",
                        column: x => x.ClientePersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaCompras_Personas_ProveedorPersonaId",
                        column: x => x.ProveedorPersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotaVentas",
                columns: table => new
                {
                    NotaVentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroNotaVenta = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedioPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientePersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaVentas", x => x.NotaVentaId);
                    table.ForeignKey(
                        name: "FK_NotaVentas_Personas_ClientePersonaId",
                        column: x => x.ClientePersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_EstadoUsuarios_EstadoUsuarioId",
                        column: x => x.EstadoUsuarioId,
                        principalTable: "EstadoUsuarios",
                        principalColumn: "EstadoUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    ComponenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoComponenteId = table.Column<int>(type: "int", nullable: true),
                    TipoComponente = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AccionId = table.Column<int>(type: "int", nullable: true),
                    FormularioId = table.Column<int>(type: "int", nullable: true),
                    GrupoId = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoGrupoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.ComponenteId);
                    table.ForeignKey(
                        name: "FK_Componentes_Componentes_GrupoComponenteId",
                        column: x => x.GrupoComponenteId,
                        principalTable: "Componentes",
                        principalColumn: "ComponenteId");
                    table.ForeignKey(
                        name: "FK_Componentes_EstadoGrupos_EstadoGrupoId",
                        column: x => x.EstadoGrupoId,
                        principalTable: "EstadoGrupos",
                        principalColumn: "EstadoGrupoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Componentes_Formularios_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "Formularios",
                        principalColumn: "FormularioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotaCompraId = table.Column<int>(type: "int", nullable: true),
                    NotaVentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_NotaCompras_NotaCompraId",
                        column: x => x.NotaCompraId,
                        principalTable: "NotaCompras",
                        principalColumn: "NotaCompraId");
                    table.ForeignKey(
                        name: "FK_Productos_NotaVentas_NotaVentaId",
                        column: x => x.NotaVentaId,
                        principalTable: "NotaVentas",
                        principalColumn: "NotaVentaId");
                });

            migrationBuilder.CreateTable(
                name: "ComponenteUsuario",
                columns: table => new
                {
                    PerfilComponenteId = table.Column<int>(type: "int", nullable: false),
                    UsuariosUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteUsuario", x => new { x.PerfilComponenteId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_ComponenteUsuario_Componentes_PerfilComponenteId",
                        column: x => x.PerfilComponenteId,
                        principalTable: "Componentes",
                        principalColumn: "ComponenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponenteUsuario_Usuarios_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleNotaCompras",
                columns: table => new
                {
                    DetalleNotaCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    NotaCompraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleNotaCompras", x => x.DetalleNotaCompraId);
                    table.ForeignKey(
                        name: "FK_DetalleNotaCompras_NotaCompras_NotaCompraId",
                        column: x => x.NotaCompraId,
                        principalTable: "NotaCompras",
                        principalColumn: "NotaCompraId");
                    table.ForeignKey(
                        name: "FK_DetalleNotaCompras_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleNotaVentas",
                columns: table => new
                {
                    DetalleNotaVentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    NotaVentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleNotaVentas", x => x.DetalleNotaVentaId);
                    table.ForeignKey(
                        name: "FK_DetalleNotaVentas_NotaVentas_NotaVentaId",
                        column: x => x.NotaVentaId,
                        principalTable: "NotaVentas",
                        principalColumn: "NotaVentaId");
                    table.ForeignKey(
                        name: "FK_DetalleNotaVentas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_EstadoGrupoId",
                table: "Componentes",
                column: "EstadoGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_FormularioId",
                table: "Componentes",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_GrupoComponenteId",
                table: "Componentes",
                column: "GrupoComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteUsuario_UsuariosUsuarioId",
                table: "ComponenteUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleNotaCompras_NotaCompraId",
                table: "DetalleNotaCompras",
                column: "NotaCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleNotaCompras_ProductoId",
                table: "DetalleNotaCompras",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleNotaVentas_NotaVentaId",
                table: "DetalleNotaVentas",
                column: "NotaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleNotaVentas_ProductoId",
                table: "DetalleNotaVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Formularios_ModuloId",
                table: "Formularios",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaCompras_ClientePersonaId",
                table: "NotaCompras",
                column: "ClientePersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaCompras_ProveedorPersonaId",
                table: "NotaCompras",
                column: "ProveedorPersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaVentas_ClientePersonaId",
                table: "NotaVentas",
                column: "ClientePersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_NotaCompraId",
                table: "Productos",
                column: "NotaCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_NotaVentaId",
                table: "Productos",
                column: "NotaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadoUsuarioId",
                table: "Usuarios",
                column: "EstadoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponenteUsuario");

            migrationBuilder.DropTable(
                name: "DetalleNotaCompras");

            migrationBuilder.DropTable(
                name: "DetalleNotaVentas");

            migrationBuilder.DropTable(
                name: "EstadoNotaCompras");

            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "EstadoGrupos");

            migrationBuilder.DropTable(
                name: "Formularios");

            migrationBuilder.DropTable(
                name: "EstadoUsuarios");

            migrationBuilder.DropTable(
                name: "NotaCompras");

            migrationBuilder.DropTable(
                name: "NotaVentas");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
