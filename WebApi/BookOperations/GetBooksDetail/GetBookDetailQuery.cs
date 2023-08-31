using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Common;
using Microsoft.EntityFrameworkCore;

namespace WebApi.BookOperations.GetBooksDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, int bookId)
        {
            _dbContext = dbContext;
            BookId = bookId;
        }

        public GetBookDetailQuery(BookStoreDbContext context)
        {
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadı!");

            BookDetailViewModel vm = new BookDetailViewModel();
            {
                vm.Title = book.Title;
                vm.Genre = book.GenreId.ToString();
                vm.PageCount = book.PageCount;
                vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
                return vm;
            };
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
