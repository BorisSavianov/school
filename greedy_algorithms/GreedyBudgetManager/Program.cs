Book[] books = new Book[]
{
    new Book("Book 1", "Author 1", 10),
    new Book("Book 2", "Author 2", 15),
    new Book("Book 3", "Author 3", 20),
    new Book("Book 4", "Author 4", 25),
    new Book("Book 5", "Author 5", 30)
};

int budget = 30;

string[] selectedBooks = Console.ReadLine().Split(',');

List<string> requestedTitles = selectedBooks
    .Where(title => !string.IsNullOrWhiteSpace(title))
    .Select(title => title.Trim())
    .ToList();

List<Book> availableBooks = new();
List<string> unavailableBooks = new();

foreach (string requestedTitle in requestedTitles)
{
    Book book = Array.Find(books, b => b.Title.Equals(requestedTitle, StringComparison.OrdinalIgnoreCase));

    if (book != null)
    {
        availableBooks.Add(book);
    }
    else
    {
        unavailableBooks.Add(requestedTitle);
    }
}

foreach (string unavailableBook in unavailableBooks)
{
    Console.WriteLine($"'{unavailableBook}' is not available in the bookstore.");
}

foreach (Book book in availableBooks.OrderBy(b => b.Price).ThenBy(b => b.Title))
{
    if (budget >= book.Price)
    {
        budget -= book.Price;
        Console.WriteLine($"You have purchased '{book.Title}' by {book.Author} for ${book.Price}. Remaining budget: ${budget}");
    }
    else
    {
        Console.WriteLine($"You do not have enough budget to purchase '{book.Title}'. Remaining budget: ${budget}");
    }
}

Console.WriteLine($"Maximum books purchased within budget: {books.Length - availableBooks.Count}");



public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Price { get; set; }

    public Book(string title, string author, int price)
    {
        Title = title;
        Author = author;
        Price = price;
    }
}