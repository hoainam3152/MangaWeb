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
    public class MangaController : BaseController
    {
        private readonly IMangaRepository service;

        public MangaController(IMangaRepository service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var mangas = await service.GetAllMangasAsync();
                if (mangas.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, mangas, HttpStatusCode.OK);
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
                    var manga = await service.GetMangaAsync(id);
                    if (manga != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, manga, HttpStatusCode.OK);
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

        [HttpGet("nameTitle")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByNameTitle(string nameTitle)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mangas = await service.GetMangasByTitleAsync(nameTitle);
                    if (mangas != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, mangas, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(MangaRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var manga = await service.CreateAsync(request);
                    return CustomResult(ResponseMessage.CREATE_SUCCESSFUL, manga, HttpStatusCode.OK);
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
        public async Task<IActionResult> Update(ulong id, MangaRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var manga = await service.UpdateAsync(id, request);
                    if (manga)
                    {
                        return CustomResult(ResponseMessage.UPDATE_SUCCESSFUL, manga, HttpStatusCode.OK);
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
                    var manga = await service.DeleteAsync(id);
                    if (manga)
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
