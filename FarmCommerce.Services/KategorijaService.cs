using FarmCommerce.Model;
using FarmCommerce.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public class KategorijaService : IKategorijaService
    {
        FarmCommerceContext _context;

        public KategorijaService(FarmCommerceContext context)
        { 
            _context = context;
        }



        List<Model.Kategorija> kategorijas = new List<Model.Kategorija>()
        {
            new Model.Kategorija()
            {
                KategorijaId = 1,
                Naziv = "Nesto",
            }
        };

        public IList<Model.Kategorija> Get()
        {
            //var list = _context.Kategorijas.ToList();
            return kategorijas;
        }
    }
}
