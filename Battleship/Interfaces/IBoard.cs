using Battleship.Enums;
using Battleship.Values;
using System.Collections.Generic;

namespace Battleship.Interfaces
{
    public interface IBoard
    {
        List<IShip> _ships { get; }
        List<ICell> _cells { get; }
        int Size { get; }
        int SunkenCells { get; }
        void AddShip(IShip ship);
        void HitTheCell(ICell cell);
        bool IsShipFit(IShip ship);
        ICell FindCell(Position position);
        List<ICell> GetCellsOnFire();
        IEnumerable<ICell> GetCellsInDirection(ICell startCell, int numberOfCells, Directions directions);
    }
}
