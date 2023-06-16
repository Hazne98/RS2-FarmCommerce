using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Recenzija
{
    public int RecenzijaId { get; set; }

    public int Ocjena { get; set; }

    public string Komentar { get; set; } = null!;

    public DateTime Datum { get; set; }

    public int ProizvodId { get; set; }

    public int KorisnikId { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual Proizvod Proizvod { get; set; } = null!;
}
