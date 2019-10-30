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
        public ICell FirstCell { get; }
        public Directions Direction { get; }
        public Ship(int number, ICell fcell, Directions direction)
        {
            DeckNumber = number > 0 ? 
                number : throw new ArgumentException($"Number of decks must be grater than 0; Number of decks: {number}");

            FirstCell = fcell;

            Direction = direction;
        }

        public bool Equals(IShip other)
        {
            if (ReferenceEquals(other, null))
                return ReferenceEquals(this, null);

            return DeckNumber.Equals(other.DeckNumber)
                && FirstCell.Equals(other.FirstCell) && Direction.Equals(other.Direction);
        }

        public override bool Equals(object obj) => Equals(obj as IShip);

        public override int GetHashCode()
        {
            unchecked
            {
                var code = DeckNumber.GetHashCode() + FirstCell.GetHashCode() + Direction.GetHashCode() + base.GetHashCode();
                return code;
            }
        }

        public static IShip New(int number, ICell fcell, Directions direction) => new Ship(number, fcell, direction);
    }
}
