using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using CoreApiResponse;
using MangaAPI.DTO;
using MangaAPI.Helpers;
using MangaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var result = await _accountRepository.RegisterAsync(dto);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return StatusCode(500);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LogInDTO dto)
        {
            var result = await _accountRepository.LogInAsync(dto);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = ApplicationRole.Admin)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var accounts = await _accountRepository.GetAllAccountsAsync();
                if (accounts.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, accounts, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var account = await _accountRepository.GetAccountAsync(id, User);
                if (account != null)
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, account, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
