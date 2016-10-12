using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Quit the game when true
            bool quit = false;

            //Keep track of round number
            int currentRound = 1;
            // Log score
            int computerWins = 0;
            int playerWins = 0;

            //Log choices
            string userChoice = "";
            string computerChoice = "";

            // Stores users choice of rock, paper, or scissors
            string choice = "";

            //Print title block
            PrintTitle();

            // How many Rounds
            Console.Write("Best of: ");
            int numerOfRounds = int.Parse(Console.ReadLine());
            Console.Clear();
            PrintTitle();

            //Begin Game
            while (!quit)
            {
                Console.WriteLine($"ROUND {currentRound}");
                Console.WriteLine();
                PrintChoices();
                Console.WriteLine();
                choice = Console.ReadLine().ToLower();
                userChoice = UsersMove(choice);

                // Generate Computers Move
                Random r = new Random();
                int rInt = r.Next(1, 3);
                computerChoice = ComputersMove(rInt);
                quit = DecideWinner(userChoice, computerChoice,computerWins,playerWins,numerOfRounds);
                Console.Clear();

                currentRound++;

            }





        }

        private static bool DecideWinner(string userChoice, string computerChoice, int computerWins, int playerWins, int numberOfRounds)
        {

            if (userChoice.Equals("rock") && computerChoice.Equals("paper")) //Users rock loses to paper
            {
                computerWins++;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("YOU LOSE");
                Console.ReadLine();
            }
            else if (userChoice.Equals("rock") && computerChoice.Equals("scissors")) //Users rock beats scissors
            {
                playerWins++;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("YOU WIN!");
                Console.ReadLine();
            }
            else if (userChoice.Equals("rock") && computerChoice.Equals("rock")) // Draw
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("IT'S A DRAW!");
                Console.ReadLine();
            }
            else if (userChoice.Equals("paper") && computerChoice.Equals("rock")) //Users paper beats rock
            {
                playerWins++;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("YOU WIN!");
                Console.ReadLine();
            }
            else if (userChoice.Equals("paper") && computerChoice.Equals("paper")) //Draw
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("IT'S A DRAW!");
                Console.ReadLine();
            }
            else if (userChoice.Equals("paper") && computerChoice.Equals("scissors")) //Users paper loses to scissors
            {
                computerWins++;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("YOU LOSE");
                Console.ReadLine();
            }
            else if (userChoice.Equals("scissors") && computerChoice.Equals("rock")) //Users scissors loses to rock
            {
                computerWins++;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("YOU LOSE");
                Console.ReadLine();
            }
            else if (userChoice.Equals("scissors") && computerChoice.Equals("paper")) //Users scissors beats to paper
            {
                playerWins++;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("YOU WIN!");
                Console.ReadLine();
            }
            else if (userChoice.Equals("scissors") && computerChoice.Equals("scissors")) //Draw
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("IT'S A DRAW!");
                Console.ReadLine();
            }
            return false;
        }

        private static string UsersMove(string choice)
        {
            Console.Clear();
            switch (choice)
            {
                case "1":
                    PrintRock();
                    return "rock";
                case "rock":
                    PrintRock();
                    return "rock";
                case "2":
                    PrintPaper();
                    return "paper";
                case "paper":
                    PrintPaper();
                    return "paper";
                case "3":
                    PrintScissors();
                    return "scissors";
                case "scissor":
                    PrintScissors();
                    return "scissors";
                default:
                    return "";
            }
        }

        private static string ComputersMove(int choice)
        {
            
            switch (choice)
            {
                case 1:
                    PrintVS();
                    PrintRock();
                    return "rock";
                case 2:
                    PrintVS();
                    PrintPaper();
                    return "paper";
                case 3:
                    PrintVS();
                    PrintScissors();
                    return "scissors";
                default:
                    return "";
            }
        }

        private static void PrintChoices()
        {
            Console.WriteLine("1  Rock");
            Console.WriteLine("2  Paper");
            Console.WriteLine("3  Scissors");
        }

        private static void PrintTitle()
        {
            // Start with the file path to input
            string directory = Environment.CurrentDirectory;
            string filename = "Title.txt";

            // Create the full path
            string fullPath = Path.Combine(directory, filename);

            PrintFile(fullPath,true);

        }

        private static void PrintScissors()
        {
            // Start with the file path to input
            string directory = Environment.CurrentDirectory;
            string filename = "Scissors.txt";

            // Create the full path
            string fullPath = Path.Combine(directory,filename);

            PrintFile(fullPath,false);

        }

        private static void PrintRock()
        {
            // Start with the file path to input
            string directory = Environment.CurrentDirectory;
            string filename = "Rock.txt";

            // Create the full path
            string fullPath = Path.Combine(directory, filename);

            PrintFile(fullPath,false);

        }

        private static void PrintPaper()
        {
            // Start with the file path to input
            string directory = Environment.CurrentDirectory;
            string filename = "Paper.txt";

            // Create the full path
            string fullPath = Path.Combine(directory, filename);

            PrintFile(fullPath, false);

        }

        private static void PrintVS()
        {
            // Start with the file path to input
            string directory = Environment.CurrentDirectory;
            string filename = "VS.txt";

            // Create the full path
            string fullPath = Path.Combine(directory, filename);

            PrintFile(fullPath, false);

        }

        private static void PrintFile(string fullPath,bool delay)
        {
            // Wrap the effort in a try-catch block to handle any exceptions
            try
            {
                //Open a StreamReader with the using statement
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    // Read the file until the end of the stream is reached
                    // EndOfStream is a "marker" that the stream uses to determine 
                    // if it has reached the end
                    // As we read forward the marker moves forward like a typewriter.
                    while (!sr.EndOfStream)
                    {
                        // Read in the line
                        string line = sr.ReadLine();

                        // See if there needs to be a delay
                        if (delay)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                        // Print it to the screen
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
        }
    }
}
