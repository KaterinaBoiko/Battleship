using Battleship.Interfaces;
using Battleship.Values;
using SeaBattle.Enums;
using System;
using System.Collections.Generic;

namespace Battleship.Classes.Strategy
{
    class StrategyForUser : IStrikeStrategy
    {
        public void StrikeCell(IPlayer player, IBoard board, params ICell[] cells)
        {
            ICell cellToShot = board.FindCell(Position.New(cells[0].Position.X, cells[0].Position.Y));
            if (cellToShot.State == State.OnFire || cellToShot.State == State.Checked)
                throw new Exception("You have already checked this cell.");

            board.HitTheCell(cells[0]);
        }
    }
}
