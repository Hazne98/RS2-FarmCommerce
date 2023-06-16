using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model.Requests
{
    public class ProizvodUpdateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ime proizvoda je obavezan")]
        public string ImeProizvoda { get; set; } = null!;

        public string? Opis { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Cijena { get; set; }

        public int KolicinaNaStanju { get; set; }

        public string SlikaProizvoda { get; set; } = null!;
    }
}
