

using MedicalAppointmentApp.Domain.Result;
using System.Linq.Expressions;

namespace MedicalAppointmentApp.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<OperationResult> Save(TEntity entity);
        Task<OperationResult> Update(TEntity entity);
        Task<OperationResult> Remove(TEntity entity);
        Task<OperationResult> GetAll();
       // Task<OperationResult> GetAll(Expression<Func<TEntity, bool>> filter);
        Task<OperationResult> GetEntityBy(int Id);
        Task<OperationResult> Exists(Expression<Func<TEntity, bool>> filter);
    }


}
