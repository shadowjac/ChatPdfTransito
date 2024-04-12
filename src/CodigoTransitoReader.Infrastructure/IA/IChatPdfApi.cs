using Refit;

namespace CodigoTransitoReader.Infrastructure.IA;

internal interface IChatPdfApi
{
    [Post("/chats/message")]
    Task<ChatPdfMessageResponse> PdfMessageAsync([Body] ChatPdfMessageRequest request);

    [Post("/chats/message")]
    Task<Stream> PdfMessageStreamASync([Body] ChatPdfMessageRequest request);
}