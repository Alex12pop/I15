public class Loan {
    public int Id { get; private set; }
    public string Reader { get; private set; }
    public int MinCondition { get; private set; }
    public Book? LentBook { get; private set; }
    public LoanStatus Status { get; private set; }

    public Loan(int id, string reader, int minCondition) {
        Id = id;

        if (string.IsNullOrWhiteSpace(reader)) {
            Reader = "Читатель";
        } else {
            Reader = reader.Trim();
        }

        MinCondition = minCondition;
        if (MinCondition < 0) {
            MinCondition = 0;
        }

        LentBook = null;
        Status = LoanStatus.Open;
    }

    public bool TryStart(Book book) {
        if (Status != LoanStatus.Open) {
            return false;
        }
        if (!book.IsUsable()) {
            return false;
        }
        if (book.Condition < MinCondition) {
            return false;
        }

        LentBook = book;
        Status = LoanStatus.Active;
        return true;
    }

    public bool TryFinish() {
        if (Status != LoanStatus.Active) {
            return false;
        }

        Book? book = LentBook;
        if (book == null) {
            return false;
        }
        if (!book.CanRegisterLoan()) {
            return false;
        }

        book.RegisterLoan();
        Status = LoanStatus.Returned;
        return true;
    }

    public bool TryCancel() {
        if (Status != LoanStatus.Open && Status != LoanStatus.Active) {
            return false;
        }

        Status = LoanStatus.Cancelled;
        return true;
    }

    public string GetStatusText() {
        switch (Status) {
            case LoanStatus.Open:
                return "ожидает выдачи";
            case LoanStatus.Active:
                return "книга на руках";
            case LoanStatus.Returned:
                return "возвращена";
            case LoanStatus.Cancelled:
                return "отменена";
            default:
                return "неизвестно";
        }
    }

    public string GetInfo() {
        string bookText = "книга не выбрана";
        if (LentBook != null) {
            bookText = $"книга «{LentBook.Title}»";
        }

        return $"Выдача №{Id} ({Reader}): {GetStatusText()}, {bookText}";
    }
}
