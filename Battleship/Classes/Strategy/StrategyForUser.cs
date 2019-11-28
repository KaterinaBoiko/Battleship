using Battleship.Interfaces;
using Battleship.Values;
using SeaBattle.Enums;
using System;
using System.Collections.Generic;

namespace Battleship.Classes.Strategy
{
    public class StrategyForUser
    {
        public void StrikeCell(IBoard board, ICell cell)
        {
            ICell cellToShot = board.FindCell(Position.New(cell.Position.X, cell.Position.Y));
            if (cellToShot.State == State.OnFire || cellToShot.State == State.Checked)
                throw new Exception("You have already checked this cell.");

            board.HitTheCell(cell);
        }
    }
}
