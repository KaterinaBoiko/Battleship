using Battleship.Interfaces;
using Battleship.Values;
using SeaBattle.Enums;
using System;
namespace Battleship.Classes.Strategy
{
    class NoPaddedCellStrategy : IStrikeStrategy
    {
        public void StrikeCell(IBoard board, params ICell[] cells)
        {
            Random rnd = new Random();
            int x = rnd.Next(board.Size);
            int y = rnd.Next(board.Size);
            ICell cellToHit = board.FindCell(Position.New(x, y));
            while (cellToHit.State!=State.Empty || cellToHit.State != State.Busy)
            {
                x = rnd.Next(board.Size);
                y = rnd.Next(board.Size);
                cellToHit = board.FindCell(Position.New(x, y));
            }

            board.HitTheCell(cellToHit);
        }
    }
}
