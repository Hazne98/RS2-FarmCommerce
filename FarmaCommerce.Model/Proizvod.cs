using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model
{
    public class Proizvod
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
    }
}
