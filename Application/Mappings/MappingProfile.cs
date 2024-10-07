using AutoMapper;
using Common.Constants;
using Domain.Entities;
using Domain.Models.Authorization;
using Domain.Models.Creates;
using Domain.Models.Update;
using Domain.Models.Views;

namespace Application.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserInformationModel>();
        CreateMap<User, UserViewModel>();
        
        CreateMap<Role, RoleViewModel>();
        CreateMap<RoleCreateModel, Role>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
        CreateMap<RoleUpdateModel, Role>();

        CreateMap<DeliveryCompany, DeliveryCompanyViewModel>();
        CreateMap<DeliveryCompanyCreateModel, DeliveryCompany>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => DeliveryCompanyStatuses.Active));
        CreateMap<DeliveryCompanyUpdateModel, DeliveryCompany>();
        
        CreateMap<Batch, BatchViewModel>();
        CreateMap<BatchCreateModel, Batch>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
        CreateMap<BatchUpdateModel, Batch>();
        
        CreateMap<FishCreateModel, Fish>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => DeliveryCompanyStatuses.Active));;
    }
}