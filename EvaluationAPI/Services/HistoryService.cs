using AutoMapper;
using AutoMapper.QueryableExtensions;
using EvaluationAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IUserService _userService;
        private readonly RandomImageContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;


        public HistoryService(
            IUserService userService,
            RandomImageContext context,
            IConfigurationProvider mappingConfiguration)
        {
            _userService = userService;
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

 
        public async Task<int> AddLikeHistoryAsync(HistoryEntity data, Guid userId)
        {
            data.UserGuid = userId;
            var result =  _context.AddAsync(data);
            var affected = await _context.SaveChangesAsync();
            if (affected == 0)
            {
                throw new InvalidOperationException("Could not create History.");
            }

            return result.Id;

        }

        public async Task<PagedResults<History>> GetHistoryAsync(PagingOptions pagingOptions, 
            Guid userId )
        {
            var query = _context.LikesHistory
                .Join(_context.Images,
                lh => lh.ImageId,
                i => i.Id, (lh, i) => new History
                {
                    ImageUrl = i.Url,
                    Liked = lh.Liked,
                    UserGuid = lh.UserGuid,
                    LastUpdate = lh.LastUpdate
                }).Where(r => r.UserGuid == userId)
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value);
  
            //check
            var allHistory = await query.ToListAsync();

            var pagedImages = allHistory
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value);

            return new PagedResults<History>
            {
                Items = pagedImages,
                TotalSize = allHistory.Count
            };

        }

    }



}
