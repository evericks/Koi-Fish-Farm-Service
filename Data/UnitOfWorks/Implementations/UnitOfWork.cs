using Data.EntityRepositories.Implementations;
using Data.EntityRepositories.Interfaces;
using Data.UnitOfWorks.Interfaces;
using Domain.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.UnitOfWorks.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly KoiFishFarmContext _context;
    private IDbContextTransaction _transaction = null!;

    public UnitOfWork(KoiFishFarmContext context)
    {
        _context = context;
    }

    private IDeliveryCompanyRepository? _deliveryCompany;

    public IDeliveryCompanyRepository DeliveryCompany
    {
        get { return _deliveryCompany ??= new DeliveryCompanyRepository(_context); }
    }

    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        try
        {
            _transaction.Commit();
        }
        finally
        {
            _transaction.Dispose();
            _transaction = null!;
        }
    }

    public void Rollback()
    {
        try
        {
            _transaction.Rollback();
        }
        finally
        {
            _transaction.Dispose();
            _transaction = null!;
        }
    }

    public void Dispose()
    {
        _transaction.Dispose();
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}