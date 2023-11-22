using Microsoft.Data.SqlClient;

namespace CleanArchitectureSample.Application.Interfaces
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
