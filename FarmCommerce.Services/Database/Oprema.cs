using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Oprema
{
    public int OpremaId { get; set; }

    public string ImeOpreme { get; set; } = null!;

    public string? Opis { get; set; }

    public int KategorijaId { get; set; }

    public decimal CijenaPoDanu { get; set; }

    public int KolicinaNaStanju { get; set; }

    public string? SlikaOpreme { get; set; }

    public int ProizvodjacId { get; set; }

    public int LokacijaId { get; set; }

    public virtual Kategorija Kategorija { get; set; } = null!;

    public virtual Lokacija Lokacija { get; set; } = null!;

    public virtual Proizvodjac Proizvodjac { get; set; } = null!;
}
