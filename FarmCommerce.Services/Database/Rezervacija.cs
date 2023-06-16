using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Rezervacija
{
    public int RezervacijaId { get; set; }

    public int LokacijaId { get; set; }

    public int KorisnikId { get; set; }

    public double Cijena { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DatumPocetka { get; set; }

    public DateTime DatumZavrsetka { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual Lokacija Lokacija { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
