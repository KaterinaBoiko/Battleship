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
        public int SunkenCells { get; private set; } = 0;

        public Board(int size)
        {
            Size = size > 0 ? size
                : throw new ArgumentException(nameof(size));

            GenerateBoard(size);
        }
        private void GenerateBoard(int size)
        {
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    _cells.Add(Cell.New(Position.New(x, y)));
        }

        public void AddShip(IShip ship)
        {
            _ships.Add(ship);

            var shipCells = GetCellsInDirection(ship.FirstCell, ship.DeckNumber, ship.Direction);

            foreach (ICell shipCell in shipCells)
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
        public void HitTheCell(ICell cell)
        {
            foreach (ICell c in _cells)
            {
                if (c.Position.Equals(cell.Position))
                {
                    if (c.State.Equals(State.Busy))
                    {
                        c.SetState(State.OnFire);
                        SunkenCells++;
                    }
                    else if (c.State.Equals(State.Empty))
                        c.SetState(State.Checked);
                }
            }

        }
        public ICell FindCell(Position position) => _cells.SingleOrDefault(x => x.Position.Equals(position));

        public List<ICell> GetCellsOnFire() => _cells.FindAll(x => x.State == State.OnFire);

        public IEnumerable<ICell> GetCellsInDirection(ICell startCell, int numberOfCells, Directions directions)
        {
            if (numberOfCells <= 0)
                throw new ArgumentException(nameof(numberOfCells));
            //if (startCell.Position.X + numberOfCells > Size || startCell.Position.Y + numberOfCells > Size)
            //    throw new InvalidOperationException($"Board is too small; {Size}");

            var result = new List<ICell>() { FindCell(startCell.Position) };
            Position nextPosition = startCell.Position;
            for (int i = 0; i < numberOfCells - 1; i++)
            {
                switch (directions)
                {
                    case Directions.Horizontally:
                        nextPosition = Position.New(nextPosition.X + 1, nextPosition.Y);
                        break;
                    case Directions.Vertically:
                        nextPosition = Position.New(nextPosition.X, nextPosition.Y + 1);
                        break;
                }
                result.Add(FindCell(nextPosition));
            }
            return result;
        }

        public bool IsShipFit(IShip ship)
        {
            int xStart, xEnd, yStart, yEnd;
            if (ship.FirstCell.Position.X == 0) xStart = 0;
            else xStart = ship.FirstCell.Position.X - 1;

            if (ship.FirstCell.Position.Y == 0) yStart = 0;
            else yStart = ship.FirstCell.Position.Y - 1;

            if (ship.FirstCell.Position.X + ship.DeckNumber > Size && ship.Direction.Equals(Directions.Horizontally))
                return false;
            else if (ship.FirstCell.Position.X + ship.DeckNumber == Size) xEnd = 9;
            else xEnd = ship.FirstCell.Position.X + ship.DeckNumber;

            if (ship.FirstCell.Position.Y + ship.DeckNumber > Size && ship.Direction.Equals(Directions.Vertically))
                return false;
            else if (ship.FirstCell.Position.Y + ship.DeckNumber == Size) yEnd = 9;
            else yEnd = ship.FirstCell.Position.Y + ship.DeckNumber;


            if (ship.Direction.Equals(Directions.Horizontally))
            {
                for (int x = xStart; x <= xEnd; x++)
                {
                    for (int y = yStart; y <= yStart + 2; y++)
                    {
                        ICell cell = FindCell(Position.New(x, y));
                        if (cell != null && cell.State.Equals(State.Busy))
                            return false;
                    }
                }
            }
            else
            {
                for (int x = xStart; x <= xStart + 2; x++)
                {
                    for (int y = yStart; y <= yEnd; y++)
                    {
                        ICell cell = FindCell(Position.New(x, y));
                        if (cell != null && cell.State.Equals(State.Busy))
                            return false;
                    }
                }
            }
            return true;
        }
        public bool Lose()
        {
            if (SunkenCells == 20)
                return true;
            else
                return false;
        }
    }
}