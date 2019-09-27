using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    class Program
    {
        public Game Game
        {
            get => default(Game);
            set
            {
            }
        }

        static void Main(string[] args)
        {
            Game mainGame = new Game();
            mainGame.Start();
        }
    }
}