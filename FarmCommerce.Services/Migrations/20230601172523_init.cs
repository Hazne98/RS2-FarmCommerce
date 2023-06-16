using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmCommerce.Services.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kategori__6C3B8FEE95792C7A", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Lozinka = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Korisnicko_ime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Grad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LozinkaHash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LozinkaSalt = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__80B06D410E14514F", x => x.KorisnikId);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    LokacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Slika = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lokacija__49DE2CCA29B98E57", x => x.LokacijaId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    ProizvodjacId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeProizvodjaca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Grad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Broj_mobitela = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Logo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proizvod__3722E595436F76AB", x => x.ProizvodjacId);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uloge__DCAB23CBD9166811", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LokacijaId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Datum_pocetka = table.Column<DateTime>(type: "date", nullable: false),
                    Datum_zavrsetka = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rezervac__CABA44DD69561097", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_Rezervacija_Lokacija",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "LokacijaId");
                });

            migrationBuilder.CreateTable(
                name: "Oprema",
                columns: table => new
                {
                    OpremaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeOpreme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorijaId = table.Column<int>(type: "int", nullable: false),
                    Cijena_po_danu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kolicina_na_stanju = table.Column<int>(type: "int", nullable: false),
                    Slika_Opreme = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProizvodjacId = table.Column<int>(type: "int", nullable: false),
                    LokacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Oprema__5C2EDCD1368C7B19", x => x.OpremaId);
                    table.ForeignKey(
                        name: "FK__Oprema__Kategori__48CFD27E",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaId");
                    table.ForeignKey(
                        name: "FK__Oprema__Lokacija__4AB81AF0",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "LokacijaId");
                    table.ForeignKey(
                        name: "FK__Oprema__Proizvod__49C3F6B7",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjac",
                        principalColumn: "ProizvodjacId");
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeProizvoda = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Opis = table.Column<string>(type: "text", nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Kolicina_na_stanju = table.Column<int>(type: "int", nullable: false),
                    Slika_Proizvoda = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ProizvodjacId = table.Column<int>(type: "int", nullable: false),
                    KategorijaId = table.Column<int>(type: "int", nullable: false),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proizvod__21A8BFF872E17312", x => x.ProizvodId);
                    table.ForeignKey(
                        name: "FK_Proizvod_Kategorija",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaId");
                    table.ForeignKey(
                        name: "FK__Proizvod__Proizv__29572725",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjac",
                        principalColumn: "ProizvodjacId");
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    KorisnikUlogaId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnic__1608726E077EA99B", x => x.KorisnikUlogaId);
                    table.ForeignKey(
                        name: "FK__Korisnici__Koris__5EBF139D",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK__Korisnici__Uloga__5FB337D6",
                        column: x => x.UlogaId,
                        principalTable: "Uloge",
                        principalColumn: "UlogaId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Datum_placanja = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status_placanja = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Nacin_placanja = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RezervacijaId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__9B556A380935D356", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK__Payment__Korisni__440B1D61",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK__Payment__Rezerva__4316F928",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "RezervacijaId");
                });

            migrationBuilder.CreateTable(
                name: "Favoriti",
                columns: table => new
                {
                    FavoritId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favoriti__C32DB3CC3F9A80DC", x => x.FavoritId);
                    table.ForeignKey(
                        name: "FK_Favoriti_Korisnik",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_Favoriti_Proizvod",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodId");
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Datum_narudzbe = table.Column<DateTime>(type: "date", nullable: false),
                    Status_narudzbe = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Narudzba__FBEC1377BCC6D1CD", x => x.NarudzbaId);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_Narudzba_Proizvod",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodId");
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    RecenzijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProizvodId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recenzij__D36C607035DAF4D0", x => x.RecenzijaId);
                    table.ForeignKey(
                        name: "FK__Recenzija__Koris__300424B4",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK__Recenzija__Proiz__2F10007B",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoriti_KorisnikId",
                table: "Favoriti",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoriti_ProizvodId",
                table: "Favoriti",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisnikId",
                table: "KorisniciUloge",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaId",
                table: "KorisniciUloge",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "UQ__Korisnik__5F72E44814CD3ABF",
                table: "Korisnik",
                column: "Korisnicko_ime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KorisnikId",
                table: "Narudzba",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_ProizvodId",
                table: "Narudzba",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Oprema_KategorijaId",
                table: "Oprema",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oprema_LokacijaId",
                table: "Oprema",
                column: "LokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oprema_ProizvodjacId",
                table: "Oprema",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_KorisnikId",
                table: "Payment",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_RezervacijaId",
                table: "Payment",
                column: "RezervacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KategorijaId",
                table: "Proizvod",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_ProizvodjacId",
                table: "Proizvod",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_KorisnikId",
                table: "Recenzija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_ProizvodId",
                table: "Recenzija",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikId",
                table: "Rezervacija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_LokacijaId",
                table: "Rezervacija",
                column: "LokacijaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoriti");

            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Oprema");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Proizvodjac");
        }
    }
}
