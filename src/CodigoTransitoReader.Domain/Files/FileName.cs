namespace CodigoTransitoReader.Domain.Files;

public sealed class FileName : ValueOf<string, FileName>
{
    protected override void Validate()
    {
        if(string.IsNullOrEmpty(Value))
            throw new ArgumentException("FileName cannot be null or empty");
    }
}