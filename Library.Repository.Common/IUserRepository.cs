using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Common
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserByIdAsync(Guid userId);
        void CreateUser(UserEntity user);
        void UpdateUser(UserEntity user);
        void DeleteUser(UserEntity user);
    }
}
