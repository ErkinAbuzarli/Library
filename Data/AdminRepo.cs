using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.DTOs;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class AdminRepo : IAdminRepo
    {












        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public AdminRepo(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        public async Task AddBook(PostBookDTO element)
        {
            var NewBook = _mapper.Map <Book> (element);

            if (NewBook == null) throw new ArgumentNullException(nameof(NewBook));

            _context.Books.Add(NewBook);
            await _context.SaveChangesAsync();
        }

        public async Task AddCategory(PostCategoryDTO element)
        {
            var NewCategory = _mapper.Map <Category> (element);

            if (NewCategory == null) throw new ArgumentNullException(nameof(NewCategory));

            _context.Categories.Add(NewCategory);
            await _context.SaveChangesAsync();
        }

        public async Task AddCopy(PostCopyDTO element)
        {
            var NewCopy= _mapper.Map <Copy> (element);

            if (NewCopy == null) throw new ArgumentNullException(nameof(NewCopy));

            _context.Copies.Add(NewCopy);
            await _context.SaveChangesAsync();
        }

        public async Task AddUser(PostUserDTO element)
        {
            var NewUser= _mapper.Map <User> (element);

            if (NewUser == null) throw new ArgumentNullException(nameof(NewUser));

            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();
        }


















        public async Task DeleteBook(int bookId)
        {
            if (bookId > 0)
            {
                _context.Books.Remove(new Book
                {
                    Id = bookId
                });

                await _context.SaveChangesAsync();
            }
            else{
                throw new ArgumentNullException();
            }
        }

        public async Task DeleteCategory(int categoryId)
        {
            if (categoryId > 0)
            {
                _context.Categories.Remove(new Category
                {
                    Id = categoryId
                });

                await _context.SaveChangesAsync();
            }
            else{
                throw new ArgumentNullException();
            }
        }

        public async Task DeleteCopy(int copyId)
        {
            if (copyId > 0)
            {
                _context.Copies.Remove(new Copy
                {
                    Id = copyId
                });

                await _context.SaveChangesAsync();
            }
            else{
                throw new ArgumentNullException();
            }
        }

        public async Task DeleteUser(int userId)
        {
            if (userId > 0)
            {
                _context.Users.Remove(new User
                {
                    Id = userId
                });

                await _context.SaveChangesAsync();
            }
            else{
                throw new ArgumentNullException();
            }
        }
















        public async Task<Book> GetBookById(int id)
        {
            var element = await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
            return element;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var element = await _context.Books.ToListAsync();
            return element;
        }


        public async Task<IEnumerable<Category>> GetCategories()
        {
            var element = await _context.Categories.ToListAsync();
            return element;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var element = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
            return element;
        }


        public async Task<IEnumerable<Copy>> GetCopies()
        {
            var element = await _context.Copies.ToListAsync();
            return element;
        }

        public async Task<Copy> GetCopyById(int id)
        {
            var element = await _context.Copies.FirstOrDefaultAsync(p => p.Id == id);
            return element;
        }

        public async Task<IEnumerable<History>> GetHistory()
        {
            var element = await _context.History.ToListAsync();
            return element;
        }
        
        public async Task<User> GetUserById(int id)
        {
            var element = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
            return element;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var element = await _context.Users.ToListAsync();
            return element;
        }













        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }














        public async Task<PostBookDTO> FindAndMapBook(int id)
        {
            var element = await GetBookById(id);
            if(element == null) throw new ArgumentNullException();

            return _mapper.Map <PostBookDTO> (element);

        }

        public async Task MapAndSaveBook(PostBookDTO RepoToDto, Book element)
        {
            _mapper.Map (RepoToDto, element);
            await _context.SaveChangesAsync();
        }

        public async Task<PostCopyDTO> FindAndMapCopy(int id)
        {
            var element = await GetCopyById(id);
            if(element == null) throw new ArgumentNullException();

            return _mapper.Map <PostCopyDTO> (element);

        }

        public async Task MapAndSaveCopy(PostCopyDTO RepoToDto, Copy element)
        {
            _mapper.Map (RepoToDto, element);
            await _context.SaveChangesAsync();
        }
        public async Task<PostCategoryDTO> FindAndMapCategory(int id)
        {
            var element = await GetCategoryById(id);
            if(element == null) throw new ArgumentNullException();

            return _mapper.Map <PostCategoryDTO> (element);

        }

        public async Task MapAndSaveCategory(PostCategoryDTO RepoToDto, Category element)
        {
            _mapper.Map (RepoToDto, element);
            await _context.SaveChangesAsync();
        }

        public async Task<PostUserDTO> FindAndMapUser(int id)
        {
            var element = await GetUserById(id);
            if(element == null) throw new ArgumentNullException();

            return _mapper.Map <PostUserDTO> (element);

        }

        public async Task MapAndSaveUser(PostUserDTO RepoToDto, User element)
        {
            _mapper.Map (RepoToDto, element);
            await _context.SaveChangesAsync();
        }














        public async Task<IEnumerable<Book>> SearchBooks(string SearchBy, string SearchString)
        {
            switch (SearchBy)
            {
                case "id":
                    return await _context.Books.Where(s => (s.Id).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                case "name":
                    return await _context.Books.Where(s => s.Name.Contains(SearchString) || SearchString == null).ToListAsync();

                case "author":
                    return await _context.Books.Where(s => s.Author.Contains(SearchString) || SearchString == null).ToListAsync();

                case "categoryid":
                    return await _context.Books.Where(s => (s.CategoryId).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                default:
                    return await GetBooks();
            }
        }

        public async Task<IEnumerable<Copy>> SearchCopies(string SearchBy, string SearchString)
        {
            switch (SearchBy)
            {
                case "id":
                    return await _context.Copies.Where(s => (s.Id).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                case "bookid":
                    return await _context.Copies.Where(s => (s.BookId).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                case "status":
                    return await _context.Copies.Where(s => (s.Status).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                default:
                    return await GetCopies();
            }
        }

        public async Task<IEnumerable<User>> SearchUsers(string SearchBy, string SearchString)
        {
            switch (SearchBy)
            {
                case "id":
                    return await _context.Users.Where(s => (s.Id).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                case "name":
                    return await _context.Users.Where(s => s.Name.Contains(SearchString) || SearchString == null).ToListAsync();

                case "surname":
                    return await _context.Users.Where(s => s.Surname.Contains(SearchString) || SearchString == null).ToListAsync();
                
                case "password":
                    return await _context.Users.Where(s => s.Password.ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                default:
                    return await GetUsers();
            }
        }

        public async Task<IEnumerable<Category>> SearchCategories(string SearchBy, string SearchString)
        {
            switch (SearchBy)
            {
                case "id":
                    return await _context.Categories.Where(s => (s.Id).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                case "name":
                    return await _context.Categories.Where(s => s.Name.Contains(SearchString) || SearchString == null).ToListAsync();

                default:
                    return await GetCategories();
            }
        }

        public async Task<IEnumerable<History>> SearchHistory(string SearchBy, string SearchString)
        {
            switch (SearchBy)
            {
                case "id":
                    return await _context.History.Where(s => (s.Id).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                case "userid":
                    return await _context.History.Where(s => (s.UserId).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                case "copyid":
                    return await _context.History.Where(s => (s.CopyId).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                case "taken-date":
                    return await _context.History.Where(s => (s.TakenDate).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                case "back-date":
                    return await _context.History.Where(s => (s.BackDate).ToString().Contains(SearchString) || SearchString == null).ToListAsync();

                default:
                    return await GetHistory();
            }            

        }





















        public async Task<IEnumerable<Book>> SortBooks(string OrderBy, bool Asc)
        {
            switch (OrderBy)
            {
                case "id":
                    if (Asc) return await _context.Books.OrderBy(s => s.Id).ToListAsync();
                    else return await _context.Books.OrderByDescending(s => s.Id).ToListAsync();

                case "name":
                    if (Asc) return await _context.Books.OrderBy(s => s.Name).ToListAsync();
                    else return await _context.Books.OrderBy(s => s.Name).ToListAsync();           

                case "author":
                    if (Asc) return await _context.Books.OrderBy(s => s.Author).ToListAsync();
                    else return await _context.Books.OrderByDescending(s => s.Author).ToListAsync();
 
                case "categoryid":
                    if (Asc) return await _context.Books.OrderBy(s => s.CategoryId).ToListAsync();
                    else return await _context.Books.OrderByDescending(s => s.CategoryId).ToListAsync();

                default:
                    return await GetBooks();
            }
        }

        public async Task<IEnumerable<Copy>> SortCopies(string OrderBy, bool Asc)
        {
            switch (OrderBy)
            {
                case "id":
                    if (Asc) return await _context.Copies.OrderBy(s => s.Id).ToListAsync();
                    else return await _context.Copies.OrderByDescending(s => s.Id).ToListAsync();

                case "status":
                    if (Asc) return await _context.Copies.OrderBy(s => s.Status).ToListAsync();
                    else return await _context.Copies.OrderByDescending(s => s.Status).ToListAsync();

                case "bookid":
                    if (Asc) return await _context.Copies.OrderBy(s => s.BookId).ToListAsync();
                    else return await _context.Copies.OrderByDescending(s => s.BookId).ToListAsync();

                default:
                    return await GetCopies();
            }
        }

        public async Task<IEnumerable<User>> SortUsers(string OrderBy, bool Asc)
        {
            switch (OrderBy)
            {
                case "id":
                    if (Asc) return await _context.Users.OrderBy(s => s.Id).ToListAsync();
                    else return await _context.Users.OrderByDescending(s => s.Id).ToListAsync();

                case "name":
                    if (Asc) return await _context.Users.OrderBy(s => s.Name).ToListAsync();
                    else return await _context.Users.OrderByDescending(s => s.Name).ToListAsync();

                case "surname":
                    if (Asc) return await _context.Users.OrderBy(s => s.Surname).ToListAsync();
                    else return await _context.Users.OrderByDescending(s => s.Surname).ToListAsync();
       
                case "password":
                    if (Asc) return await _context.Users.OrderBy(s => s.Password).ToListAsync();
                    else return await _context.Users.OrderByDescending(s => s.Password).ToListAsync();

                default:
                    return await GetUsers();
            }
        }

        public async Task<IEnumerable<Category>> SortCategories(string OrderBy, bool Asc)
        {            
            switch (OrderBy)
            {
                case "id":
                    if (Asc) return await _context.Categories.OrderBy(s => s.Id).ToListAsync();
                    else return await _context.Categories.OrderByDescending(s => s.Id).ToListAsync();

                case "name":
                    if (Asc) return await _context.Categories.OrderBy(s => s.Name).ToListAsync();
                    else return await _context.Categories.OrderByDescending(s => s.Name).ToListAsync();

                default:
                    return await GetCategories();
            }
        }

        public async Task<IEnumerable<History>> SortHistory(string OrderBy, bool Asc)
        {
            switch (OrderBy)
            {
                case "id":
                    if (Asc) return await _context.History.OrderBy(s => s.Id).ToListAsync();
                    else return await _context.History.OrderByDescending(s => s.Id).ToListAsync();

                case "userid":
                    if (Asc) return await _context.History.OrderBy(s => s.UserId).ToListAsync();
                    else return await _context.History.OrderByDescending(s => s.UserId).ToListAsync();

                case "copyid":
                    if (Asc) return await _context.History.OrderBy(s => s.CopyId).ToListAsync();
                    else return await _context.History.OrderByDescending(s => s.CopyId).ToListAsync();
       
                case "taken-date":
                    if (Asc) return await _context.History.OrderBy(s => s.TakenDate).ToListAsync();
                    else return await _context.History.OrderByDescending(s => s.TakenDate).ToListAsync();
       
                case "back-date":
                    if (Asc) return await _context.History.OrderBy(s => s.BackDate).ToListAsync();
                    else return await _context.History.OrderByDescending(s => s.BackDate).ToListAsync();

                default:
                    return await GetHistory();
            }
        }











        
        public async Task<IEnumerable<History>> FilterHistory(string Option, string Min, string Max)
        {
            var parsedMinDate = DateTime.Parse(Min);
            var parsedMaxDate = DateTime.Parse(Max);

            switch (Option)
            {
                case "taken" : 
                    return await _context.History.Where(s => s.TakenDate > parsedMinDate && s.TakenDate < parsedMaxDate).ToListAsync();

                case "back" : 
                    return await _context.History.Where(s => s.BackDate > parsedMinDate && s.BackDate < parsedMaxDate).ToListAsync();

                default:
                    return await GetHistory();
            }
        }








  

    }
}