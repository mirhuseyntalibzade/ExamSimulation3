using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstractions
{
    public interface ICategoryService
    {
        public Task<ICollection<SelectListItem>> SelectCategories();
    }
}
