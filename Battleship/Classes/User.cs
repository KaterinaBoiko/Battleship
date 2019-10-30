using Battleship.Abstracts;
using Battleship.Classes.Strategy;
using Battleship.Interfaces;
using System;

namespace Battleship.Classes
{
    public class User : IPlayer
    {
        public IBoard Board { get; private set; }
        public IStrikeStrategy Strategy { get; private set; }

        public User(BoardBuilder builder)
        {
            Board = builder.CreateBoard();
            Strategy = new StrategyForUser();
        }

        public void Strike(params ICell[] cells) => Strategy.StrikeCell(Board, cells[0]);
    }
}
