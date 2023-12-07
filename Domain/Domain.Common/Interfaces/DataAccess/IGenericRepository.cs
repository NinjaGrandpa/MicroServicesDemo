namespace Domain.Common.Interfaces.DataAccess;

// where T : class; kräver att den generiska typen kan initieras av 'new'
// Generiskt för att fungera för flera olika typer

public interface IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
{
    Task<TEntity> GetByIdAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TId id);
}
