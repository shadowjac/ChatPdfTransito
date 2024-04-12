namespace CodigoTransitoReader.Infrastructure.IA;

internal sealed record PdfMessage(string Role, string Content);
internal sealed record ChatPdfMessageRequest(IEnumerable<PdfMessage> Messages, bool Stream, bool ReferenceSources, string SourceId);