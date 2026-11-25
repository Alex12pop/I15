public class Book {
    private string _title = "Без названия";

    public string Title {
        get {
            return _title;
        }

        private set {
            if (string.IsNullOrWhiteSpace(value)) {
                _title = "Без названия";
                return;
            }

            _title = value.Trim();
        }
    }

    public string Author { get; private set; }
    public int Pages { get; private set; }
    public int Price { get; private set; }
    public int Condition { get; private set; }
    public int TimesLoaned { get; private set; }

    public Book(string title, string author, int pages, int price) {
        Title = title;

        if (string.IsNullOrWhiteSpace(author)) {
            Author = "Неизвестный автор";
        } else {
            Author = author.Trim();
        }

        Pages = pages;

        if (Pages < 1) {
            Pages = 1;
        }

        if (Pages > 5000) {
            Pages = 5000;
        }

        Price = price;

        if (Price < 0) {
            Price = 0;
        }

        Condition = 100;
        TimesLoaned = 0;
    }

    public void Wear(int points) {
        if (points <= 0) {
            return;
        }

        Condition -= points;

        if (Condition < 0) {
            Condition = 0;
        }
    }

    public void Restore(int points) {
        if (points <= 0) {
            return;
        }

        int missingCondition = 100 - Condition;

        if (points >= missingCondition) {
            Condition = 100;
            return;
        }

        Condition += points;
    }

    public bool IsUsable() {
        return Condition > 0;
    }

    public bool CanRegisterLoan() {
        return TimesLoaned < int.MaxValue;
    }

    public void RegisterLoan() {
        if (!CanRegisterLoan()) {
            return;
        }
        TimesLoaned += 1;
    }

    public string GetInfo() {
        return $">>> {Title} <<<\n" +
               $"Автор: {Author}\n" +
               $"Страниц: {Pages}\n" +
               $"Цена: {Price} руб.\n" +
               $"Состояние: {Condition}\n" +
               $"Выдач: {TimesLoaned}";
    }
}
