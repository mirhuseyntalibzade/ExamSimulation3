using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.NewsDTOs
{
    public class UpdateNewsDTO
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<SelectListItem> Categories { get; set; }
    }
}
