using EvaluationAPI.Models;
using EvaluationAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        private readonly IUserService _userService;
        private readonly PagingOptions _defaultPagingOptions;

        public HistoryController(
            IHistoryService historyService,
            IUserService userService,
            IOptions<PagingOptions> defaultPagingOptions)
        {
            _historyService = historyService;
            _defaultPagingOptions = defaultPagingOptions.Value;
            _userService = userService;
        }

        //post likes
        [Authorize]
        [HttpPost(Name = nameof(AddLikeHistory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddLikeHistory(
           [FromBody] HistoryEntity form)
        {
            var userId = await _userService.GetUserIdAsync(User);
            if (userId == null) return Unauthorized();

            var historyId = await _historyService.AddLikeHistoryAsync(
                form, (Guid)userId);

            if (historyId == 0) return BadRequest(new ApiError(
               "An error has ocurred inserting the history"));

            return Created(
                "toBeImplemented",
                new { historyId }          
                );
        }


        [Authorize]
        [HttpGet(Name = nameof(GetAllHistoryAsync))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<Collection<History>>> GetAllHistoryAsync(
            [FromQuery] PagingOptions pagingOptions = null)
        {
            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;
            var allHistory = new PagedResults<History>();
            if (User.Identity.IsAuthenticated)
            {
                var userId = await _userService.GetUserIdAsync(User);
                if (userId != null)
                {
                    allHistory = await _historyService.GetHistoryAsync(pagingOptions, userId.Value);
                }
            }

            var collection = PagedCollection<History>.Create(
             Link.ToCollection(nameof(GetAllHistoryAsync)),
             allHistory.Items.ToArray(),
             allHistory.TotalSize,
             pagingOptions);

            return collection;

        }
    }
}
