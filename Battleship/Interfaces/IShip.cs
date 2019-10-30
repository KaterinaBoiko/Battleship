using Battleship.Enums;
using System.Collections.Generic;

namespace Battleship.Interfaces
{
    public interface IShip
    {
        //IEnumerable<ICell> Cells { get; }
        ICell FirstCell { get; }
        Directions Direction { get; }
        int DeckNumber { get; }
    }
}
