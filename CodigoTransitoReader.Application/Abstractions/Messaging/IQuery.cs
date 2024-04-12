using CodigoTransitoReader.Domain.Abstractions;
using MediatR;

namespace CodigoTransitoReader.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}