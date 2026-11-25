Probe.Run();
Experiments.Run();

// Hero yaroslav = new Hero("Ярослав", 100);
// Hero anastasia = new Hero("Анастасия", 90);
// Hero artem = new Hero("Артём", 120);
// Hero alexander = new Hero("   Александр   ", 150);
// Hero sergey = new Hero("Сергей", 110);

// alexander.TakeDamage(10);
// alexander.Heal(10);

// Guild guild = new Guild("Гильдия героев");
// guild.AddHero(yaroslav);
// guild.AddHero(anastasia);
// guild.AddHero(artem);
// guild.AddHero(alexander);
// guild.AddHero(sergey);

// Console.WriteLine($">>> {guild.Name}: участников {guild.MemberCount} <<<");
// Console.WriteLine();

// QuestBoard board = new QuestBoard(guild);

// board.AddQuest(new Quest(101, "Вернуть поплавок", 100, 30));
// board.TryAssign(101, "Сергей");
// board.TryComplete(101);

// board.AddQuest(new Quest(102, "Проверить нижнюю площадку", 100, 10));
// board.AddQuest(new Quest(103, "Снять мерки для насоса больницы", 100, 20));
// board.AddQuest(new Quest(104, "Обследовать ответвление", 100, 15));

// Console.WriteLine($"Сергей на №102: {board.TryAssign(102, "Сергей")}");
// Console.WriteLine($"Сергей на №103: {board.TryAssign(103, "Сергей")}");
// Console.WriteLine($"Отмена №102: {board.TryCancel(102)}");
// Console.WriteLine($"Сергей на №103: {board.TryAssign(103, "Сергей")}");
// Console.WriteLine($"Завершение №103: {board.TryComplete(103)}");
// Console.WriteLine($"Ярослав на №104: {board.TryAssign(104, "Ярослав")}");
// Console.WriteLine($"Удалить Сергея: {board.TryRemoveMember("Сергей")}");

// Console.WriteLine();
// List<Quest> quests = board.GetQuests();
// foreach (Quest quest in quests) {
//     Console.WriteLine(quest.GetInfo());
// }

// Console.WriteLine($"Открыто: {board.CountByStatus(QuestStatus.Open)}, " +
//                   $"назначено: {board.CountByStatus(QuestStatus.Assigned)}, " +
//                   $"выполнено: {board.CountByStatus(QuestStatus.Completed)}, " +
//                   $"отменено: {board.CountByStatus(QuestStatus.Cancelled)}");

// Quest? yaroslavQuest = board.FindActiveQuest("Ярослав");
// if (yaroslavQuest != null) {
//     Console.WriteLine($"Ярослав сейчас: №{yaroslavQuest.Id} «{yaroslavQuest.Title}»");
// }

// Quest? sergeyQuest = board.FindActiveQuest("Сергей");
// if (sergeyQuest == null) {
//     Console.WriteLine("Сергей сейчас: свободен");
// }

// Console.WriteLine();
// Console.WriteLine(sergey.GetInfo());

// // ===== Личный проект: «Библиотека» (состояния выдачи и вычисляемая занятость книги) =====
// Console.WriteLine();
// Console.WriteLine("=== Личный проект: библиотека ===");

// Library library = new Library("Городская библиотека");
// Book warAndPeace = new Book("Война и мир", "Лев Толстой", 1225, 650);
// Book crimeAndPunishment = new Book("Преступление и наказание", "Фёдор Достоевский", 592, 380);
// library.AddBook(warAndPeace);
// library.AddBook(crimeAndPunishment);

// LoanDesk desk = new LoanDesk(library);
// desk.AddLoan(new Loan(1, "Иван Петров", 50));
// desk.AddLoan(new Loan(2, "Мария Орлова", 50));
// desk.AddLoan(new Loan(3, "Олег Смирнов", 50));

// Console.WriteLine($"Иван берёт «Войну и мир» (№1): {desk.TryStart(1, "Война и мир")}");
// Console.WriteLine($"Книга выдана сейчас: {desk.IsLent(warAndPeace)}");
// Console.WriteLine($"Мария берёт ту же книгу (№2): {desk.TryStart(2, "Война и мир")}");
// Console.WriteLine($"Отмена выдачи №1: {desk.TryCancel(1)}");
// Console.WriteLine($"Книга выдана сейчас: {desk.IsLent(warAndPeace)}");
// Console.WriteLine($"Мария берёт ту же книгу (№2): {desk.TryStart(2, "Война и мир")}");
// Console.WriteLine($"Возврат по выдаче №2: {desk.TryFinish(2)}");
// Console.WriteLine($"Книга выдана сейчас: {desk.IsLent(warAndPeace)}");
// Console.WriteLine($"Отмена возвращённой выдачи №2: {desk.TryCancel(2)}");
// Console.WriteLine($"Олег берёт ту же книгу (№3): {desk.TryStart(3, "Война и мир")}");

// Console.WriteLine();
// List<Loan> loans = desk.GetLoans();
// foreach (Loan loan in loans) {
//     Console.WriteLine(loan.GetInfo());
// }

// Console.WriteLine($"Ожидают: {desk.CountByStatus(LoanStatus.Open)}, " +
//                   $"на руках: {desk.CountByStatus(LoanStatus.Active)}, " +
//                   $"возвращено: {desk.CountByStatus(LoanStatus.Returned)}, " +
//                   $"отменено: {desk.CountByStatus(LoanStatus.Cancelled)}");

// Console.WriteLine();
// Console.WriteLine(warAndPeace.GetInfo());
