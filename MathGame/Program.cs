DateTime date = DateTime.Now;

var games = new List<string>();
string name = GetName();

Menu(name, date);

static string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine() ?? "Guest";
    return name;
}
void Menu(string name, DateTime date)
{
    Console.Clear();
    Console.WriteLine("\n");
    Console.WriteLine($"Hello, {name}. It's {date:D}.");

    var isGameOn = true;

    do
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("\n");
        Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
V - View Past Game Scores
Q - Quit Program");
        Console.WriteLine("\n");
        Console.WriteLine("-----------------------------------");
        var gameSelected = Console.ReadLine()?.ToUpper();
        switch (gameSelected)
        {
            case "A":
                AdditionGame("Addition Game");
                break;
            case "S":
                SubtractionGame("Subtraction Game");
                break;
            case "M":
                MultiplicationGame("Multiplication Game");
                break;
            case "D":
                DivisionGame("Division Game");
                break;
            case "V":
                GetGames();
                break;
            case "Q":
                QuitProgram("Quitting program. Goodbye!");
                isGameOn = false;
                break;
            default:
                Console.WriteLine("Invalid selection.");
                break;
        }
    } while (isGameOn);
}



void AdditionGame(string message)
{
    Console.Clear();

    Console.WriteLine("\n");
    Console.WriteLine(message);
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("\n");

    var random = new Random();
    int firstNumber;
    int secondNumber;
    int score = 0;

    for (int i = 0; i < 5; i++)
    {
        firstNumber = random.Next(1, 10);
        secondNumber = random.Next(1, 10);


        Console.WriteLine($"What does {firstNumber} + {secondNumber} equal?");

        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber + secondNumber)
        {
            Console.WriteLine("Correct! Press any key for the next question");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"Incorrect. The correct answer is {firstNumber + secondNumber}.");
            Console.WriteLine("Press any key for the next question");
            Console.ReadLine();
        }


    }

    AddToHistory(score, "Addition");

    Console.WriteLine($"Your score is {score} out of 5.");
    Console.WriteLine("Press any key for Main Menu");
    Console.ReadLine();
}

void SubtractionGame(string message)
{
    Console.Clear();
    Console.WriteLine("\n");
    Console.WriteLine(message);
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("\n");

    var random = new Random();
    int firstNumber;
    int secondNumber;
    int score = 0;

    for (int i = 0; i < 5; i++)
    {
        firstNumber = random.Next(1, 10);
        secondNumber = random.Next(1, 10);


        Console.WriteLine($"What does {firstNumber} - {secondNumber} equal?");

        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber - secondNumber)
        {
            Console.WriteLine("Correct! Press any key for the next question");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"Incorrect. The correct answer is {firstNumber - secondNumber}.");
            Console.WriteLine("Press any key for the next question");
            Console.ReadLine();
        }


    }

    AddToHistory(score, "Subtraction");

    Console.WriteLine($"Your score is {score} out of 5.");
    Console.WriteLine("Press any key for Main Menu");
    Console.ReadLine();
}

void MultiplicationGame(string message)
{
    Console.Clear();
    Console.WriteLine("\n");
    Console.WriteLine(message);
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("\n");

    var random = new Random();
    int firstNumber;
    int secondNumber;
    int score = 0;

    for (int i = 0; i < 5; i++)
    {
        firstNumber = random.Next(1, 10);
        secondNumber = random.Next(1, 10);


        Console.WriteLine($"What does {firstNumber} * {secondNumber} equal?");

        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber * secondNumber)
        {
            Console.WriteLine("Correct! Press any key for the next question");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"Incorrect. The correct answer is {firstNumber * secondNumber}.");
            Console.WriteLine("Press any key for the next question");
            Console.ReadLine();
        }


    }

    AddToHistory(score, "Multiplication");

    Console.WriteLine($"Your score is {score} out of 5.");
    Console.WriteLine("Press any key for Main Menu");
    Console.ReadLine();

}
void DivisionGame(string message)
{
    Console.Clear();
    Console.WriteLine("\n");
    Console.WriteLine(message);
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("\n");
    int score = 0;

    for (int i = 0; i < 5; i++)
    {
        var divisionNumbers = GetDivisionNumbers();
        var firstNumber = divisionNumbers[0];
        var secondNumber = divisionNumbers[1];

        Console.WriteLine($"What does {firstNumber} / {secondNumber} equal?");

        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber / secondNumber)
        {
            Console.WriteLine("Correct! Press any key for the next question");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"Incorrect. The correct answer is {firstNumber / secondNumber}.");
            Console.WriteLine("Press any key for the next question");
            Console.ReadLine();
        }
    }

    AddToHistory(score, "Division");

    Console.WriteLine($"Your score is {score} out of 5.");
    Console.WriteLine("Press any key for Main Menu");
    Console.ReadLine();
}
void GetGames()
{
    Console.Clear();
    Console.WriteLine("\n");
    Console.WriteLine("Games History");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("\n");
    foreach (var game in games)
    {
        Console.WriteLine(game);
    }
    Console.WriteLine("\n");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("\n");
    Console.WriteLine("Press any key to return to main menu");
    Console.ReadLine();

}
void QuitProgram(string message)
{
    Console.WriteLine(message);
    

}

int[] GetDivisionNumbers()
{
    var random = new Random();
    var firstNumber = random.Next(1, 100);
    var secondNumber = random.Next(1, 100);
    var results = new int[2];

    while (firstNumber % secondNumber != 0)
    {
        firstNumber = random.Next(1, 100);
        secondNumber = random.Next(1, 100);
    }

    results[0] = firstNumber;
    results[1] = secondNumber;

    return results;
}

void AddToHistory(int score, string gametype)
{
    games.Add($"{DateTime.Now} - {gametype}: Score = {score}/5");
}