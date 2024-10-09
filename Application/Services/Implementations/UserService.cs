﻿using Application.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Constants;
using Data.EntityRepositories.Interfaces;
using Data.UnitOfWorks.Interfaces;
using Domain.Entities;
using Domain.Models.Creates;
using Domain.Models.Update;
using Domain.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementations;

public class UserService : BaseService, IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _userRepository = unitOfWork.User;
    }

    public async Task<IActionResult> GetUsers()
    {
        var deliveryCompanies = await _unitOfWork.User.GetAll()
            .OrderByDescending(x => x.CreateAt)
            .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    }
    
    public async Task<IActionResult> GetCustomers()
    {
        var deliveryCompanies = await _unitOfWork.User.Where(x => x.Role.Name.Equals(UserRoles.Customer))
            .OrderByDescending(x => x.CreateAt)
            .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    }

    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _unitOfWork.User.Where(x => x.Id.Equals(id))
            .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return new OkObjectResult(user);
    }
    
    public async Task<IActionResult> CreateUser(UserCreateModel model)
    {
        var user = _mapper.Map<User>(model);
        _userRepository.Add(user);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetUser(user.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateUser(Guid id, UserUpdateModel model)
    {
        var user = _mapper.Map<User>(model);
        _userRepository.Update(user);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetUser(user.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var user = await _userRepository
            .Where(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        if (user == null)
        {
            return new BadRequestResult();
        }
        _userRepository.Delete(user);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? new NoContentResult() : new BadRequestResult();
    }
}