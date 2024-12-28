using OneToManyCRUD.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OneToManyCRUD.Core.Entities
{
    public class Tags:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
