using System.Collections.Generic;

namespace JustPacMan
{
    public interface IMovingStrategy
    {
        IEnumerable<Location> GetRoute(Location source, Location destination, MazeObject[,] maze);
    }
}
