using CodigoTransitoReader.Application.Abstractions.Messaging;

namespace CodigoTransitoReader.Application.Files.CreateFile;

public sealed record CreateFileCommand(
    Guid Id,
    Guid ClientId,
    string SourceId,
    string Name,
    int NumPages) : ICommand<Guid>;