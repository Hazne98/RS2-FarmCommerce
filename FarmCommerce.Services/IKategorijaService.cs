using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmCommerce.Model;
using FarmCommerce.Model.Requests;

namespace FarmCommerce.Services
{
    public interface IKategorijaService
    {
        IList<Kategorija> Get();
    }
}
