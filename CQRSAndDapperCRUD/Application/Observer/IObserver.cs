namespace Application.Observer
{
    public interface IObserver
    {
        void CreatedBook(BookCreated  bookCreated);
    }
}
