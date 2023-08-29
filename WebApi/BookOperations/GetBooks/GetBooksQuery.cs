using WebApi.DbOperations;
using WebApi.Common;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle() // Geri dönüş tipi List<BooksViewModel> olarak düzeltildi
        {
            var bookList = _dbContext.Books.OrderBy(book => book.Id).ToList(); // Değişken ismi X yerine book olarak düzeltildi
            List<BooksViewModel> vm = new List<BooksViewModel>();

            foreach (var book in bookList) // Değişken ismi item yerine book olarak düzeltildi
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title, // Book.Title olarak düzeltildi
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.ToString("dd/MM/yyyy")

                });
            }
            return vm; // Değişken ismi bookList olarak düzeltildi
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
