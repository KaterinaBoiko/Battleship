using Battleship.Enums;
using Battleship.Interfaces;
using SeaBattle.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Classes
{
    public class Ship : IShip
    {
        public int DeckNumber { get; } 
        public IEnumerable<ICell> Cells { get; }
        public Directions Direction { get; }
        public Ship(int number, IEnumerable<ICell> cells, Directions direction)
        {
            DeckNumber = number > 0 ? 
                number : throw new ArgumentException($"Number of decks must be grater than 0; Number of decks: {number}");

            Cells = IsShipCorrect(cells, direction) ? 
                cells : throw new ArgumentException(nameof(cells));

            Direction = direction;

            //foreach (ICell cell in Cells)
            //    cell.SetState(State.Busy);
        }

        private bool IsShipCorrect(IEnumerable<ICell> start, Directions direction)
        {
            return true;
        }

        public void UpdateStatus(ICell cell)
        {
            var cellToUpdate = Cells.SingleOrDefault(x => x.Equals(cell));
            //if (cellToUpdate != null)
            //{
            //    cell.SetState(State.OnFire);
            //}
        }

        public bool Equals(IShip other)
        {
            if (ReferenceEquals(other, null))
                return ReferenceEquals(this, null);

            var areCellsEqual = true;
            foreach (var cell in Cells)
                if(!other.Cells.Any(x => x.Equals(cell)))
                {
                    areCellsEqual = false;
                    break;
                }

            return DeckNumber.Equals(other.DeckNumber)
                && areCellsEqual && Direction.Equals(other.Direction);
        }

        public override bool Equals(object obj) => Equals(obj as IShip);

        public override int GetHashCode()
        {
            unchecked
            {
                var code = DeckNumber.GetHashCode() + Cells.GetHashCode() + Direction.GetHashCode() + base.GetHashCode();
                return code;
            }
        }

        public static IShip New(int number, IEnumerable<ICell> cells, Directions direction) => new Ship(number, cells, direction);
    }
}
