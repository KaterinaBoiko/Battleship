using Battleship.Interfaces;
using Battleship.Values;
using SeaBattle.Enums;
using System;
using System.Collections.Generic;

namespace Battleship.Classes.Strategy
{
    class OnePaddedCellStrategy : IStrikeStrategy
    {
        public void StrikeCell(IBoard board, params ICell[] cells)
        {
            List<ICell> cellsOnFire = board.GetCellsOnFire();
            var random = new Random();
            int index = random.Next(cellsOnFire.Count);
            ICell cellToHit = board.FindCell(cellsOnFire[index].Position);
            int hit = random.Next(4);
            switch (hit)
            {
                case 0:
                    board.HitTheCell(board.FindCell(Position.New(cellToHit.Position.X + 1, cellToHit.Position.Y)));
                    break;
                case 1:
                    board.HitTheCell(board.FindCell(Position.New(cellToHit.Position.X, cellToHit.Position.Y - 1)));
                    break;
                case 2:
                    board.HitTheCell(board.FindCell(Position.New(cellToHit.Position.X - 1, cellToHit.Position.Y)));
                    break;
                case 3:
                    board.HitTheCell(board.FindCell(Position.New(cellToHit.Position.X, cellToHit.Position.Y + 1)));
                    break;
            }
        }
    }
}
