using EvaluationAPI.Models;
using EvaluationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly IImageService _imageService;
        private readonly PagingOptions _defaultPagingOptions;

        public ImageController(
            IImageService imageService,
            IOptions<PagingOptions> defaultPagingOptionsWrapper)
        {
            _imageService = imageService;
            _defaultPagingOptions = defaultPagingOptionsWrapper.Value;


        }

        [HttpGet(Name = nameof(GetAllImages))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Collection<Image>>> GetAllImages(
           [FromQuery] PagingOptions pagingOptions = null ) //parameter it's comming from querystring
        {
            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            var images = await _imageService.GetImagesAsync(pagingOptions);

            var collection = PagedCollection<Image>.Create(
                Link.ToCollection(nameof(GetAllImages)),
                images.Items.ToArray(),
                images.TotalSize,
                pagingOptions);

            return collection;
        }

        [HttpGet("{imageId}", Name = nameof(GetImageById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async  Task<ActionResult<Image>> GetImageById(int imageId)
        {
            

           var image =  await _imageService.GetImageAsync(imageId);
            
            if (image == null) return NotFound();
            
            return  image;

            
        }
    }

}
