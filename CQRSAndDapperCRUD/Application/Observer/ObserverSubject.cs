namespace Application.Observer
{
    public class ObserverSubject
    {
        private readonly List<IObserver> _observers;

        public ObserverSubject()
        {
            _observers = new List<IObserver>();
        }
        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void UnSubscribe(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void NotifySubscribes(BookCreated bookCreated)
        {
            _observers.ForEach(x =>
            {
                x.CreatedBook(bookCreated);
            });
        }
    }
}
