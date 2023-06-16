using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Proizvodjac
{
    public int ProizvodjacId { get; set; }

    public string ImeProizvodjaca { get; set; } = null!;

    public string Adresa { get; set; } = null!;

    public string Grad { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string BrojMobitela { get; set; } = null!;

    public string? Logo { get; set; }

    public virtual ICollection<Oprema> Opremas { get; set; } = new List<Oprema>();

    public virtual ICollection<Proizvod> Proizvods { get; set; } = new List<Proizvod>();
}
