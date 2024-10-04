using Data.EntityRepositories.Interfaces;

namespace Data.UnitOfWorks.Interfaces;

public interface IUnitOfWork
{
    public IDeliveryCompanyRepository DeliveryCompany { get; }
    
    void BeginTransaction();
    
    void Commit();
    
    void Rollback();
    
    void Dispose();
    
    Task<int> SaveChangesAsync();
}