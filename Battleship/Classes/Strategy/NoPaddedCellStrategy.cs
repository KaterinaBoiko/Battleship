using Battleship.Interfaces;
using Battleship.Values;
using SeaBattle.Enums;
using System;
namespace Battleship.Classes.Strategy
{
    class NoPaddedCellStrategy : IStrikeStrategy
    {
        public void StrikeCell(IPlayer player, IBoard board, params ICell[] cells)
        {
            Random rnd = new Random();
            int x = rnd.Next(board.Size);
            int y = rnd.Next(board.Size);
            ICell cellToHit = board.FindCell(Position.New(x, y));
            while (cellToHit.State.Equals(State.Checked) || cellToHit.State.Equals(State.OnFire))
            {
                x = rnd.Next(board.Size);
                y = rnd.Next(board.Size);
                cellToHit = board.FindCell(Position.New(x, y));
            }
            board.HitTheCell(cellToHit);

            //change strategy only if shoot the ship!
            //Bot bot = (Bot)player;
            //bot.ChangeStrategy(new OnePaddedCellStrategy());
        }
    }
}
