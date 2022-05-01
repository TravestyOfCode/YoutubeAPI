using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Web.Data.Queries;
using Google.Apis.Auth;

namespace YoutubeAPI.Web.Controllers
{
    [Authorize]
    public class VideoController : Controller
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetVideosQuery());

            if (result.IsSuccess)
                return View(result.Value);

            return StatusCode(result.StatusCode);            
        }

        public async Task<IActionResult> RefreshVideos()
        {
            var claims = User.Claims;
            Google.Apis.YouTube.v3.YouTubeService service = new Google.Apis.YouTube.v3.YouTubeService();
            Google.Apis.YouTube.v3.SubscriptionsResource subs = service.Subscriptions;
            
            var request = new HttpRequestMessage(HttpMethod.Get, "https://youtube.googleapis.com/youtube/v3/subscriptions?part=snippet&mine=true");

            return StatusCode(200);
            // Get subscriptions for the user

            // For each subscription, get the channel id, title, and thumbnail

            // For each channel, get contentDetails for the relatedPlaylists.uploads value

            // Query the playlistitems endpoint (using snippet)

            // For reach playlistitem in result.items parse data for videos.
        }
    }
}
