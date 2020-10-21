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
    public class UserRepo : IUserRepo
    {



        private readonly IAdminRepo _repository;
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public UserRepo(LibraryContext context, IMapper mapper, IAdminRepo repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }




        public async Task<IEnumerable<ReadBookDTO>> ShowBooks()
        {
            return await _context.Categories.Join
            (
                _context.Books,
                category => category.Id,
                book => book.Categories.Id,
                (category, book) => new ReadBookDTO
                {
                    Name = book.Name,
                    Author = book.Author,
                    Genre = category.Name,
                    Pages = book.Page,
                    Stock = _context.Copies.Where(s => s.BookId == book.Id && s.Status == true).Count()
                }
            ).ToListAsync();

        }








        public async Task<ProfileDTO> ShowProfile(int id)
        {
            User user = await _repository.GetUserById(id);
            List<Assigned_Book> assigned_Book = await _context.Assigned_Books.Where(a => a.UserId == id).ToListAsync();
            List<Copy> copies =  new List<Copy>();
            List<Book> books = new List<Book>();
            List<string> names = new List<string>();

            foreach (Assigned_Book item in assigned_Book)
            {
                copies.Add(await _context.Copies.FirstOrDefaultAsync(s => s.Id == item.CopyId));
            }

            foreach (Copy item in copies)
            {
                books.Add(await _context.Books.FirstOrDefaultAsync(s => s.Id == item.BookId));
            }

            foreach (Book item in books)
            {
                names.Add(item.Name);
            }

            ProfileDTO p = new ProfileDTO 
            {
                Name = user.Name,
                Surname = user.Surname,
                Password = user.Password,
                AssignedBooks = names
            };

            return p;
        }






        public async Task Take_Book(int user_id, int copy_id)
        {
            await _context.Assigned_Books.AddAsync(new Assigned_Book{CopyId = copy_id, UserId = user_id});
            Copy copy = await _context.Copies.FirstOrDefaultAsync(s => s.Id == copy_id);
            copy.Status = false;
            await _context.History.AddAsync(new History{UserId = user_id, CopyId = copy_id, TakenDate = DateTime.Now, BackDate = Convert.ToDateTime("05/05/2005")});
            await _context.SaveChangesAsync();
        }


        public async Task Back_Book(int user_id, int copy_id)
        {
            _context.Assigned_Books.Remove(await _context.Assigned_Books.FirstOrDefaultAsync(s => s.CopyId == copy_id));
            Copy copy = await _context.Copies.FirstOrDefaultAsync(s => s.Id == copy_id);
            copy.Status = true;
            History history = await _context.History.FirstOrDefaultAsync(s => s.CopyId == copy_id && s.BackDate == Convert.ToDateTime("05/05/2005"));
            history.BackDate = DateTime.Now;
            await _context.SaveChangesAsync(); 
        }




    }
}