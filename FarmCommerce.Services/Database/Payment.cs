using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int Kolicina { get; set; }

    public decimal Cijena { get; set; }

    public DateTime DatumPlacanja { get; set; }

    public string StatusPlacanja { get; set; } = null!;

    public string NacinPlacanja { get; set; } = null!;

    public int RezervacijaId { get; set; }

    public int KorisnikId { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual Rezervacija Rezervacija { get; set; } = null!;
}
