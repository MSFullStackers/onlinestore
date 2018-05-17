using Stwo.Core;

namespace Online.Model
{
    public interface IProductRepository : IGetRepository<Products, int>
    {
    }

   [DmComponent(Lifetime = Lifetime.Singleton, Target = typeof(IProductRepository))]
    public class ProductRepository : RepositoryBase<Products, int>, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}