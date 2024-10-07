using Application.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.EntityRepositories.Interfaces;
using Data.UnitOfWorks.Interfaces;
using Domain.Entities;
using Domain.Models.Creates;
using Domain.Models.Update;
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
            .OrderByDescending(x => x.CreateAt)
            .ProjectTo<DeliveryCompanyViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    } 
    
    public async Task<IActionResult> GetDeliveryCompany(Guid id)
    {
        var deliveryCompany = await _unitOfWork.DeliveryCompany.Where(x => x.Id.Equals(id))
            .ProjectTo<DeliveryCompanyViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return new OkObjectResult(deliveryCompany);
    } 
    
    public async Task<IActionResult> CreateDeliveryCompany(DeliveryCompanyCreateModel model)
    {
        var deliveryCompany = _mapper.Map<DeliveryCompany>(model);
        _deliveryCompanyRepository.Add(deliveryCompany);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetDeliveryCompany(deliveryCompany.Id) : new BadRequestResult();
    }
    
    public async Task<IActionResult> UpdateDeliveryCompany(Guid id, DeliveryCompanyUpdateModel model)
    {
        var deliveryCompany = _mapper.Map<DeliveryCompany>(model);
        _deliveryCompanyRepository.Update(deliveryCompany);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetDeliveryCompany(deliveryCompany.Id) : new BadRequestResult();
    }
    
    public async Task<IActionResult> DeleteDeliveryCompany(Guid id)
    {
        var deliveryCompany = await _deliveryCompanyRepository
            .Where(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        if (deliveryCompany == null)
        {
            return new BadRequestResult();
        }
        _deliveryCompanyRepository.Delete(deliveryCompany);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? new NoContentResult() : new BadRequestResult();
    }
}