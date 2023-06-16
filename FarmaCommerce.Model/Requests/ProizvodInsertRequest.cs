using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model.Requests
{
    public class ProizvodInsertRequest
    {
        [Required(AllowEmptyStrings = false)] //ne moze se poslat u nazivu samo space
        public string ImeProizvoda { get; set; } = null!;

        public string? Opis { get; set; }

        public int KategorijaId { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Cijena { get; set; }

        public int KolicinaNaStanju { get; set; }

        public string SlikaProizvoda { get; set; } = null!;

        public int ProizvodjacId { get; set; }

    }
}
