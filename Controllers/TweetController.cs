using Microsoft.AspNetCore.Mvc;
using System.Text;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterApi.Models;

namespace TwitterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        [HttpPost]
        public async Task< IActionResult> PosterT(TweetModelDto tweetModelDto)
        {
            var client = new TwitterClient("",
                "",
                "",
                "ap");

            var result = await client.Execute.AdvanceRequestAsync(GoForRequyuest(tweetModelDto, client));
            return Ok(result.Content);
        }
        static Action<ITwitterRequest> GoForRequyuest(TweetModelDto tweetModelDto, TwitterClient client)
        {
            return (ITwitterRequest request) =>
            {
                var body = client.Json.Serialize(tweetModelDto);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Query.Url = "https://api.twitter.com/2/tweets";
                request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST;
                request.Query.HttpContent = content;
            };
        }

    }
}
