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
            var client = new TwitterClient("nDi7ms0i7HZhbYnXqoTt6NtUg",
                "VMAsiZNIs7yOnnjHjbnLRmQMlP6bwUTE29UVnA3QMN3YSu6xZi",
                "1525161521713668096-fJbaJFX0vVMRqAU0fovCAZD3l33t7m",
                "albuYF5RyHFI0WRuJCON88DuyiZgzzhmUMRmUzmysQqVI");

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
