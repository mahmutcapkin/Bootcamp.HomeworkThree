namespace Application.Features.Books.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public string Publisher { get; set; }
        public int AuthorId { get; set; }
    }
}
