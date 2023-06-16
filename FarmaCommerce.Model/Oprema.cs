using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model
{
    public class Oprema
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

    }
}
