using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.DAL.Entities;
using Backend.Infrastructure.Helpers;
using Backend.Views.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers.Components
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthorizationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // POST: api/Authorization/Register
        [HttpPost("Register")]
        public async Task<IActionResult> PostRegister([FromBody] RegisterView model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return Ok(/*new { Token = TokenHelper.GenerateToken(user) }*/);

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }

            var errors = ModelState.Values.Select(t => t.Errors.Select(p => p.ErrorMessage));

            return BadRequest(errors);
        }

        // POST: api/Authorization/Login
        [HttpPost("Login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginView model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                    return Ok(/*new { Token = TokenHelper.GenerateToken(new User { Email = model.Email }) }*/);
            }

            return Unauthorized();
        }
    }
}
