namespace _6._6_wiskundequiz_levels;
class Program
{
    static void Main(string[] args)
    {
        // Variables
        int goodAnswers = 0;

        // Show game intro
        GameIntro();

        // Ask playername
        string playerName = Input.AskString("Geef je naam op: ");

        // main do loop, keeps running until wrong answer
        bool result = true;
        do
        {
            int level = VerifyLevel(goodAnswers);
            Random rangen = new Random();

            int number1 = rangen.Next(1, 11);
            int number2 = rangen.Next(1, level);
          
            

            // Call MultiPlications function, which returns bool to indicate a good or a wrong answer, do loop exits on a wrong answer
            result = Multiplications(number1, number2);
            if(result)
            {
                goodAnswers++; // Calculate good answers
            }

        }
        while (result);

        // Print result to player
        GameScore(playerName, goodAnswers);

    }

    // Methods
    //
    // Game intro
    static void GameIntro()
    {
        Console.WriteLine("Welkom in de wiskundequiz. Los de oefeningen op, wanneer je een fout antwoord opgeeft, krijg je het aantal correcte antwoorden weergegeven.");
    }

    // Method to calculate multiplications
    static bool Multiplications(int number1, int number2)
    {
        int answer = Input.AskInteger($"{number1} x {number2} = ");
        if (answer == number1 * number2)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    // Method to print the game score to the user
    static void GameScore(string playerName, int goodAnswers)
    {
        Console.WriteLine($"{playerName} je scoorde {goodAnswers} correct(e) antwoord(en).");
    }

    // Method to verify level based on good answers, f.e. 5 good answers, level 1, 
    // 10 good answers level 2, etc.
    static int VerifyLevel(int goodAnswers)
    {
        if(goodAnswers < 5)
        {
            return 6;
        }
        else if (goodAnswers >= 5 && goodAnswers < 10)
        {
            return 11;
        }
        else
        {
            return 21;
        }    
                
    }
        
    


    // Class to verify valid integer or string input by user

    public static class Input
    {
        public static string AskString(string question)
        {
            Console.Write($"{question}");
            return Console.ReadLine() ?? string.Empty;
        }
        public static int AskInteger(string question)
        {
            while (true)
            {
                Console.Write($"{question}");
                if (int.TryParse(Console.ReadLine(), out int r))
                    return r;

            }
        }
    }
}

