using WebApi.DbOperations;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using System.Linq;

namespace WebApi.BookOperations.CreateBookCs
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper; // _mapper değişkeni değiştirildi

        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper) // Parametre adı düzeltildi
        {
            _dbContext = dbContext;
            _mapper = mapper; // _mapper değişkenine parametre olarak gelen IMapper nesnesi atanıyor
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book != null)
                throw new InvalidOperationException("Kitap Zaten Mevcut");

            book = _mapper.Map<Book>(Model);

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
