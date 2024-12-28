using OneToManyCRUD.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OneToManyCRUD.Core.Entities
{
    public class ProductTag:BaseEntity
    {
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }

        public int TagId { get; set; }
        [JsonIgnore]
        public Tags Tag { get; set; }
    }
}
