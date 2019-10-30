using Battleship.Classes;
using Battleship.Enums;
using Battleship.Interfaces;
using Battleship.Values;
using System;

namespace Battleship.Abstracts
{
    public abstract class BoardBuilder
    {
        protected IBoard _board { get; private set; }

        //public BoardBuilder(IBoard board)
        //{
        //    _board = board
        //        ?? throw new ArgumentNullException(nameof(board));
        //}

        public BoardBuilder(int size)
        {
            IBoard board = new Board(size);
            _board = board
                ?? throw new ArgumentNullException(nameof(board));
        }
        //public abstract void AddFourDeckShip(Position position, Directions shipDirection);
        //public abstract void AddThreeDeckShip(Position position, Directions shipDirection);
        //public abstract void AddTwoDeckShip(Position position, Directions shipDirection);
        //public abstract void AddOneDeckShip(Position position, Directions shipDirection);
        protected void BuildShip(int numberOfDecks, Position position, Directions shipDirection)
        {
           var ship = Ship.New(numberOfDecks,
                _board.FindCell(position),
                shipDirection);

            _board.AddShip(ship);
        }
        public abstract IBoard CreateBoard();
    }
}
