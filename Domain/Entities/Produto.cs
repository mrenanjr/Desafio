using Domain.Common;

namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
