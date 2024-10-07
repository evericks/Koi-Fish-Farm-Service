using Data.EntityRepositories.Interfaces;

namespace Data.UnitOfWorks.Interfaces;

public interface IUnitOfWork
{
    public IDeliveryCompanyRepository DeliveryCompany { get; }
    public IBatchRepository Batch { get; }
    public ICategoryRepository Category { get; }
    public IDriverRepository Driver { get; }
    public IFeedbackRepository Feedback { get; }
    public IFishCategoryRepository FishCategory { get; }
    public IFishRepository Fish { get; }
    public IOrderDetailRepository OrderDetail { get; }
    public IOrderRepository Order { get; }
    public IRoleRepository Role { get; }
    public IUserRepository User { get; }
    
    void BeginTransaction();
    
    void Commit();
    
    void Rollback();
    
    void Dispose();
    
    Task<int> SaveChangesAsync();
}