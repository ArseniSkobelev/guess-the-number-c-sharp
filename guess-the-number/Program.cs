namespace guess_the_number
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var random = new Random();

            var errColor = ConsoleColor.Red;
            var sucColor = ConsoleColor.Green;
            var defColor = ConsoleColor.Gray;

            var gameEndedInput = "";

            void Game()
            {
                Console.Clear();
                var generatedNumber = random.Next(0, 10);
                var turns = 5;

                gameEndedInput = "";

                Console.WriteLine(generatedNumber);

                Console.Write("The computer has generated a random number for you to guess! (The range is 0 - 10) \n");
                while (true)
                {
                    Console.ForegroundColor = defColor;
                    Console.WriteLine("Guess: ");
                    var userInput = Console.ReadLine();

                    if (String.IsNullOrEmpty(userInput))
                    {
                        Console.WriteLine("Please enter a number!");
                    }
                    else if (userInput.ToLower() == "exit")
                    {
                        Console.WriteLine("Thanks for playing! See ya!");
                        break;
                    }
                    else if (!int.TryParse(userInput, out int isANumber))
                    {
                        Console.WriteLine("Please enter a number!");
                    }
                    else
                    {
                        if (Convert.ToInt32(userInput) == generatedNumber)
                        {
                            Console.ForegroundColor = sucColor;
                            Console.WriteLine("Correct! You have guessed the number correctly! Would you like to try again? (type 'yes' or 'no')");
                            Console.ForegroundColor = defColor;
                            gameEndedInput = Console.ReadLine().ToLower();
                            break;
                        }
                        else
                        {
                            turns--;
                            Console.ForegroundColor = errColor;
                            Console.WriteLine(String.Format("Incorrect! You have {0} tries left!", turns));
                        }

                        if (turns == 0)
                        {
                            Console.WriteLine("You have 0 tries left! Unfortunately you've lost. Would you like to try again? (type 'yes' or 'no')");
                            Console.ForegroundColor = defColor;
                            gameEndedInput = Console.ReadLine().ToLower();
                            break;
                        }
                    }

                }
            }

            Game();
            Console.ForegroundColor = defColor;
            if (gameEndedInput == "yes")
            {
                Game();
            }
            else
            {
                Console.WriteLine("Thanks for playing! See ya!");
            }

        }
    }
}