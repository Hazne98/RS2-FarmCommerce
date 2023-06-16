using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FarmCommerce.Services.Database;

public partial class FarmCommerceContext : DbContext
{
    public FarmCommerceContext()
    {
    }

    public FarmCommerceContext(DbContextOptions<FarmCommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Favoriti> Favoritis { get; set; }

    public virtual DbSet<Kategorija> Kategorijas { get; set; }

    public virtual DbSet<KorisniciUloge> KorisniciUloges { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<Lokacija> Lokacijas { get; set; }

    public virtual DbSet<Narudzba> Narudzbas { get; set; }

    public virtual DbSet<Oprema> Opremas { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Proizvod> Proizvods { get; set; }

    public virtual DbSet<Proizvodjac> Proizvodjacs { get; set; }

    public virtual DbSet<Recenzija> Recenzijas { get; set; }

    public virtual DbSet<Rezervacija> Rezervacijas { get; set; }

    public virtual DbSet<Uloge> Uloges { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FarmCommerce;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favoriti>(entity =>
        {
            entity.HasKey(e => e.FavoritId).HasName("PK__Favoriti__C32DB3CC3F9A80DC");

            entity.ToTable("Favoriti");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Favoritis)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favoriti_Korisnik");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.Favoritis)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favoriti_Proizvod");
        });

        modelBuilder.Entity<Kategorija>(entity =>
        {
            entity.HasKey(e => e.KategorijaId).HasName("PK__Kategori__6C3B8FEE95792C7A");

            entity.ToTable("Kategorija");

            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KorisniciUloge>(entity =>
        {
            entity.HasKey(e => e.KorisnikUlogaId).HasName("PK__Korisnic__1608726E077EA99B");

            entity.ToTable("KorisniciUloge");

            entity.Property(e => e.KorisnikUlogaId).ValueGeneratedNever();
            entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisniciUloges)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Korisnici__Koris__5EBF139D");

            entity.HasOne(d => d.Uloga).WithMany(p => p.KorisniciUloges)
                .HasForeignKey(d => d.UlogaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Korisnici__Uloga__5FB337D6");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.KorisnikId).HasName("PK__Korisnik__80B06D410E14514F");

            entity.ToTable("Korisnik");

            entity.HasIndex(e => e.KorisnickoIme, "UQ__Korisnik__5F72E44814CD3ABF").IsUnique();

            entity.Property(e => e.Adresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Grad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KorisnickoIme)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Korisnicko_ime");
            entity.Property(e => e.Lozinka)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LozinkaHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LozinkaSalt)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prezime)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Lokacija>(entity =>
        {
            entity.HasKey(e => e.LokacijaId).HasName("PK__Lokacija__49DE2CCA29B98E57");

            entity.ToTable("Lokacija");

            entity.Property(e => e.Adresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Grad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Slika)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Narudzba>(entity =>
        {
            entity.HasKey(e => e.NarudzbaId).HasName("PK__Narudzba__FBEC1377BCC6D1CD");

            entity.ToTable("Narudzba");

            entity.Property(e => e.Cijena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DatumNarudzbe)
                .HasColumnType("date")
                .HasColumnName("Datum_narudzbe");
            entity.Property(e => e.StatusNarudzbe)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Status_narudzbe");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Narudzbas)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Narudzba_Korisnik");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.Narudzbas)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Narudzba_Proizvod");
        });

        modelBuilder.Entity<Oprema>(entity =>
        {
            entity.HasKey(e => e.OpremaId).HasName("PK__Oprema__5C2EDCD1368C7B19");

            entity.ToTable("Oprema");

            entity.Property(e => e.CijenaPoDanu)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Cijena_po_danu");
            entity.Property(e => e.ImeOpreme).HasMaxLength(50);
            entity.Property(e => e.KolicinaNaStanju).HasColumnName("Kolicina_na_stanju");
            entity.Property(e => e.SlikaOpreme)
                .HasMaxLength(200)
                .HasColumnName("Slika_Opreme");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Opremas)
                .HasForeignKey(d => d.KategorijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Oprema__Kategori__48CFD27E");

            entity.HasOne(d => d.Lokacija).WithMany(p => p.Opremas)
                .HasForeignKey(d => d.LokacijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Oprema__Lokacija__4AB81AF0");

            entity.HasOne(d => d.Proizvodjac).WithMany(p => p.Opremas)
                .HasForeignKey(d => d.ProizvodjacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Oprema__Proizvod__49C3F6B7");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A380935D356");

            entity.ToTable("Payment");

            entity.Property(e => e.Cijena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DatumPlacanja)
                .HasColumnType("datetime")
                .HasColumnName("Datum_placanja");
            entity.Property(e => e.NacinPlacanja)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nacin_placanja");
            entity.Property(e => e.StatusPlacanja)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Status_placanja");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Payments)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__Korisni__440B1D61");

            entity.HasOne(d => d.Rezervacija).WithMany(p => p.Payments)
                .HasForeignKey(d => d.RezervacijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__Rezerva__4316F928");
        });

        modelBuilder.Entity<Proizvod>(entity =>
        {
            entity.HasKey(e => e.ProizvodId).HasName("PK__Proizvod__21A8BFF872E17312");

            entity.ToTable("Proizvod");

            entity.Property(e => e.Cijena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ImeProizvoda)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.KolicinaNaStanju).HasColumnName("Kolicina_na_stanju");
            entity.Property(e => e.Opis).HasColumnType("text");
            entity.Property(e => e.SlikaProizvoda)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Slika_Proizvoda");

            entity.HasOne(d => d.KategorijaNavigation).WithMany(p => p.Proizvods)
                .HasForeignKey(d => d.KategorijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proizvod_Kategorija");

            entity.HasOne(d => d.Proizvodjac).WithMany(p => p.Proizvods)
                .HasForeignKey(d => d.ProizvodjacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proizvod__Proizv__29572725");
        });

        modelBuilder.Entity<Proizvodjac>(entity =>
        {
            entity.HasKey(e => e.ProizvodjacId).HasName("PK__Proizvod__3722E595436F76AB");

            entity.ToTable("Proizvodjac");

            entity.Property(e => e.Adresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BrojMobitela)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Broj_mobitela");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Grad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImeProizvodjaca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Logo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Recenzija>(entity =>
        {
            entity.HasKey(e => e.RecenzijaId).HasName("PK__Recenzij__D36C607035DAF4D0");

            entity.ToTable("Recenzija");

            entity.Property(e => e.Datum).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Recenzijas)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recenzija__Koris__300424B4");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.Recenzijas)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recenzija__Proiz__2F10007B");
        });

        modelBuilder.Entity<Rezervacija>(entity =>
        {
            entity.HasKey(e => e.RezervacijaId).HasName("PK__Rezervac__CABA44DD69561097");

            entity.ToTable("Rezervacija");

            entity.Property(e => e.DatumPocetka)
                .HasColumnType("date")
                .HasColumnName("Datum_pocetka");
            entity.Property(e => e.DatumZavrsetka)
                .HasColumnType("date")
                .HasColumnName("Datum_zavrsetka");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Rezervacijas)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rezervacija_Korisnik");

            entity.HasOne(d => d.Lokacija).WithMany(p => p.Rezervacijas)
                .HasForeignKey(d => d.LokacijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rezervacija_Lokacija");
        });

        modelBuilder.Entity<Uloge>(entity =>
        {
            entity.HasKey(e => e.UlogaId).HasName("PK__Uloge__DCAB23CBD9166811");

            entity.ToTable("Uloge");

            entity.Property(e => e.UlogaId).ValueGeneratedNever();
            entity.Property(e => e.Naziv).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
