using RS2.Core;

namespace IFarmer.Entity
{
    public partial class Product : EntityBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }
    }
}
