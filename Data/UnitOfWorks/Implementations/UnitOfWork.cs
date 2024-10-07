using Data.EntityRepositories.Implementations;
using Data.EntityRepositories.Interfaces;
using Data.UnitOfWorks.Interfaces;
using Domain.Context;
using Microsoft.EntityFrameworkCore;
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
    
    private IBatchRepository? _batch;

    public IBatchRepository Batch
    {
        get { return _batch ??= new BatchRepository(_context); }
    }
    
    private ICategoryRepository? _cateogry;

    public ICategoryRepository Category
    {
        get { return _cateogry ??= new CategoryRepository(_context); }
    }
    
    private IDriverRepository? _driver;

    public IDriverRepository Driver
    {
        get { return _driver ??= new DriverRepository(_context); }
    }
    
    private IFeedbackRepository? _feedback;

    public IFeedbackRepository Feedback
    {
        get { return _feedback ??= new FeedbackRepository(_context); }
    }
    
    private IFishRepository? _fish;

    public IFishRepository Fish
    {
        get { return _fish ??= new FishRepository(_context); }
    }
    
    private IFishCategoryRepository? _fishCategory;

    public IFishCategoryRepository FishCategory
    {
        get { return _fishCategory ??= new FishCategoryRepository(_context); }
    }
    
    private IOrderRepository? _order;

    public IOrderRepository Order
    {
        get { return _order ??= new OrderRepository(_context); }
    }
    
    private IOrderDetailRepository? _orderDetail;

    public IOrderDetailRepository OrderDetail
    {
        get { return _orderDetail ??= new OrderDetailRepository(_context); }
    }
    
    private IRoleRepository? _role;

    public IRoleRepository Role
    {
        get { return _role ??= new RoleRepository(_context); }
    }
    
    private IUserRepository? _user;

    public IUserRepository User
    {
        get { return _user ??= new UserRepository(_context); }
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
        HandleTracking();
        return await _context.SaveChangesAsync();
    }
    
    private void HandleTracking()
    {
        var entries = _context.ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in entries)
        {
            var entity = entry.Entity;
            var entityType = entity.GetType();
            var now = DateTime.UtcNow;

            switch (entry.State)
            {
                case EntityState.Added:
                    SetProperty(entity, entityType, "CreateAt", now);
                    break;
                case EntityState.Modified:
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    private void SetProperty(object entity, Type entityType, string propertyName, object value)
    {
        var property = entityType.GetProperty(propertyName);
        if (property != null && property.CanWrite)
        {
            property.SetValue(entity, value);
        }
    }
}