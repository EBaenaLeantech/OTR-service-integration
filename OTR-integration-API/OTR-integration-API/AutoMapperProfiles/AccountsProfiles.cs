using AutoMapper;
using OTR_integration_Data.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.AutoMapperProfiles
{
    public class AccountsProfiles : Profile
    {
        public AccountsProfiles()
        {
            // Source -> Target
            CreateMap<AccountCardCreateRequest, AccountCardCreateInterchecksRequest>()
                .ForMember(
                    target => target.Type,
                    opt => opt.MapFrom(source => source.Type)
                )
                .ForMember(
                    target => target.AccountNumber,
                    opt => opt.MapFrom(source => Convert.ToInt64(source.AccountNumber))
                )
                .ForMember(
                    target => target.ExpirationDate,
                    opt => opt.MapFrom(source => source.ExpirationDate)
                )
                .ForMember(
                    target => target.ZipCode,
                    opt => opt.MapFrom(source => Convert.ToInt32(source.ZipCode))
                )
                .ForMember(
                    target => target.SecurityCode,
                    opt => opt.MapFrom(source => Convert.ToInt32(source.SecurityCode))
                )
                .ForMember(
                    target => target.PushRequired,
                    opt => opt.MapFrom(source => source.PushRequired)
                )
                .ForMember(
                    target => target.PullRequired,
                    opt => opt.MapFrom(source => source.PullRequired)
                );
        }
    }
}
