using Battleship.Interfaces;
using System.Collections.Generic;
using System;
using Battleship.Values;
using Battleship.Enums;
using System.Linq;
using SeaBattle.Enums;

namespace Battleship.Classes
{
    public class Board : IBoard
    {
        public List<IShip> _ships { get; private set; } = new List<IShip>();
        public List<ICell> _cells { get; private set; } = new List<ICell>();
        public int Size { get; private set; }

        public Board(int size)
        {
            Size = size > 0 ? size
                : throw new ArgumentException(nameof(size));

            GenerateBoard(size);
        }

        private bool IsShipValid(IShip ship)
        {
            return true;
        }

        private void GenerateBoard(int size)
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    _cells.Add(Cell.New(Position.New(x, y)));           
        }

        public void AddShip(IShip ship)
        {
            if (IsShipValid(ship))
                _ships.Add(ship);
            else
                throw new ArgumentException(nameof(ship));

            foreach(ICell shipCell in ship.Cells)
            {
                foreach (ICell boardCell in _cells)
                {
                    if (boardCell.Position.Equals(shipCell.Position))
                    {
                        boardCell.SetState(State.Busy);
                    }
                }
            }
        }
        public void RemoveShip(IShip ship)
        {
            _ships.Remove(ship);
        }
        //public void HitTheCell(ICell cell) => _ships.ForEach(x => x.UpdateStatus(cell));
        public void HitTheCell(ICell cell)
        {
            _ships.ForEach(x => x.UpdateStatus(cell));//??

            foreach (ICell c in _cells)
            {
                if (c.Position.Equals(cell.Position))
                {
                    if (c.State.Equals(State.Busy))
                        c.SetState(State.OnFire);
                    else if (c.State.Equals(State.Empty))
                        c.SetState(State.Checked);
                }
            }

        }

        public ICell FindCell(Position position) => _cells.SingleOrDefault(x => x.Position.Equals(position));

        public List<ICell> GetCellsOnFire() => _cells.FindAll(x => x.State==State.OnFire);

        public IEnumerable<ICell> GetCellsInDirection(ICell startCell, int numberOfCells, Directions directions)
        {
            if (numberOfCells <= 0)
                throw new ArgumentException(nameof(numberOfCells));
            if (startCell.Position.X + numberOfCells > Size || startCell.Position.Y + numberOfCells > Size)
                throw new InvalidOperationException($"Board is too small; {Size}");

            var result = new List<ICell>();
            for(int i = 0; i < numberOfCells; i++)
            {
                Position nextPosition = null;
                switch (directions)
                {
                    case Directions.Horizontally:
                        nextPosition = Position.New(startCell.Position.X + 1, startCell.Position.Y);
                        break;
                    case Directions.Vertivally:
                        nextPosition = Position.New(startCell.Position.X, startCell.Position.Y + 1);
                        break;
                }
                result.Add(FindCell(nextPosition));
            }
            return result;
        }
    }
}