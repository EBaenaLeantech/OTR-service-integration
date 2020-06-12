using AutoMapper;
using OTR_integration_WebAPI.Contracts.Requests;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTR_integration_WebAPI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Transaction Request to Itercheck Request
            CreateMap<TransactionDebitRequest, TransactionDebitIntercheckRequest>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => "DEBIT")
                )
                .ForMember(
                    dest => dest.AccountId,
                    opt => opt.MapFrom(src => src.AccountId)
                )
                .ForMember(
                    dest => dest.RequestReferenceId,
                    opt => opt.MapFrom(src => src.RequestReferenceId)
                )
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.MapFrom(src => src.Amount)
                );

            CreateMap<TransactionCreditRequest, TransactionCreditIntercheckRequest>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => "CREDIT")
                )
                .ForMember(
                    dest => dest.Method,
                    opt => opt.MapFrom(src => "INSTANT_DEPOSIT")
                )
                .ForMember(
                    dest => dest.AccountId,
                    opt => opt.MapFrom(src => src.AccountId)
                )
                .ForMember(
                    dest => dest.RequestReferenceId,
                    opt => opt.MapFrom(src => src.RequestReferenceId)
                )
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.MapFrom(src => src.Amount)
                );
        }

    }
}