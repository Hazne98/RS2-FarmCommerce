using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Favoriti
{
    public int FavoritId { get; set; }

    public int KorisnikId { get; set; }

    public int ProizvodId { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual Proizvod Proizvod { get; set; } = null!;
}
