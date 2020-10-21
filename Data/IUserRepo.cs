using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DTOs;
using Library.Models;

namespace Library.Data
{
    public interface IUserRepo
    {
        Task<IEnumerable<ReadBookDTO>> ShowBooks();
        Task<ProfileDTO> ShowProfile(int id);
        Task Take_Book(int user_id, int copy_id);
        Task Back_Book(int user_id, int copy_id);
    }
}