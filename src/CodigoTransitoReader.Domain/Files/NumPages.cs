namespace CodigoTransitoReader.Domain.Files;

public sealed class NumPages : ValueOf<int, NumPages>
{
    protected override void Validate()
    {
        if (Value <= 0)
            throw new ArgumentOutOfRangeException(nameof(Value), "The number of pages must be greater than 0.");
    }
}