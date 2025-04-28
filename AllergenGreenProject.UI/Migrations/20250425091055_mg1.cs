using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllergenGreenProject.UI.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorilers",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorilers", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "KayitTipleris",
                columns: table => new
                {
                    KayitTipiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KayitAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KayitTipleris", x => x.KayitTipiId);
                });

            migrationBuilder.CreateTable(
                name: "Risklers",
                columns: table => new
                {
                    RiskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risklers", x => x.RiskId);
                });

            migrationBuilder.CreateTable(
                name: "Ureticilers",
                columns: table => new
                {
                    UreticiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UreticiAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ureticilers", x => x.UreticiId);
                });

            migrationBuilder.CreateTable(
                name: "UrunRiskRenkleris",
                columns: table => new
                {
                    RenkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenkAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunRiskRenkleris", x => x.RenkId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPremium = table.Column<bool>(type: "bit", nullable: true),
                    KayitTipleriKayitTipiId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_KayitTipleris_KayitTipleriKayitTipiId",
                        column: x => x.KayitTipleriKayitTipiId,
                        principalTable: "KayitTipleris",
                        principalColumn: "KayitTipiId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramIzinleris",
                columns: table => new
                {
                    IzinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kamera = table.Column<bool>(type: "bit", nullable: true),
                    KullaniciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramIzinleris", x => x.IzinId);
                    table.ForeignKey(
                        name: "FK_ProgramIzinleris_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Barkodlars",
                columns: table => new
                {
                    BarkodNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barkodlars", x => x.BarkodNo);
                });

            migrationBuilder.CreateTable(
                name: "UrunAramalars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarkodNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    BarkodNoNavigationBarkodNo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunAramalars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunAramalars_Barkodlars_BarkodNoNavigationBarkodNo",
                        column: x => x.BarkodNoNavigationBarkodNo,
                        principalTable: "Barkodlars",
                        principalColumn: "BarkodNo");
                    table.ForeignKey(
                        name: "FK_UrunAramalars_Kategorilers_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorilers",
                        principalColumn: "KategoriId");
                });

            migrationBuilder.CreateTable(
                name: "Urunlers",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunIcerigi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    UreticiId = table.Column<int>(type: "int", nullable: false),
                    UrunBarkod = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UrunRiskRenkleri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunOnYuzu = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UrunArkaYuzu = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunlers", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_Urunlers_Barkodlars_UrunBarkod",
                        column: x => x.UrunBarkod,
                        principalTable: "Barkodlars",
                        principalColumn: "BarkodNo");
                    table.ForeignKey(
                        name: "FK_Urunlers_Kategorilers_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorilers",
                        principalColumn: "KategoriId");
                    table.ForeignKey(
                        name: "FK_Urunlers_Ureticilers_UreticiId",
                        column: x => x.UreticiId,
                        principalTable: "Ureticilers",
                        principalColumn: "UreticiId");
                });

            migrationBuilder.CreateTable(
                name: "KullanicilarUrunler",
                columns: table => new
                {
                    KullanicisId = table.Column<int>(type: "int", nullable: false),
                    UrunsUrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullanicilarUrunler", x => new { x.KullanicisId, x.UrunsUrunId });
                    table.ForeignKey(
                        name: "FK_KullanicilarUrunler_AspNetUsers_KullanicisId",
                        column: x => x.KullanicisId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullanicilarUrunler_Urunlers_UrunsUrunId",
                        column: x => x.UrunsUrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciVeFavorilers",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciVeFavorilers", x => new { x.KullaniciId, x.UrunId });
                    table.ForeignKey(
                        name: "FK_KullaniciVeFavorilers_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KullaniciVeFavorilers_Kategorilers_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorilers",
                        principalColumn: "KategoriId");
                    table.ForeignKey(
                        name: "FK_KullaniciVeFavorilers_Urunlers_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "RisklerUrunler",
                columns: table => new
                {
                    RisksRiskId = table.Column<int>(type: "int", nullable: false),
                    UrunsUrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RisklerUrunler", x => new { x.RisksRiskId, x.UrunsUrunId });
                    table.ForeignKey(
                        name: "FK_RisklerUrunler_Risklers_RisksRiskId",
                        column: x => x.RisksRiskId,
                        principalTable: "Risklers",
                        principalColumn: "RiskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RisklerUrunler_Urunlers_UrunsUrunId",
                        column: x => x.UrunsUrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UreticiveUrunlers",
                columns: table => new
                {
                    UreticiId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UreticiveUrunlers", x => new { x.UreticiId, x.UrunId });
                    table.ForeignKey(
                        name: "FK_UreticiveUrunlers_Kategorilers_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorilers",
                        principalColumn: "KategoriId");
                    table.ForeignKey(
                        name: "FK_UreticiveUrunlers_Ureticilers_UreticiId",
                        column: x => x.UreticiId,
                        principalTable: "Ureticilers",
                        principalColumn: "UreticiId");
                    table.ForeignKey(
                        name: "FK_UreticiveUrunlers_Urunlers_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "UrunPaylasmas",
                columns: table => new
                {
                    PaylasmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaylasmaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunPaylasmas", x => x.PaylasmaId);
                    table.ForeignKey(
                        name: "FK_UrunPaylasmas_Urunlers_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "UrunRiskRenkleriUrunler",
                columns: table => new
                {
                    RenksRenkId = table.Column<int>(type: "int", nullable: false),
                    UrunsUrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunRiskRenkleriUrunler", x => new { x.RenksRenkId, x.UrunsUrunId });
                    table.ForeignKey(
                        name: "FK_UrunRiskRenkleriUrunler_UrunRiskRenkleris_RenksRenkId",
                        column: x => x.RenksRenkId,
                        principalTable: "UrunRiskRenkleris",
                        principalColumn: "RenkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UrunRiskRenkleriUrunler_Urunlers_UrunsUrunId",
                        column: x => x.UrunsUrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UrunTakipleris",
                columns: table => new
                {
                    TakipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    Revise = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunTakipleris", x => x.TakipId);
                    table.ForeignKey(
                        name: "FK_UrunTakipleris_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UrunTakipleris_Urunlers_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "UrunVeIceriklers",
                columns: table => new
                {
                    IcerikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    KullanimKosullari = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunVeIceriklers", x => x.IcerikId);
                    table.ForeignKey(
                        name: "FK_UrunVeIceriklers_Kategorilers_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorilers",
                        principalColumn: "KategoriId");
                    table.ForeignKey(
                        name: "FK_UrunVeIceriklers_Urunlers_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "KullaniciVeKaraListes",
                columns: table => new
                {
                    KaraListeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    IceriklerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciVeKaraListes", x => x.KaraListeId);
                    table.ForeignKey(
                        name: "FK_KullaniciVeKaraListes_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KullaniciVeKaraListes_UrunVeIceriklers_IceriklerId",
                        column: x => x.IceriklerId,
                        principalTable: "UrunVeIceriklers",
                        principalColumn: "IcerikId");
                    table.ForeignKey(
                        name: "FK_KullaniciVeKaraListes_Urunlers_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "UrunIcerikveRiskBilgileris",
                columns: table => new
                {
                    IcerikId = table.Column<int>(type: "int", nullable: false),
                    RiskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunIcerikveRiskBilgileris", x => new { x.IcerikId, x.RiskId });
                    table.ForeignKey(
                        name: "FK_UrunIcerikveRiskBilgileris_UrunVeIceriklers_IcerikId",
                        column: x => x.IcerikId,
                        principalTable: "UrunVeIceriklers",
                        principalColumn: "IcerikId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KayitTipleriKayitTipiId",
                table: "AspNetUsers",
                column: "KayitTipleriKayitTipiId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Barkodlars_UrunId",
                table: "Barkodlars",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_KullanicilarUrunler_UrunsUrunId",
                table: "KullanicilarUrunler",
                column: "UrunsUrunId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciVeFavorilers_KategoriId",
                table: "KullaniciVeFavorilers",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciVeFavorilers_UrunId",
                table: "KullaniciVeFavorilers",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciVeKaraListes_IceriklerId",
                table: "KullaniciVeKaraListes",
                column: "IceriklerId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciVeKaraListes_KullaniciId",
                table: "KullaniciVeKaraListes",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciVeKaraListes_UrunId",
                table: "KullaniciVeKaraListes",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramIzinleris_KullaniciId",
                table: "ProgramIzinleris",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_RisklerUrunler_UrunsUrunId",
                table: "RisklerUrunler",
                column: "UrunsUrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UreticiveUrunlers_KategoriId",
                table: "UreticiveUrunlers",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_UreticiveUrunlers_UrunId",
                table: "UreticiveUrunlers",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunAramalars_BarkodNoNavigationBarkodNo",
                table: "UrunAramalars",
                column: "BarkodNoNavigationBarkodNo");

            migrationBuilder.CreateIndex(
                name: "IX_UrunAramalars_KategoriId",
                table: "UrunAramalars",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_KategoriId",
                table: "Urunlers",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_UreticiId",
                table: "Urunlers",
                column: "UreticiId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_UrunBarkod",
                table: "Urunlers",
                column: "UrunBarkod");

            migrationBuilder.CreateIndex(
                name: "IX_UrunPaylasmas_UrunId",
                table: "UrunPaylasmas",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunRiskRenkleriUrunler_UrunsUrunId",
                table: "UrunRiskRenkleriUrunler",
                column: "UrunsUrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunTakipleris_KullaniciId",
                table: "UrunTakipleris",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunTakipleris_UrunId",
                table: "UrunTakipleris",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunVeIceriklers_KategoriId",
                table: "UrunVeIceriklers",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunVeIceriklers_UrunId",
                table: "UrunVeIceriklers",
                column: "UrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Barkodlars_Urunlers_UrunId",
                table: "Barkodlars",
                column: "UrunId",
                principalTable: "Urunlers",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barkodlars_Urunlers_UrunId",
                table: "Barkodlars");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "KullanicilarUrunler");

            migrationBuilder.DropTable(
                name: "KullaniciVeFavorilers");

            migrationBuilder.DropTable(
                name: "KullaniciVeKaraListes");

            migrationBuilder.DropTable(
                name: "ProgramIzinleris");

            migrationBuilder.DropTable(
                name: "RisklerUrunler");

            migrationBuilder.DropTable(
                name: "UreticiveUrunlers");

            migrationBuilder.DropTable(
                name: "UrunAramalars");

            migrationBuilder.DropTable(
                name: "UrunIcerikveRiskBilgileris");

            migrationBuilder.DropTable(
                name: "UrunPaylasmas");

            migrationBuilder.DropTable(
                name: "UrunRiskRenkleriUrunler");

            migrationBuilder.DropTable(
                name: "UrunTakipleris");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Risklers");

            migrationBuilder.DropTable(
                name: "UrunVeIceriklers");

            migrationBuilder.DropTable(
                name: "UrunRiskRenkleris");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "KayitTipleris");

            migrationBuilder.DropTable(
                name: "Urunlers");

            migrationBuilder.DropTable(
                name: "Barkodlars");

            migrationBuilder.DropTable(
                name: "Kategorilers");

            migrationBuilder.DropTable(
                name: "Ureticilers");
        }
    }
}
