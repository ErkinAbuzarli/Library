using AutoMapper;
using Library.DTOs;
using Library.Models;

namespace Library.Profiles
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            // Source -> Target
            CreateMap <PostBookDTO, Book> ();
            CreateMap <PostCopyDTO, Copy> ();
            CreateMap <PostCategoryDTO, Category> ();
            CreateMap <PostUserDTO, User> ();


            CreateMap <Book, PostBookDTO> ();
            CreateMap <Copy, PostCopyDTO> ();
            CreateMap <Category, PostCategoryDTO> ();
            CreateMap <User, PostUserDTO> ();

            CreateMap <User, LoginDTO> ();
            CreateMap <LoginDTO, User> ();

        }
    }
}