using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public class Answer
    {
        public string Puzzle;
        public char[] MaskedPuzzle;
        public string Category;

        public Answer()
        {
            Puzzle = null;
            MaskedPuzzle = null;
            Category = null;
            Initialize();
        }
        private void Initialize()
        {
            Puzzle = "You are playing Wheel of Fortune";
            MaskedPuzzle = new char[Puzzle.Length];
            for (int i = 0; i < Puzzle.Length; i++)
            {
                if (Puzzle[i] == ' ')
                    MaskedPuzzle[i] = ' ';
                else
                    MaskedPuzzle[i] = '_';
            }
        }

        public int CheckLetter(char letter)
        {
            int count = 0;
            for (int i = 0; i < Puzzle.Length; i++)
            {
                if (Char.ToLower(Puzzle[i]) == letter
                    && MaskedPuzzle[i] == '_')
                {
                    MaskedPuzzle[i] = Puzzle[i];
                    count++;
                }
            }
            return count;
        }
        public bool CheckSolution(string solution)
        {
            if (solution.ToLower() == Puzzle.ToLower())
                return true;
            else
                return false;
        }
    }
}
