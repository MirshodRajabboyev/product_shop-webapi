using Dapper;
using ProductShop.Application.Utilities;
using ProductShop.DataAccess.Interfaces.Brands;
using ProductShop.Domain.Entities.Brands;

namespace ProductShop.DataAccess.Repositories.Brands;

public class BrandRepository : BaseRepository, IBrandRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select Count(*) From brands";
            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Brand entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.brands(name) " +
                "VALUES (@Name);";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM brands WHERE id=@Id;";
            var result = await _connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Brand>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "Select * From brands Order By id Desc " +
                $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Brand>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Brand>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Brand?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * From brands Where id=@Id";
            var result = await _connection.QuerySingleAsync<Brand>(query, new { Id = id });

            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Brand entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.brands SET name=@Name " +
                $"WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
