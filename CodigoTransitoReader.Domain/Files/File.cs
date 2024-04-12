using CodigoTransitoReader.Domain.Abstractions;

namespace CodigoTransitoReader.Domain.Files;

public sealed class File : Entity
{
    private File(Guid id, SourceId sourceId, FileName name, NumPages numberOfPages, DateTime createdAt) : base(id)
    {
        SourceId = sourceId;
        Name = name;
        NumberOfPages = numberOfPages;
        CreatedAt = createdAt;
    }

    public SourceId SourceId { get; private set; }
    public FileName Name { get; private set; }
    public NumPages NumberOfPages { get; private set; }
    public DateTime CreatedAt { get; private set; }


    public static File Create(
        SourceId sourceId,
        FileName name,
        NumPages numberOfPages,
        DateTime createdAt)
    {
        return new File(Guid.NewGuid(), sourceId, name, numberOfPages, createdAt);
    }
}