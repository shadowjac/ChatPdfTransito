namespace CodigoTransitoReader.Domain.ChatMessages;

public sealed class Message
{
    private Message(Content? content, IEnumerable<PageNumber>? references)
    {
        Content = content;
        References = references;
    }

    public static Message From(Content? content, IEnumerable<PageNumber>? references)
    {
        return new Message( content, references);
    }
    public Content? Content { get; private set; }
    public IEnumerable<PageNumber>? References { get; private set; }
}