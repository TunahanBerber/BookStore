using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return; // Veritabanında zaten kitaplar varsa işlemi bitir
                }

                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,   //!idleri auto Incremented yaptıktan sonra ıd eklemenin bir anlamı yok zaten kendi güncelleyecek artık
                        Title = "Yıldızlararası",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Mouse and People",
                        GenreId = 2,
                        PageCount = 164,
                        PublishDate = new DateTime(1899, 06, 12)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Arsen Lupen",
                        GenreId = 2,
                        PageCount = 300,
                        PublishDate = new DateTime(2023, 08, 22)
                    }
                );

                context.SaveChanges(); 
            }
        }
    }
}
