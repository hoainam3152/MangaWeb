using AutoMapper;
using MangaAPI.DTO;
using MangaAPI.DTO.Responses;
using MangaAPI.Helpers;
using MangaAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;

        public AccountService(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager, 
                                IConfiguration configuration,
                                RoleManager<IdentityRole> roleManager,
                                IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
            this.mapper = mapper;

        }

        public async Task<AccountResponse> GetAccountAsync(string accountId, ClaimsPrincipal user)
        {
            var isAdmin = user.IsInRole(ApplicationRole.Admin);
            var loggedInUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!isAdmin && accountId != loggedInUserId)
            {
                throw new Exception(ResponseMessage.NOT_PERMISION);
            }

            var account = await userManager.FindByIdAsync(accountId);
            return mapper.Map<AccountResponse>(account);
        }

        public async Task<IEnumerable<AccountResponse>> GetAllAccountsAsync()
        {
            var users = await userManager.Users.ToListAsync();
            return mapper.Map<IEnumerable<AccountResponse>>(users);
        }

        public async Task<string> LogInAsync(LogInDTO dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return string.Empty;
            }

            var passwordValid = await userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordValid)
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
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole.ToString()));
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
                if (!await roleManager.RoleExistsAsync(ApplicationRole.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(ApplicationRole.User));
                }

                await userManager.AddToRoleAsync(user, ApplicationRole.User);
            }

            return result;
        }
    }
}
