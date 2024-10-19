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

public class DriverService : BaseService, IDriverService
{
    private readonly IDriverRepository _driverRepository;

    public DriverService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _driverRepository = unitOfWork.Driver;
    }

    public async Task<IActionResult> GetDrivers()
    {
        var deliveryCompanies = await _unitOfWork.Driver.GetAll()
            .OrderByDescending(x => x.CreateAt)
            .ProjectTo<DriverViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    }

    public async Task<IActionResult> GetDriver(Guid id)
    {
        var driver = await _unitOfWork.Driver.Where(x => x.Id.Equals(id))
            .ProjectTo<DriverViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return new OkObjectResult(driver);
    }

    public async Task<IActionResult> CreateDriver(DriverCreateModel model)
    {
        var driver = _mapper.Map<Driver>(model);
        _driverRepository.Add(driver);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetDriver(driver.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateDriver(Guid id, DriverUpdateModel model)
    {
        var driver = _mapper.Map<Driver>(model);
        _driverRepository.Update(driver);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetDriver(driver.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteDriver(Guid id)
    {
        var driver = await _driverRepository
            .Where(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        if (driver == null)
        {
            return new BadRequestResult();
        }
        _driverRepository.Delete(driver);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? new NoContentResult() : new BadRequestResult();
    }
}