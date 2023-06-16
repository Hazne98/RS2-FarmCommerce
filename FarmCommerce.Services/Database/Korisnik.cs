using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Korisnik
{
    public int KorisnikId { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string Lozinka { get; set; } = null!;

    public string KorisnickoIme { get; set; } = null!;

    public string Adresa { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[]? Slika { get; set; }

    public string Grad { get; set; } = null!;

    public string LozinkaHash { get; set; } = null!;

    public string LozinkaSalt { get; set; } = null!;

    public virtual ICollection<Favoriti> Favoritis { get; set; } = new List<Favoriti>();

    public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; } = new List<KorisniciUloge>();

    public virtual ICollection<Narudzba> Narudzbas { get; set; } = new List<Narudzba>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Recenzija> Recenzijas { get; set; } = new List<Recenzija>();

    public virtual ICollection<Rezervacija> Rezervacijas { get; set; } = new List<Rezervacija>();
}
