using Battleship.Interfaces;
using System;

namespace Battleship.Classes.Strategy
{
    class SeveralPaddedCellStrategy : IStrikeStrategy
    {
        public void StrikeCell(IPlayer player, IBoard board, params ICell[] cells)
        {

            Bot bot = (Bot)player;
            bot.ChangeStrategy(new NoPaddedCellStrategy());

        }
    }
}
