using AutoMapper;
using OTR_integration_Data.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.AutoMapperProfiles
{
    /// <summary>
    /// Automapper implementation to mapping functions between Recipients objects.
    /// </summary>
    public class RecipientsProfiles : Profile
    {
        public RecipientsProfiles()
        {
            // Source -> Target
            CreateMap<RecipientCreateRequest, RecipientSearchRequest>()
                .ForMember(
                    target => target.Email,
                    opt => opt.MapFrom(source => source.Email)
                );
        }
    }
}
