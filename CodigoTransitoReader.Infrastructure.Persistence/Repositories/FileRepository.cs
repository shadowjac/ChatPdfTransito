using CodigoTransitoReader.Domain.Files;
using CodigoTransitoReader.Domain.Files.Repositories;
using File = CodigoTransitoReader.Domain.Files.File;

namespace CodigoTransitoReader.Infrastructure.Persistence.Repositories;

public sealed class FileRepository : IFileRepository
{
    public Task AddAsync(File file, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<File?> GetFileBySourceId(SourceId sourceId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}