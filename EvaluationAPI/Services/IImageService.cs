using EvaluationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Services
{
    public interface IImageService
    {
        Task<PagedResults<Image>> GetImagesAsync(PagingOptions pagingOptions);
        Task<Image> GetImageAsync(int id);
    }
}
