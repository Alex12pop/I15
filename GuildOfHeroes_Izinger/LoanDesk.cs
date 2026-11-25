public class LoanDesk {
    private readonly Library _library;
    private readonly List<Loan> _loans = new List<Loan>();

    public LoanDesk(Library library) {
        _library = library;
    }

    public bool AddLoan(Loan loan) {
        if (loan.Status != LoanStatus.Open) {
            return false;
        }
        if (FindLoan(loan.Id) != null) {
            return false;
        }
        _loans.Add(loan);
        return true;
    }

    public Loan? FindLoan(int loanId) {
        foreach (Loan loan in _loans) {
            if (loan.Id == loanId) {
                return loan;
            }
        }
        return null;
    }

    public List<Loan> GetLoans() {
        return new List<Loan>(_loans);
    }

    public bool IsLent(Book book) {
        foreach (Loan loan in _loans) {
            if (loan.Status == LoanStatus.Active && loan.LentBook == book) {
                return true;
            }
        }
        return false;
    }

    public bool TryStart(int loanId, string title) {
        Loan? loan = FindLoan(loanId);
        if (loan == null) {
            return false;
        }

        Book? book = _library.FindBookByTitle(title);
        if (book == null) {
            return false;
        }

        if (IsLent(book)) {
            return false;
        }

        return loan.TryStart(book);
    }

    public bool TryFinish(int loanId) {
        Loan? loan = FindLoan(loanId);
        if (loan == null) {
            return false;
        }
        return loan.TryFinish();
    }

    public bool TryCancel(int loanId) {
        Loan? loan = FindLoan(loanId);
        if (loan == null) {
            return false;
        }
        return loan.TryCancel();
    }

    public int CountByStatus(LoanStatus status) {
        int count = 0;
        foreach (Loan loan in _loans) {
            if (loan.Status == status) {
                count++;
            }
        }
        return count;
    }
}
