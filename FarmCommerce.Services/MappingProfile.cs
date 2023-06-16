using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<Model.Requests.KorisnikInsertRequest, Database.Korisnik>();
            CreateMap<Model.Requests.KorisnikUpdateRequest, Database.Korisnik>();

            CreateMap<Database.Proizvod, Model.Proizvod>();
            CreateMap<Model.Requests.ProizvodInsertRequest, Database.Proizvod>();
            CreateMap<Model.Requests.ProizvodUpdateRequest, Database.Proizvod>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Database.Oprema, Model.Oprema>();

            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>();

            CreateMap<Database.Uloge, Model.Uloge>();
        }
    }

    //public UserProfile()
    //{
        //CreateMap<User, UserViewModel>();
    //}
}
 