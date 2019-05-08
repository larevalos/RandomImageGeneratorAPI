using EvaluationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Services
{
    public interface IHistoryService
    {
        Task<int> AddLikeHistoryAsync(HistoryEntity data, Guid userId);
        Task<PagedResults<History>> GetHistoryAsync(PagingOptions pagingOptions,
             Guid userId);
    }
}
