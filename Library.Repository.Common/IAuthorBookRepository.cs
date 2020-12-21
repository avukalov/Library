using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Repository.Common
{
    public interface IAuthorBookRepository
    {
        void CreateAuthorBook(AuthorBookEntity authorBook);
    }
}
