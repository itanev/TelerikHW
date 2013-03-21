namespace JustPacMan
{
    class JustPacmanMain
    {
        #region The Entry Point

        static void Main()
        {
            ConsoleManager consoleManager = new ConsoleManager(new Keyboard(), 100);

            consoleManager.Start();
        }

        #endregion
    }
}
