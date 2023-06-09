﻿using AutoMapper;
using FarmCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services.ProizvodiStateMachine
{
    public class ActiveProductState : BaseState
    {
        public ActiveProductState(IServiceProvider serviceProvider, Database.FarmCommerceContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
        }

        //public override Task<Proizvod> Activate(int id)
        //{
        //    return base.Activate(id);
        //}

        public override async Task<Proizvod> Hide(int id)
        {
            var set = _context.Set<Database.Proizvod>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "draft";

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Proizvod>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Hide");

            return list;
        }
    }
}
