using CodigoTransitoReader.Application.Abstractions.Clock;
using CodigoTransitoReader.Application.Abstractions.Messaging;
using CodigoTransitoReader.Domain.Abstractions;
using CodigoTransitoReader.Domain.Files;
using CodigoTransitoReader.Domain.Files.Repositories;
using File = CodigoTransitoReader.Domain.Files.File;

namespace CodigoTransitoReader.Application.Files.CreateFile;

public sealed class CreateFileCommandHandler : ICommandHandler<CreateFileCommand, Guid>
{
    private readonly IFileRepository _fileRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateFileCommandHandler(IFileRepository fileRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider)
    {
        _fileRepository = fileRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        var file = await _fileRepository.GetFileBySourceId(SourceId.From(request.SourceId), cancellationToken);

        if (file is not null)
        {
            return Result.Failure<Guid>(FileErrors.FileAlreadyExists);
        }

        var newFile = File.Create(SourceId.From(request.SourceId),
            FileName.From(request.Name),
            NumPages.From(request.NumPages),
            _dateTimeProvider.UtcNow);

        await _fileRepository.AddAsync(newFile, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newFile.Id;
    }
}