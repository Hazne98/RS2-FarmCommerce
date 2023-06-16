using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Services;
using FarmCommerce.Services.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmCommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnikController : BaseCRUDController<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        public KorisnikController(ILogger<BaseController<Model.Korisnik, KorisnikSearchObject>> logger, IKorisnikService service) 
            : base(logger, service)
        {
        }

        [Authorize(Roles = "Administrator")]
        public override Task<Model.Korisnik> Insert([FromBody] KorisnikInsertRequest insert)
        {
            return base.Insert(insert);
        }

    } 
}
