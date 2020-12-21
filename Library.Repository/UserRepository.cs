using Library.DAL;
using Library.DAL.Entities;
using Library.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(LibraryDbContext dbContext) : base(dbContext)
        {

        }

        public void CreateUser(UserEntity user) => Create(user);

        public void DeleteUser(UserEntity user) => Delete(user);

        public async Task<UserEntity> GetUserByIdAsync(Guid userId)
        {
            return await Find(u => u.Id.Equals(userId)).FirstOrDefaultAsync();
        }

        public void UpdateUser(UserEntity user) => Update(user);
    }
}
