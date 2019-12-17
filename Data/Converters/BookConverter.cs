using CrudPessoas.Data.Converter;
using CrudPessoas.Data.VO;
using CrudPessoas.Model;
using System.Collections.Generic;
using System.Linq;

namespace CrudPessoas.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return new Book();
            return new Book()
            {
                Id = origin.Id,
                Title = origin.Title,
                Author= origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return new BookVO();
            return new BookVO()
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<Book> ParseList(List<BookVO> originList)
        {
            if (originList == null) return new List<Book>();
            return originList.Select(x => Parse(x)).ToList();
        }

        public List<BookVO> ParseList(List<Book> originList)
        {
            if (originList == null) return new List<BookVO>();
            return originList.Select(x => Parse(x)).ToList();
        }
    }
}
