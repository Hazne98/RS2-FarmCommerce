using AutoMapper;
using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchObjects;
using FarmCommerce.Services.Database;
using FarmCommerce.Services.ProizvodiStateMachine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FarmCommerce.Services
{
    public class ProizvodService : BaseCRUDService<Model.Proizvod, Database.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodUpdateRequest>, IProizvodService
    {
        public BaseState _baseState { get; set; }
        public ProizvodService(BaseState baseState, FarmCommerceContext context, IMapper mapper)
            : base(context, mapper)
        {
            _baseState = baseState;
        }

        public override IQueryable<Database.Proizvod> AddFilter(IQueryable<Database.Proizvod> query, ProizvodSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search?.ImeProizvoda))
            {
                query = query.Where(x => x.ImeProizvoda.StartsWith(search.ImeProizvoda));
            }

            if (!string.IsNullOrWhiteSpace(search?.FTS))
            {
                query = query.Where(x => x.ImeProizvoda.Contains(search.FTS));
            }

            return base.AddFilter(query, search);
        }

        public override Task<Model.Proizvod> Insert(ProizvodInsertRequest insert)
        {
            var state = _baseState.CreateState("initial");

            return state.Insert(insert);
        }

        public override async Task<Model.Proizvod> Update(int id, ProizvodUpdateRequest update)
        {
            var entity = await _context.Proizvods.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Update(id, update);
        }

        public async Task<Model.Proizvod> Activate(int id)
        {
            var entity = await _context.Proizvods.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Activate(id);
        }

        public async Task<Model.Proizvod> Hide(int id)
        {
            var entity = await _context.Proizvods.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Hide(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.Proizvods.FindAsync(id);

            var state = _baseState.CreateState(entity?.StateMachine ?? "initial");

            return await state.AllowedActions();
        }
    }
}
