using BL.DTOs.NewsDTOs;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly INewsService _service;
        public HomeController(INewsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<GetNewsDTO> news = await _service.GetAllNewsAsync();
            return View(news);
        }
    }
}
