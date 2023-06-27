using Application.Accounts.Commands;
using Application.Accounts.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, string>().ConstructUsing(str => (str ?? "").Trim());

            CreateMap<CreateAccount, AppUser>()
                .ForMember(q => q.UserName, q => q.MapFrom(q => q.UserEmail))
                .ForMember(q => q.Email, q => q.MapFrom(q => q.UserEmail))
                .ForMember(q => q.NormalizedUserName, q => q.MapFrom(q => q.UserEmail.ToLower()))
                .ForMember(q => q.NormalizedEmail, q => q.MapFrom(q => q.UserEmail.ToLower()));

            CreateMap<AppUser, GetAllAcoountDTO>()
                .ForMember(q => q.UserName, q => q.MapFrom(q => q.UserName))
                .ForMember(q => q.UserEmail, q => q.MapFrom(q => q.Email));

        }
    }
}
