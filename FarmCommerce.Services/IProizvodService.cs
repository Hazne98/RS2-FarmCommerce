using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public interface IProizvodService : ICRUDService<Model.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>
    {
        Task<Proizvod> Activate(int id);
        Task<Proizvod> Hide(int id);
        Task<List<string>> AllowedActions(int id);
    }
}
