using AutoMapper;
using BL.DTOs.AuthDTOs;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Concretes
{
    public class AuthService : IAuthService
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly SignInManager<IdentityUser> _signInManager;
        readonly IMapper _mapper;
        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task RegisterAsync(RegisterDTO userDTO)
        {
            IdentityUser user = _mapper.Map<IdentityUser>(userDTO);
            await _userManager.CreateAsync(user, "User");
        }
        public async Task LoginAsync(LoginDTO userDTO)
        {
            IdentityUser? user = await _userManager.FindByEmailAsync(userDTO.Email);
            if (user is null)
            {
                throw new Exception("Login credentials are not correct");
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(user, userDTO.Password,true,true);
            if (!result.Succeeded)
            {
                throw new Exception("Login credentials are not correct");
            }
            await _signInManager.SignInAsync(user, true);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
