namespace CodigoTransitoReader.Domain.Files;

public sealed class SourceId : ValueOf<string, SourceId>
{
    protected override void Validate()
    {
        if (!Value.StartsWith("src_"))
        {
            throw new ArgumentException("Invalid source id");
        }
    }
}