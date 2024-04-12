using CodigoTransitoReader.Application.Abstractions.IA;
using CodigoTransitoReader.Domain.ChatMessages;
using CodigoTransitoReader.Domain.Files;
using CodigoTransitoReader.Infrastructure.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CodigoTransitoReader.Infrastructure.IA;

internal class ChatPdfService : IChatPdfService
{
    private readonly IChatPdfApi _chatPdfApi;
    private readonly string _sourceId;
    private readonly ILogger<ChatPdfService> _logger;

    public ChatPdfService(IChatPdfApi chatPdfApi, IOptions<ChatPdfConfiguration> chatPdfConfiguration, ILogger<ChatPdfService> logger)
    {
        _chatPdfApi = chatPdfApi;
        _logger = logger;
        _sourceId = chatPdfConfiguration.Value.SourceId;
    }

    public async Task<SourceId?> AddFileAsync(Stream streamFile, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Stream> ChatStreamAsync(string role,
        string message,
        bool includeReferences, CancellationToken cancellationToken = default)
    {
        var request = new ChatPdfMessageRequest(new List<PdfMessage> { new PdfMessage(role, message) },
            true,
            includeReferences,
            _sourceId);


        var stream = await _chatPdfApi.PdfMessageStreamASync(request);

        return stream;
    }

    public async Task<Message> ChatAsync(string role,
        string message,
        bool includeReferences, CancellationToken cancellationToken = default)
    {
        //TODO: Implement mapper or mapster
        var request = new ChatPdfMessageRequest(new List<PdfMessage> { new PdfMessage(role, message) },
            false,
            includeReferences,
            _sourceId);

        var response = await _chatPdfApi.PdfMessageAsync(request);

        var result = Message.From(
            Content.From(response.Content),
            response.References.Select(r => PageNumber.From(r.PageNumber))
        );

        return result;
    }
}