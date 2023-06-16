using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Lokacija
{
    public int LokacijaId { get; set; }

    public string Grad { get; set; } = null!;

    public string Adresa { get; set; } = null!;

    public string? Slika { get; set; }

    public virtual ICollection<Oprema> Opremas { get; set; } = new List<Oprema>();

    public virtual ICollection<Rezervacija> Rezervacijas { get; set; } = new List<Rezervacija>();
}
