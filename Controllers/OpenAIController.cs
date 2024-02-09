using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OpenAI_TTS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAIController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> TTS(InputBody input)
        {
            var httpClient = new HttpClient();
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.openai.com/v1/audio/speech"),
                Headers =
                {
                    { HttpRequestHeader.Authorization.ToString(), "Bearer YOUR_API_KEY" },
                    { HttpRequestHeader.Accept.ToString(), "application/json" }
                },
                Content = JsonContent.Create(input)
            };

            var response = await httpClient.SendAsync(httpRequestMessage);
            var byteArray = await response.Content.ReadAsByteArrayAsync();
            await System.IO.File.WriteAllBytesAsync("audio.mp3", byteArray);

            return Ok(response);
        }
    }
}