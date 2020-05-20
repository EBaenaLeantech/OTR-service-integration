using AutoMapper;
using OTR_integration_API.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.AutoMapperProfiles
{
    public class RecipientsProfiles : Profile
    {
        public RecipientsProfiles()
        {
            // Source -> Target
            CreateMap<RecipientCreateRequest, RecipientSearchRequest>()
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                );
        }
    }
}
