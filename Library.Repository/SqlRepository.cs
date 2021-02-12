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
                string query = "INSERT INTO Author (AuthorId, FirstName, LastName, Country, CreatedAt, UpdatedAt) VALUES (@AuthorId, @FirstName, @LastName, @Country, @CreatedAt, @UpdatedAt)";

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
                string query = "DELETE FROM Author WHERE AuthorId = @AuthorId";

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
                string query = "SELECT * FROM Author WHERE AuthorId = @AuthorId";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@AuthorId", id);

                    _connection.Open();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        var result = await reader.ReadAsync();
                        if (result)
                        {
                            AuthorEntity author = new AuthorEntity()
                            {
                                AuthorId = Guid.Parse(reader["AuthorId"].ToString()),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Country = reader["Country"].ToString()
                            };
                            reader.Close();
                            return author;
                        }
                        return null;
                    }
                }
            }
        }

        public Task<List<AuthorEntity>> GetAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorEntity> UpdateAuthorAsync(AuthorEntity author)
        {
            throw new NotImplementedException();
        }
    }
}
