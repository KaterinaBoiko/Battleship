using Battleship.Abstracts;
using Battleship.Classes.Strategy;
using Battleship.Interfaces;
using System.Collections.Generic;

namespace Battleship.Classes
{
    public class Game
    {
        private static Game instance;
        public static IBoard UserBoard { get; private set; }
        public static IBoard BotBoard { get; private set; }
        public static IBotStrikeStrategy BotStrategy { get; private set; }
        public static StrategyForUser UserStrategy { get; private set; } = new StrategyForUser();
        private static readonly List<IBotStrikeStrategy> strategies = new List<IBotStrikeStrategy>
        {
            new NoPaddedCellStrategy(),
            new OnePaddedCellStrategy(),
            //new SeveralPaddedCellStrategy()
        };

        private Game(BoardBuilder userBuilder, BoardBuilder botBuilder)
        {
            UserBoard = userBuilder.CreateBoard();
            BotBoard = botBuilder.CreateBoard();
            BotStrategy = strategies[0];
        }

        public static Game getInstance(BoardBuilder userBuilder, BoardBuilder botBuilder)
        {
            if (instance == null)
                instance = new Game(userBuilder, botBuilder);
            return instance;
        }

        public static void ChangeBotStrategy()
        {
            int newIndex = strategies.IndexOf(BotStrategy);
            if (newIndex == 1)
                BotStrategy = strategies[0];
            else
                BotStrategy = strategies[++newIndex];
        }

    }
}
