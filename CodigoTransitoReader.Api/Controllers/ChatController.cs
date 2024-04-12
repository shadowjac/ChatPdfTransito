using CodigoTransitoReader.Application.Abstractions.IA;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodigoTransitoReader.Api.Controllers;

public class ChatController : BaseController
{
    private readonly IChatPdfService _chatPdfService;

    public ChatController(ISender sender, IChatPdfService chatPdfService) : base(sender)
    {
        _chatPdfService = chatPdfService;
    }

    [HttpPost("message")]
    public async Task<IActionResult> Chat([FromBody] Request request)
    {
        var result = await _chatPdfService.ChatAsync("user", request.Message);
        return Ok(result);
    }

    [HttpPost("message/stream")]
    public async Task<IActionResult> ChatStream([FromBody] Request request)
    {
        await using var stream = await _chatPdfService.ChatStreamAsync("user", request.Message);
        
        var responseChunks = new List<object>();
        using (var reader = new StreamReader(stream))
        {
            while (await reader.ReadLineAsync() is { } line)
            {
                if (!line.StartsWith("data:")) continue;
                // Parse the JSON data from the line
                var dataObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(line[5..]);
                responseChunks.Add(dataObject!);
            }
        }
        
        return Ok(responseChunks);
    }
}

public record Request(string Message);