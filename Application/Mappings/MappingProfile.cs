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
        CreateMap<UserUpdateModel, User>();
        
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
        
        CreateMap<Fish, FishViewModel>();
        CreateMap<FishCreateModel, Fish>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.FishCategories, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => FishStatuses.Active));;
        CreateMap<FishUpdateModel, Fish>();
        
        CreateMap<FishCategoryCreateModel, FishCategory>()
            .ForMember(dest => dest.FishId, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));

        CreateMap<FishCategory, FishCategoryViewModel>();
        
        CreateMap<Category, CategoryViewModel>();
    }
}