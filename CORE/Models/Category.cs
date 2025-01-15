using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public ICollection<News>? News { get; set; }
    }
}
