using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Application.Observer.EventHandler
{
    public class BookCreatedSendEmail : IObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public BookCreatedSendEmail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreatedBook(BookCreated  bookCreated)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<BookCreatedSendEmail>>();

            logger.LogInformation($"Email Gönderildi : Kitap id={bookCreated.BookId} Kitap ismi : {bookCreated.BookName}");
        }
    }
}
