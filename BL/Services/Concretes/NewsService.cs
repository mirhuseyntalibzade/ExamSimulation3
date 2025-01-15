using AutoMapper;
using BL.DTOs.NewsDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Models;
using DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;

namespace BL.Services.Concretes
{
    public class NewsService : INewsService
    {
        readonly INewsRepository _repository;
        readonly IMapper _mapper;
        readonly IWebHostEnvironment _webHostEnvironment;
        public NewsService(IWebHostEnvironment webHostEnvironment, IMapper mapper, INewsRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task AddNewsAsync(AddNewsDTO newsDTO)
        {
            News news = _mapper.Map<News>(newsDTO);

            string rootPath = _webHostEnvironment.WebRootPath;
            string folderPath = rootPath + "/uploads/news/";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileName = newsDTO.Image.FileName;
            string filePath = folderPath + fileName;

            string[] extensions = [".jpg", ".png", ".jpeg"];
            bool isAllowed = false;
            foreach (string extension in extensions)
            {
                if (Path.GetExtension(fileName) == extension)
                {
                    isAllowed = true;
                    break;
                }
            }

            if (!isAllowed)
            {
                throw new FileNotSupportedException("File is not supported");
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await newsDTO.Image.CopyToAsync(stream);
            }
            news.ImageURL = fileName;
            await _repository.AddAsync(news);
            int result = await _repository.SaveChangesAsync();
            if (result == 0)
            {
                throw new NotValidOperationException("Couldn't add news.");
            }
        }

        public async Task DeleteNews(int Id)
        {
            News news = await _repository.GetByIdAsync(Id);
            _repository.Delete(news);
            int result = await _repository.SaveChangesAsync();
            if (result == 0)
            {
                throw new NotValidOperationException("Couldn't delete news.");
            }
        }

        public async Task<ICollection<GetNewsDTO>> GetAllNewsAsync()
        {
            ICollection<News> news = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<GetNewsDTO>>(news);
            
        }

        public async Task<GetNewsDTO> GetNewsByIdAsync(int Id)
        {
            News news = await _repository.GetByIdAsync(Id);
            if (news is null)
            {
                throw new NotFoundException("item cannot be found.");
            }
            return _mapper.Map<GetNewsDTO>(news);
        }

        public async Task UpdateNews(UpdateNewsDTO newsDTO)
        {
            News news = _mapper.Map<News>(newsDTO);

            string rootPath = _webHostEnvironment.WebRootPath;
            string folderPath = rootPath + "/uploads/news/";
            string fileName = newsDTO.Image.FileName;
            string filePath = folderPath + fileName;

            string[] extensions = [".jpg", ".png", ".jpeg"];
            bool isAllowed = false;
            foreach (string extension in extensions)
            {
                if (Path.GetExtension(fileName) == extension)
                {
                    isAllowed = true;
                    break;
                }
            }

            if (!isAllowed)
            {
                throw new FileNotSupportedException("File is not supported");
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await newsDTO.Image.CopyToAsync(stream);
            }
            news.ImageURL = fileName;

            _repository.Update(news);
            int result = await _repository.SaveChangesAsync();
            if (result == 0)
            {
                throw new NotValidOperationException("Couldn't update news.");
            }
        }
    }
}
