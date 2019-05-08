using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EvaluationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaluationAPI.Services
{
    public class ImageService : IImageService
    {
        private readonly RandomImageContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;
       

        public ImageService(RandomImageContext context,
            IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<Image> GetImageAsync(int id)
        {
            var entity = await _context.Images
                .SingleOrDefaultAsync(i => i.Id == id);
            if (entity == null)
            {
                return null;
            }

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<Image>(entity);
        }

        public async Task<PagedResults<Image>> GetImagesAsync(PagingOptions pagingOptions)
        {
            var query = _context.Images
                .ProjectTo<Image>(_mappingConfiguration);  //automapper to map response in Image model.

            //check
            var allImages = await query.ToListAsync();

            var randomImages = new List<Image>();
            randomImages = RandomizeGenericList(allImages);

            var pagedImages = randomImages
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value);

            return new PagedResults<Image>
            {
                Items = pagedImages,
                TotalSize = randomImages.Count
            };

        }

        public static List<T> RandomizeGenericList<T>(IList<T> originalList)
        {
            List<T> randomList = new List<T>();
            Random random = new Random();
            T value = default(T);

            //now loop through all the values in the list
            while (originalList.Count() > 0)
            {
                //pick a random item from th original list
                var nextIndex = random.Next(0, originalList.Count());
                //get the value for that random index
                value = originalList[nextIndex];
                //add item to the new randomized list
                randomList.Add(value);
                //remove value from original list (prevents
                //getting duplicates
                originalList.RemoveAt(nextIndex);
            }

            //return the randomized list
            return randomList;
        }


    }
}
