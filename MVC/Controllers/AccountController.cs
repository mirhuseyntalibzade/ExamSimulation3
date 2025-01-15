using BL.DTOs.AuthDTOs;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        readonly IAuthService _service;
        public AccountController(IAuthService service)
        {
            _service = service;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO userDTO)
        {
            try
            {
                await _service.LoginAsync(userDTO);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO userDTO)
        {
            try
            {
                await _service.RegisterAsync(userDTO);
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _service.LogoutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
