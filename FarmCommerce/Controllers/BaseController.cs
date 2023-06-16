using FarmCommerce.Model;
using FarmCommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmCommerce.Controllers
{
    //API CONTORLLER se nalazi direkt na odredjenom kontroleru
    [Route("[controller]")]
    [Authorize]
    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        protected readonly IService<T, TSearch> _service;
        protected readonly ILogger<BaseController<T, TSearch>> _logger;

        public BaseController(ILogger<BaseController<T, TSearch>> logger, IService<T, TSearch> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet()]
        public async Task<PageResult<T>> Get([FromQuery]TSearch? search = null) //task se awaita
        {
            return await _service.Get(search);
        }

        [HttpGet("{id}")]
        public async Task<T> GetById(int id) //task se awaita
        {
            return await _service.GetById(id);
        }
    }
}
