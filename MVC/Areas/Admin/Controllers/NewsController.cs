using AutoMapper;
using BL.DTOs.NewsDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Validators.NewsValidator;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class NewsController : Controller
    {
        readonly INewsService _service;
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;
        public NewsController(IMapper mapper, ICategoryService categoryService, INewsService service)
        {
            _service = service;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<GetNewsDTO> news = await _service.GetAllNewsAsync();
                return View(news);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Create()
        {
            try
            {
                ICollection<SelectListItem> categories = await _categoryService.SelectCategories();
                AddNewsDTO newsDTO = new AddNewsDTO
                {
                    Categories = categories,
                };
                return View(newsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddNewsDTO newsDTO)
        {
            var validator = new AddNewsValidation();
            var results = validator.Validate(newsDTO);


            if (!results.IsValid)
            {
                ICollection<SelectListItem> categories = await _categoryService.SelectCategories();
                newsDTO.Categories = categories;
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                }
                return View(newsDTO);
            }
            try
            {
                await _service.AddNewsAsync(newsDTO);
                return RedirectToAction("Index");
            }
            catch (FileNotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotValidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Update(int Id)
        {
            try
            {
                GetNewsDTO newsDTO = await _service.GetNewsByIdAsync(Id);
                ICollection<SelectListItem> categories = await _categoryService.SelectCategories();
                UpdateNewsDTO updateNewDTO = _mapper.Map<UpdateNewsDTO>(newsDTO);
                updateNewDTO.Categories = categories;
                return View(updateNewDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateNewsDTO newsDTO)
        {
            var validator = new UpdateNewsValidation();
            var results = validator.Validate(newsDTO);

            if (!results.IsValid)
            {
                ICollection<SelectListItem> categories = await _categoryService.SelectCategories();
                newsDTO.Categories = categories;
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                }
                return View(newsDTO);
            }
            try
            {
                await _service.UpdateNews(newsDTO);
                return RedirectToAction("Index");
            }
            catch (FileNotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotValidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _service.DeleteNews(Id);
                return RedirectToAction("Index");
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotValidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
