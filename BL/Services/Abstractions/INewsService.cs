using BL.DTOs.NewsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstractions
{
    public interface INewsService
    {
        public Task<ICollection<GetNewsDTO>> GetAllNewsAsync();
        public Task<GetNewsDTO> GetNewsByIdAsync(int Id);
        public Task AddNewsAsync(AddNewsDTO news);
        public Task UpdateNews(UpdateNewsDTO news);
        public Task DeleteNews(int Id);
    }
}
