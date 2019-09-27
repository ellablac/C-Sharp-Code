using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WheelOfFortune
{
    public static class UI
    {

        public static void WriteWOF()
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
  


      
                                         __     __  __   __  _____   _____   __   
                                        | | /| / / | |__| | | |     | |     | |
                                        | |/ |/ /  | |__| | | |==   | |==   | |__
                                        |_/  |_/   |_|  |_| |_|___  |_|___  |____|   
                               
                                                         ______   _____
                                                        | |  | | | |
                                                        | |  | | | |==
                                                        |_|__|_| |_|

                                    _____  ______   _____   _______   __  __  __  __  _____
                                   | |    | |  | | | | | | |_______| | | | | |  \| | | |
                                   | |==  | |  | | | |_/ /    | |    | |_| | | \ \ | | |==
                                   |_|    |_|__|_| |_| \_\    |_|    \_____| |_|\ _| |_|___
                                   
                               ");
        }

        public static void SplashScreen()
        {
            const int NUM_SPLASHES = 3;
            for (int i = 0; i < NUM_SPLASHES - 1; i++)
            {
                WriteWOF();
                Thread.Sleep(300);
                Console.Clear();
                Thread.Sleep(300);
            }
            WriteWOF();
            Console.ReadLine();
        }
        public static char PlayOrQuitMenu()
        {
            Console.Write("\nEnter W to Spin the Wheel, S to solve or Q to quit: ");
            string selection = Console.ReadLine();
            while (selection.ToLower() != "w"
                  && selection.ToLower() != "s"
                  && selection.ToLower() != "q")
            {
                Console.Write("\nInvalid selection. Please enter W, S or Q: ");
                selection = Console.ReadLine();
            }
            return Char.ToLower(selection[0]);
        }

        public static void PrintPuzzle(char[] answer)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < answer.Length; i++)
            {
                Console.Write("{0} ", answer[i]);
            }
            Console.WriteLine("\n");
        }
        public static int SpinTheWheel()
        {
            // TODO: return a dollar value, "loose a turn" or "bankrupt"
            // (can use negative numbers for anything other than dollar value)
            // 
            return 100;
        }
        public static char GuessSingleLetter()
        {
            Console.WriteLine("\nSpinning the Wheel...");
            Thread.Sleep(100);
            Console.Write("\nEnter the letter: ");
            string letter = Console.ReadLine().ToLower();

            while (letter.Length != 1 || letter[0] < 'a' || letter[0] > 'z')
            {
                Console.Write("Invalid input. Please enter a letter a-z");
                Console.Write("\nEnter the letter: ");
                letter = Console.ReadLine().ToLower();
            }
            return letter[0];
        }

        public static void LetterGuessResult
               (char letter, int count, int score, int totalScore)
        {
            if (count > 0)
                Console.WriteLine("Congrats, the letter {0} appears in the " +
                    "puzzle {1} times! You won ${2} !!! Your total is ${3} \n",
                    letter, count, score, totalScore);
            else
                Console.WriteLine("Sorry, the letter {0} is not in the " +
                    "puzzle. Your total is ${1} \n",
                    letter, totalScore);
        }

        public static void PuzzleGuessResult(bool solved, int score)
        {
            if (solved)
            {
                Console.WriteLine("You won the round! Your score is {0}", score);
            }
            else
            {
                Console.WriteLine("Sorry, incorrect. You lost everything");
            }
        }
    }
}
