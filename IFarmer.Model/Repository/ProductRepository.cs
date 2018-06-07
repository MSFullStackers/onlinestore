using IFarmer.Entity;
using RS2.Core;

namespace IFarmer.Model
{
    public interface IProductRepository : IRepositoryBase<Product, int>
    {
    }

   [DmComponent(Lifetime = Lifetime.Singleton, Target = typeof(IProductRepository))]
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}