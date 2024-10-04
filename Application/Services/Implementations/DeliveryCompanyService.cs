using Application.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.EntityRepositories.Interfaces;
using Data.UnitOfWorks.Interfaces;
using Domain.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementations;

public class DeliveryCompanyService: BaseService, IDeliveryCompanyService
{
    private readonly IDeliveryCompanyRepository _deliveryCompanyRepository;
    public DeliveryCompanyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _deliveryCompanyRepository = unitOfWork.DeliveryCompany;
    }

    public async Task<IActionResult> GetDeliveryCompanies()
    {
        var deliveryCompanies = await _unitOfWork.DeliveryCompany.GetAll()
            .ProjectTo<DeliveryCompanyViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    }
}