using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Kategorija
{
    public int KategorijaId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Oprema> Opremas { get; set; } = new List<Oprema>();

    public virtual ICollection<Proizvod> Proizvods { get; set; } = new List<Proizvod>();
}
