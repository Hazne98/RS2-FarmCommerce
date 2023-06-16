using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Services;
using FarmCommerce.Services.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace FarmCommerce.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class OpremaController : BaseController<Model.Oprema, BaseSearchObject>
    {
        public OpremaController(ILogger<BaseController<Model.Oprema, BaseSearchObject>> logger, IService<Model.Oprema, BaseSearchObject> service) : base(logger, service)
        {
        }
    }
}
