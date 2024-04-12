using System.Data;

namespace CodigoTransitoReader.Application.Abstractions.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}