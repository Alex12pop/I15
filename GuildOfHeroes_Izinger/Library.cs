public class Library {
    private List<Book> _books = new List<Book>();

    public string Name { get; private set; }

    public int BookCount {
        get { return _books.Count; }
    }

    public Library(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            Name = "Библиотека";
        } else {
            Name = name.Trim();
        }
    }

    public bool AddBook(Book book) {
        if (FindBookByTitle(book.Title) != null) {
            return false;
        }

        _books.Add(book);
        return true;
    }

    public Book? FindBookByTitle(string title) {
        if (string.IsNullOrWhiteSpace(title)) {
            return null;
        }

        string searchTitle = title.Trim();

        foreach (Book book in _books) {
            if (string.Equals(book.Title, searchTitle, StringComparison.OrdinalIgnoreCase)) {
                return book;
            }
        }

        return null;
    }

    public bool RemoveBook(string title) {
        Book? book = FindBookByTitle(title);
        if (book == null) {
            return false;
        }
        return _books.Remove(book);
    }

    public List<Book> GetBooks() {
        List<Book> result = new List<Book>();
        foreach (Book book in _books) {
            result.Add(book);
        }
        return result;
    }

    public int CountPricierThan(int price) {
        int count = 0;
        foreach (Book book in _books) {
            if (book.Price > price) {
                count += 1;
            }
        }
        return count;
    }
}
