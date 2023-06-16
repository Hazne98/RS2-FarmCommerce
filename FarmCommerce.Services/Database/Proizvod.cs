using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Proizvod
{
    public int ProizvodId { get; set; }

    public string ImeProizvoda { get; set; } = null!;

    public string? Opis { get; set; }

    public decimal Cijena { get; set; }

    public int KolicinaNaStanju { get; set; }

    public string SlikaProizvoda { get; set; } = null!;

    public int ProizvodjacId { get; set; }

    public int KategorijaId { get; set; }

    public string? StateMachine { get; set; }

    public virtual ICollection<Favoriti> Favoritis { get; set; } = new List<Favoriti>();

    public virtual Kategorija KategorijaNavigation { get; set; } = null!;

    public virtual ICollection<Narudzba> Narudzbas { get; set; } = new List<Narudzba>();

    public virtual Proizvodjac Proizvodjac { get; set; } = null!;

    public virtual ICollection<Recenzija> Recenzijas { get; set; } = new List<Recenzija>();
}
