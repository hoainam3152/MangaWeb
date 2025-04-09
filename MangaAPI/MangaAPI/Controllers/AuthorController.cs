using CoreApiResponse;
using MangaAPI.DTO.Requests;
using MangaAPI.Helpers;
using MangaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MangaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireAdminOrManagerRole")]
    public class AuthorController : BaseController
    {
        private readonly IAuthorRepository service;

        public AuthorController(IAuthorRepository service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var authors = await service.GetAllAuthorsAsync();
                if (authors.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, authors, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(ulong id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var author = await service.GetAuthorAsync(id);
                    if (author != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, author, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var author = await service.CreateAsync(request);
                    return CustomResult(ResponseMessage.CREATE_SUCCESSFUL, author, HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.InnerException!.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ulong id, AuthorRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var author = await service.UpdateAsync(id, request);
                    if (author)
                    {
                        return CustomResult(ResponseMessage.UPDATE_SUCCESSFUL, author, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.InnerException!.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Authorize(Roles = ApplicationRole.Admin)]
        public async Task<IActionResult> Delete(ulong id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Author = await service.DeleteAsync(id);

                    if (Author)
                    {
                        return CustomResult(ResponseMessage.DELETE_SUCCESSFUL, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.InnerException!.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
