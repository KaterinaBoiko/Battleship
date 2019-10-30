using Battleship.Interfaces;

namespace Battleship.Classes
{
    public class Game
    {
        private static Game instance;
        public IPlayer Player { get; }
        public IPlayer Bot { get; }

        private Game(IPlayer player, IPlayer bot)
        {
            Player = player;
            Bot = bot;
        }

        public static Game getInstance(IPlayer player, IPlayer bot)
        {
            if (instance == null)
                instance = new Game(player, bot);
            return instance;
        }
    }
}
