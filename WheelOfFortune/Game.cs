using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public class Game
    {
        private const char SPIN_WHEEL = 'w'; // spin the wheel = guess a letter
        private const char SOLVE_PUZZLE = 's';
        private const char QUIT_GAME = 'q';

        private Player player1;
        private Answer answer;
        public Game()
        {
            player1 = new Player();
            answer = new Answer();
        }

        public void Start()
        {
            UI.SplashScreen();
            Console.WriteLine("the game has started\n");

            char userSelection = UI.PlayOrQuitMenu();
            bool endGame = false;
            while (userSelection != QUIT_GAME && !endGame)
            {
                UI.PrintPuzzle(answer.MaskedPuzzle);
                switch (userSelection)
                {
                    case SPIN_WHEEL:
                        SpinWheel();
                        break;
                    case SOLVE_PUZZLE:
                        endGame = SolvePuzzle();
                        break;
                }

                userSelection = UI.PlayOrQuitMenu();
            }
        }
        private void SpinWheel()
        {
            int money = UI.SpinTheWheel();
            char playerLetter = UI.GuessSingleLetter();
            int count = answer.CheckLetter(playerLetter);
            int guessScore = 0;
            if (count > 0)
            {
                guessScore = count * money;
                player1.score += guessScore;
            }
            UI.LetterGuessResult(playerLetter, count, guessScore, player1.score);
            UI.PrintPuzzle(answer.MaskedPuzzle);
        }

        public bool SolvePuzzle()
        {
            Console.Write("Enter the phrase: ");
            string playerAnswer = Console.ReadLine();
            bool solved = answer.CheckSolution(playerAnswer);
            UI.PuzzleGuessResult(solved, player1.score);
            if (solved)
                // TODO: if they want to play another round,
                // initialize the answer and scores.
                return true;
            else
                player1.score = 0;

            return false;
        }
        public void MainMenu()
        {
            Console.WriteLine("this is the main menu");
        }
    }
}
