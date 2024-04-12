using CodigoTransitoReader.Domain.ChatMessages;
using CodigoTransitoReader.Domain.Files;

namespace CodigoTransitoReader.Application.Abstractions.IA;

public interface IChatPdfService
{
    Task<SourceId?> AddFileAsync(Stream streamFile, CancellationToken cancellationToken = default);

    Task<Message> ChatAsync(string role, string message, bool includeReferences = true,
        CancellationToken cancellationToken = default);

    Task<Stream> ChatStreamAsync(string role,
        string message,
        bool includeReferences = true, CancellationToken cancellationToken = default);
}