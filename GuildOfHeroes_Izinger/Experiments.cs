// Эксперименты ПР №7: пробы, трассировка, «значение, которого нет» и дополнительная часть.

public static class Experiments {
    public static void Run() {
        Console.WriteLine("##### ПР №7: эксперименты #####");
        TwoJobsOneMaster();
        Transitions();
        Trace();
        ExtraHistory();
        ExtraStrangeValue();
    }

    private static void Header(string text) {
        Console.WriteLine();
        Console.WriteLine($"--- {text} ---");
    }

    // Шаг 1 (после шага 6): один мастер — два дела
    private static void TwoJobsOneMaster() {
        Header("Шаг 1: один мастер — два дела");

        Guild probeGuild = new Guild("Учебная гильдия");
        Hero master = new Hero("Учебный мастер", 110);
        probeGuild.AddHero(master);

        QuestBoard probeBoard = new QuestBoard(probeGuild);
        probeBoard.AddQuest(new Quest(1, "Верхняя площадка", 100, 10));
        probeBoard.AddQuest(new Quest(2, "Нижняя площадка", 100, 10));

        Console.WriteLine($"На первое: {probeBoard.TryAssign(1, "Учебный мастер")}");
        Console.WriteLine($"На второе: {probeBoard.TryAssign(2, "Учебный мастер")}");
    }

    // Шаг 5: проверка переходов
    private static void Transitions() {
        Header("Шаг 5: таблица переходов");

        Guild probeGuild = new Guild("Учебная гильдия");
        Hero master = new Hero("Учебный мастер", 110);
        probeGuild.AddHero(master);

        QuestBoard probeBoard = new QuestBoard(probeGuild);
        Quest probeQuest = new Quest(1, "Учебное дело", 100, 10);
        probeBoard.AddQuest(probeQuest);

        Console.WriteLine($"Закрыть открытое: {probeBoard.TryComplete(1)}");
        Console.WriteLine($"Назначить: {probeBoard.TryAssign(1, "Учебный мастер")}");
        Console.WriteLine($"Назначить ещё раз: {probeBoard.TryAssign(1, "Учебный мастер")}");
        Console.WriteLine($"Отменить: {probeBoard.TryCancel(1)}");
        Console.WriteLine($"Закрыть отменённое: {probeBoard.TryComplete(1)}");
        Console.WriteLine($"Отменить ещё раз: {probeBoard.TryCancel(1)}");
        Console.WriteLine(probeQuest.GetInfo());
        Console.WriteLine($"Опыт: {master.Experience}");
    }

    // Шаг 9: трассировка
    private static void Trace() {
        Header("Шаг 9: трассировка");

        Guild traceGuild = new Guild("Трассировка");
        Hero ivan = new Hero("Иван", 120);
        traceGuild.AddHero(ivan);

        QuestBoard traceBoard = new QuestBoard(traceGuild);
        traceBoard.AddQuest(new Quest(1, "Первое", 100, 10));
        traceBoard.AddQuest(new Quest(2, "Второе", 100, 20));

        Console.WriteLine(traceBoard.TryAssign(1, "Иван"));
        Console.WriteLine(traceBoard.TryAssign(2, "Иван"));
        Console.WriteLine(traceBoard.TryComplete(1));
        Console.WriteLine(traceBoard.TryAssign(2, "Иван"));
        Console.WriteLine(traceBoard.TryCancel(1));
        Console.WriteLine(traceBoard.TryCancel(2));
        Console.WriteLine(traceBoard.TryComplete(2));
        Console.WriteLine(traceBoard.IsAssigned(ivan));
        Console.WriteLine(ivan.Experience);
    }

    // Д.1: история героя
    private static void ExtraHistory() {
        Header("Д.1: история героя");

        Guild guild = new Guild("Гильдия героев");
        guild.AddHero(new Hero("Ярослав", 100));
        guild.AddHero(new Hero("Сергей", 110));

        QuestBoard board = new QuestBoard(guild);
        board.AddQuest(new Quest(101, "Вернуть поплавок", 100, 30));
        board.AddQuest(new Quest(102, "Проверить нижнюю площадку", 100, 10));
        board.AddQuest(new Quest(103, "Снять мерки для насоса больницы", 100, 20));
        board.AddQuest(new Quest(104, "Обследовать ответвление", 100, 15));

        board.TryAssign(101, "Сергей");
        board.TryComplete(101);
        board.TryAssign(102, "Сергей");
        board.TryCancel(102);
        board.TryAssign(103, "Сергей");
        board.TryComplete(103);
        board.TryAssign(104, "Ярослав");

        List<Quest> history = board.GetQuestsOf("Сергей");
        Console.WriteLine($"Поручений в истории Сергея: {history.Count}");
        foreach (Quest quest in history) {
            Console.WriteLine(quest.GetInfo());
        }
        Console.WriteLine($"В истории неизвестного героя: {board.GetQuestsOf("Никто").Count}");
    }

    // Д.2: значение, которого нет
    private static void ExtraStrangeValue() {
        Header("Д.2: значение вне перечисления");

        QuestStatus strange = (QuestStatus)7;
        Console.WriteLine(strange);
    }
}
