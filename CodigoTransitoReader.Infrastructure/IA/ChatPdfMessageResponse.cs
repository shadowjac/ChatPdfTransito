namespace CodigoTransitoReader.Infrastructure.IA;

internal sealed record Reference(int PageNumber);

internal sealed record ChatPdfMessageResponse(string Content, IEnumerable<Reference> References);