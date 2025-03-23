using System.Net;
using CoreApiResponse;
using MangaAPI.DTO.Requests;
using MangaAPI.Helpers;
using MangaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : BaseController
    {
        private readonly IGenreRepository service;

        public GenreController(IGenreRepository service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var genres = await service.GetAllGenresAsync();
                if (genres.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, genres, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var genre = await service.GetGenreAsync(id);
                    if (genre != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, genre, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(GenreCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.CreateAsync(request);
                    return CustomResult(ResponseMessage.CREATE_SUCCESSFUL, request, HttpStatusCode.OK);
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

        [HttpPut]
        public async Task<IActionResult> Update(int id, GenreUpdateRequest genreUpdate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var genre = await service.UpdateAsync(id, genreUpdate);
                    if (genre)
                    {
                        return CustomResult(ResponseMessage.UPDATE_SUCCESSFUL, genre, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
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
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var genre = await service.DeleteAsync(id);

                    if (genre)
                    {
                        return CustomResult(ResponseMessage.DELETE_SUCCESSFUL, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (DbUpdateException)
                {
                    return CustomResult(ResponseMessage.DELETE_FAILED, HttpStatusCode.BadRequest);
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
