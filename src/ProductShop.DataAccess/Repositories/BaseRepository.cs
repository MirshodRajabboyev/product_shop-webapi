using Npgsql;

namespace ProductShop.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        _connection = new NpgsqlConnection("Host=localhost; Port=5432; " +
            "Database=ProductsShop; User Id=postgres; Password=12345;");
    }
}
