using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public interface IKorisnikService : ICRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        public Model.Korisnik Login(string username, string password);
    }
}
