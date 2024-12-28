using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OneToManyCRUD.Core.Entities.Common;

namespace OneToManyCRUD.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
