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

public class RoleService : BaseService, IRoleService
{
    private readonly IRoleRepository _batchRepository;

    public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _batchRepository = unitOfWork.Role;
    }

    public async Task<IActionResult> GetRoles()
    {
        var deliveryCompanies = await _unitOfWork.Role.GetAll()
            .OrderByDescending(x => x.CreateAt)
            .ProjectTo<RoleViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    }

    public async Task<IActionResult> GetRole(Guid id)
    {
        var batch = await _unitOfWork.Role.Where(x => x.Id.Equals(id))
            .ProjectTo<RoleViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return new OkObjectResult(batch);
    }

    public async Task<IActionResult> CreateRole(RoleCreateModel model)
    {
        var batch = _mapper.Map<Role>(model);
        _batchRepository.Add(batch);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetRole(batch.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateRole(Guid id, RoleUpdateModel model)
    {
        var batch = _mapper.Map<Role>(model);
        _batchRepository.Update(batch);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetRole(batch.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteRole(Guid id)
    {
        var batch = await _batchRepository
            .Where(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        if (batch == null)
        {
            return new BadRequestResult();
        }
        _batchRepository.Delete(batch);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? new NoContentResult() : new BadRequestResult();
    }
}