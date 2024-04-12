namespace CodigoTransitoReader.Domain.Files.Repositories;

public interface IFileRepository
{
    Task AddAsync(File file, CancellationToken cancellationToken = default);
    Task<File?> GetFileBySourceId(SourceId sourceId, CancellationToken cancellationToken = default);
}