using AutoMapper;
using Common.Constants;
using Domain.Entities;
using Domain.Models.Authorization;
using Domain.Models.Creates;
using Domain.Models.Views;

namespace Application.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<DeliveryCompany, DeliveryCompanyViewModel>();
        CreateMap<DeliveryCompanyCreateModel, DeliveryCompany>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => DeliveryCompanyStatuses.Active));
    }
}