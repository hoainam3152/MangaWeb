using MangaAPI.DTO.Requests;
using MangaAPI.Helpers;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MangaGenresAPI.Repositories;
using CoreApiResponse;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MangaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireAdminOrManagerRole")]
    public class MangaGenresController : BaseController
    {
        private readonly IMangaGenresRepository service;

        public MangaGenresController(IMangaGenresRepository service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var MangaGenress = await service.GetAllMangaGenressAsync();
                if (MangaGenress.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, MangaGenress, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(ulong mangaId, int genreId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var MangaGenres = await service.GetMangaGenresAsync(mangaId, genreId);
                    if (MangaGenres != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, MangaGenres, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(MangaGenresRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var MangaGenres = await service.CreateAsync(request);
                    return CustomResult(ResponseMessage.CREATE_SUCCESSFUL, MangaGenres, HttpStatusCode.OK);
                }
                catch (DbUpdateException dbEx)
                {
                    return CustomResult(dbEx.Message, HttpStatusCode.BadRequest);
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
        public async Task<IActionResult> Delete(ulong mangaId, int genreId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var MangaGenres = await service.DeleteAsync(mangaId, genreId);
                    if (MangaGenres)
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
