using Library.DAL.Entities;
using Library.Repository.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace Library.Repository
{
    public class SqlRepository : ISqlRepository
    {
        private readonly SqlConnection _connection;

        public SqlRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LibraryDbConnectionString");
            _connection = new SqlConnection(connectionString);

        }

        public async Task<bool> CreateAuthorAsync(AuthorEntity author)
        {
            using (_connection)
            {
                string query = "" + 
                    "INSERT INTO Author (AuthorId, FirstName, LastName, Country, CreatedAt, UpdatedAt) " + 
                    "VALUES (@AuthorId, @FirstName, @LastName, @Country, @CreatedAt, @UpdatedAt);";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@AuthorId", Guid.NewGuid());
                    command.Parameters.AddWithValue("@FirstName", author.FirstName);
                    command.Parameters.AddWithValue("@LastName", author.LastName);
                    command.Parameters.AddWithValue("@Country", author.Country);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                    _connection.Open();
                    return (await command.ExecuteNonQueryAsync()) > 0;
                }
            }
        }

        public async Task<bool> DeleteAuthorAsync(Guid id)
        {
            using (_connection)
            {
                string query = "DELETE FROM Author WHERE AuthorId = @AuthorId;";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@AuthorId", id);
                    
                    _connection.Open();
                    return (await command.ExecuteNonQueryAsync()) > 0;
                }
            }
        }

        public async Task<AuthorEntity> GetAuthorByIdAsync(Guid id)
        {   
            using (_connection)
            {
                string query = "SELECT * FROM Author WHERE AuthorId = @AuthorId;";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@AuthorId", id);

                    _connection.Open();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new AuthorEntity()
                            {
                                AuthorId = Guid.Parse(reader["AuthorId"].ToString()),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Country = reader["Country"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public async Task<List<AuthorEntity>> GetAuthorsAsync()
        {
            using (_connection)
            {
                string query = "SELECT * FROM Author;";

                using(SqlCommand command = new SqlCommand(query, _connection))
                {
                    _connection.Open();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        var authors = new List<AuthorEntity>();
                        while (await reader.ReadAsync())
                        {
                            var author = new AuthorEntity()
                            {
                                AuthorId = Guid.Parse(reader["AuthorId"].ToString()),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Country = reader["Country"].ToString()
                            };
                            authors.Add(author);
                        }

                        await reader.CloseAsync();
                        return authors;
                    }
                }
            }
        }

        public async Task<bool> UpdateAuthorAsync(AuthorEntity author)
        {
            using (_connection)
            {
                string query = "" +
                    "UPDATE Author " +
                    "SET FirstName = @FirstName, LastName = @LastName, Country = @Country, UpdatedAt = @UpdatedAt " +
                    "WHERE AuthorId = @AuthorId;";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@AuthorId", author.AuthorId);
                    command.Parameters.AddWithValue("@FirstName", author.FirstName);
                    command.Parameters.AddWithValue("@LastName", author.LastName);
                    command.Parameters.AddWithValue("@Country", author.Country);
                    command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                    _connection.Open();
                    return (await command.ExecuteNonQueryAsync()) > 0;
                }
            }
        }
    }
}
