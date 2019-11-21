using Battleship.Abstracts;
using Battleship.Classes.Strategy;
using Battleship.Interfaces;

namespace Battleship.Classes
{
    public class Bot : IPlayer
    {
        public IBoard Board { get; private set; }
        public IStrikeStrategy Strategy { get; private set; }

        public Bot(BoardBuilder builder)
        {
            Board = builder.CreateBoard();
            Strategy = new NoPaddedCellStrategy();
        }
        public void Strike(IBoard opponentBoard, params ICell[] cells) => Strategy.StrikeCell(this, opponentBoard);
        public void ChangeStrategy(IStrikeStrategy str)
        {
            Strategy = str;
        }
        public bool Lose()
        {
            if (Board.SunkenCells == 20) return true;
            return false;
        }
    }
}
