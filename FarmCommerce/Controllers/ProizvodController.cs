﻿using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Services;
using FarmCommerce.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace FarmCommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodController : BaseCRUDController<Model.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>
    {
        public ProizvodController(ILogger<BaseController<Model.Proizvod, ProizvodSearchObject>> logger, IProizvodService service ) : base(logger, service)
        {
        }

        [HttpPut("{id}/activate")]
        public virtual async Task<Model.Proizvod> Activate(int id)
        {
            return await (_service as IProizvodService).Activate(id);
        }

        [HttpPut("{id}/hide")]
        public virtual async Task<Model.Proizvod> Hide(int id)
        {
            return await (_service as IProizvodService).Hide(id);
        }

        [HttpGet("{id}/allowedActions")]
        public virtual async Task<List<string>> AllowedActions(int id)
        {
            return await (_service as IProizvodService).AllowedActions(id);
        }
    }
}
