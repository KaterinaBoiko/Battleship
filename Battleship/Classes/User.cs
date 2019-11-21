using Battleship.Abstracts;
using Battleship.Classes.Strategy;
using Battleship.Interfaces;
using System;

namespace Battleship.Classes
{
    public class User : IPlayer
    {
        public IBoard Board { get; private set; }
        //public IBoard OpponentBoard { get; p }
        public IStrikeStrategy Strategy { get; private set; }

        public User(BoardBuilder builder)
        {
            Board = builder.CreateBoard();
            Strategy = new StrategyForUser();
        }
        public bool Lose()
        {
            if (Board.SunkenCells == 20) return true;
            return false;
        }
        public void Strike(IBoard opponentBoard, params ICell[] cells) => Strategy.StrikeCell(this, opponentBoard, cells[0]);
    }
}
