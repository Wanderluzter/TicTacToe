using System;

class Jogo
{
    public static void Run()
    {
        string name1 = ChooseName(1), name2 = ChooseName(2);
        int score1 = 0, score2 = 0;
        int min = 100, max = 999;

        do
        {
            Console.Clear();
            int number = GetNumberInput(name1, min, max);

            Console.Clear();
            score1 += Guess(name2, number, min, max);

            ShowScore(name1, name2, score1, score2);

            (name1, name2) = (name2, name1);
            (score1, score2) = (score2, score1);

        } while (Continue());
        Console.WriteLine("See ya!");
    }

    public static int GetNumberInput(string name, int min, int max)
    {
        int number;
        do { Console.Write($"{name} please type between {min} and {max}: "); }
        while (!int.TryParse(Console.ReadLine(), out number) || number < min || number > max);
        return number;
    }

    public static string ChooseName(int playerNumber)
    {
        Console.Write($"Please type a name for player {playerNumber}: ");
        return Console.ReadLine();
    }

    public static bool Continue()
    {
        while (true)
        {
            Console.WriteLine("Continue playing? ( Y / N )");
            switch (Console.ReadKey(intercept: true).Key)
            {
                case ConsoleKey.Y: return true;
                case ConsoleKey.N: return false;
                default: continue;
            }
        }
    }

    public static int Guess(string playerName, int correctNumber, int min, int max)
    {
        int usedGuesses = 0;
        while (true)
        {
            usedGuesses++;
            int guess = GetNumberInput(playerName, min, max);
            if (guess > correctNumber)
            {
                Console.WriteLine("The correct number is smaller.");
                continue;
            }
            else if (guess < correctNumber)
            {
                Console.WriteLine("The correct number is bigger.");
                continue;
            }
            else
            {
                Console.WriteLine($"Congratulations! You got it right in {usedGuesses} guesses!");
                return usedGuesses;
            }
        }
    }

    public static void ShowScore(string name1, string name2, int score1, int score2)
    {
        Console.WriteLine("----------SCORE-----------");
        Console.WriteLine("                           ");
        Console.WriteLine($"{name1} : {score1}");
        Console.WriteLine("                           ");
        Console.WriteLine($"{name2} : {score2}");
        Console.WriteLine("                           ");
        Console.WriteLine("---------------------------");
    }
}