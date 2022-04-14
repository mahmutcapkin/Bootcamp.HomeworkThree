using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Application.Observer.EventHandler
{
    public class BookCreatedSendSms : IObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public BookCreatedSendSms(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreatedBook(BookCreated  bookCreated)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<BookCreatedSendSms>>();
            logger.LogInformation($"SMS Gönderildi : Kitap id={bookCreated.BookId} Kitap ismi : {bookCreated.BookName}");
        }
    }
}
