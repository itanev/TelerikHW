using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class GameEngine
    {
        /// <summary>
        /// This is lazy initialization.
        /// If we say:
        ///     private static GameEngine gameEngineInstance = new GameEngine();
        /// It becomes eagger initialization.
        /// </summary>
        private static GameEngine gameEngineInstance = null;

        private GameEngine()
        {
            Console.WriteLine("Hi from inside the game engine.");
        }

        public static GameEngine StartGame()
        {
            return new GameEngine();
        }
    }
}
