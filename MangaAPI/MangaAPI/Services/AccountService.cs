using MangaAPI.DTO;
using MangaAPI.Helpers;
using MangaAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MangaAPI.Services
{
    public class AccountService : IAccountRepository
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager, 
                                IConfiguration configuration,
                                RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;

        }

        public async Task<string> LogInAsync(LogInDTO dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            var passwordValid = await userManager.CheckPasswordAsync(user, dto.Password);
            if (user == null || !passwordValid)
            {
                return string.Empty;
            }
            var result = await signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);

            if (!result.Succeeded)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));

            var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(20),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDTO dto)
        {
            var user = new IdentityUser
            {
                Email = dto.Email,
                UserName = dto.Email,
            };

            var result = await userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                //check if role not exists
                if (!await roleManager.RoleExistsAsync(ApplicationRole.Customer))
                {
                    await roleManager.CreateAsync(new IdentityRole(ApplicationRole.Customer));
                }

                await userManager.AddToRoleAsync(user, ApplicationRole.Customer);
            }

            return result;
        }
    }
}
