using Battleship.Enums;
using Battleship.Values;
using System.Collections.Generic;

namespace Battleship.Interfaces
{
    public interface IBoard
    {
        List<IShip> _ships { get;  }
        List<ICell> _cells { get; }
        int Size { get; }
        void AddShip(IShip ship);
        void RemoveShip(IShip ship);
        void HitTheCell(ICell cell);
        ICell FindCell(Position position);
        List<ICell> GetCellsOnFire();
        IEnumerable<ICell> GetCellsInDirection(ICell startCell, int numberOfCells, Directions directions);
    }
}
