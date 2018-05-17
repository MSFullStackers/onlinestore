using Stwo.Core;

namespace Online.Model
{
    public partial class Products : EntityBase<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
