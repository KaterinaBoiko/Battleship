using Battleship.Interfaces;
using SeaBattle.Enums;
using System;

namespace Battleship.Classes.Strategy
{
    class StrategyForUser : IStrikeStrategy
    {
        public void StrikeCell(IBoard board, params ICell[] cells)
        {
            if (cells[0].State == State.OnFire || cells[0].State == State.Checked)
                throw new Exception("You have already checked this cell.");

            board.HitTheCell(cells[0]);
        }
    }
}
