using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DTOs;
using Library.Models;

namespace Library.Data
{
    public interface IAdminRepo
    {





        Task AddBook(PostBookDTO element);
        Task AddCopy(PostCopyDTO element);
        Task AddCategory(PostCategoryDTO element);
        Task AddUser(PostUserDTO element);







        Task DeleteBook(int bookId);
        Task DeleteCopy(int copyId);
        Task DeleteCategory(int categoryId);
        Task DeleteUser(int userId);









        Task<PostBookDTO> FindAndMapBook(int id);
        Task<PostCopyDTO> FindAndMapCopy(int id);
        Task<PostCategoryDTO> FindAndMapCategory(int id);
        Task<PostUserDTO> FindAndMapUser(int id);


        Task MapAndSaveBook(PostBookDTO RepoToDTO, Book element);
        Task MapAndSaveCopy(PostCopyDTO RepoToDTO, Copy element);
        Task MapAndSaveCategory(PostCategoryDTO RepoToDTO, Category element);
        Task MapAndSaveUser(PostUserDTO RepoToDTO, User element);







        bool SaveChanges();







        

        Task<Book> GetBookById(int id);
        Task<Copy> GetCopyById(int id);
        Task<User> GetUserById(int id);
        Task<Category> GetCategoryById(int id);









        Task<IEnumerable<Book>> GetBooks();
        Task<IEnumerable<Copy>> GetCopies();
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<History>> GetHistory();








        Task<IEnumerable<Book>> SearchBooks(string SearchBy, string SearchString);
        Task<IEnumerable<Copy>> SearchCopies(string SearchBy, string SearchString);
        Task<IEnumerable<User>> SearchUsers(string SearchBy, string SearchString);
        Task<IEnumerable<Category>> SearchCategories(string SearchBy, string SearchString);
        Task<IEnumerable<History>> SearchHistory(string SearchBy, string SearchString);












        Task<IEnumerable<Book>> SortBooks(string OrderBy, bool Asc);
        Task<IEnumerable<Copy>> SortCopies(string OrderBy, bool Asc);
        Task<IEnumerable<User>> SortUsers(string OrderBy, bool Asc);
        Task<IEnumerable<Category>> SortCategories(string OrderBy, bool Asc);
        Task<IEnumerable<History>> SortHistory(string OrderBy, bool Asc);  





        Task<IEnumerable<History>> FilterHistory(string Option, string Min, string Max);

    }
}