using System.Data.Entity;
using HopCompost_DataAccess.Base;

namespace HopCompost_DataAccess
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }

    // ReSharper disable once InconsistentNaming
    public partial class HopCompost_DbEntities1 : IDbContext
    {

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        
        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}