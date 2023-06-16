using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Narudzba
{
    public int NarudzbaId { get; set; }

    public int Kolicina { get; set; }

    public decimal Cijena { get; set; }

    public DateTime DatumNarudzbe { get; set; }

    public string StatusNarudzbe { get; set; } = null!;

    public int KorisnikId { get; set; }

    public int ProizvodId { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual Proizvod Proizvod { get; set; } = null!;
}
