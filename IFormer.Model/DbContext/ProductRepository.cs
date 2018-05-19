using Stwo.Core;

namespace Online.Model
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