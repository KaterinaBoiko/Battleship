using Battleship.Abstracts;
using Battleship.Enums;
using Battleship.Interfaces;
using Battleship.Values;
using System;

namespace Battleship.Classes
{
    public class DefaultBuilder : BoardBuilder
    {
        public static readonly int defaultSize = 10;
        public DefaultBuilder()
           : base(defaultSize)
        { }
        public override IBoard CreateBoard()
        {
            Random rnd = new Random();
            int x = rnd.Next(_board.Size);
            int y = rnd.Next(_board.Size);
            var enums = Enum.GetValues(typeof(Directions));
            Directions direction = (Directions)enums.GetValue(rnd.Next(enums.Length));

            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 5 - i; j++)
                {
                    IShip ship = Ship.New(i, Cell.New(Position.New(x, y)), direction);
                    while (!_board.IsShipFit(ship)){
                        x = rnd.Next(_board.Size);
                        y = rnd.Next(_board.Size);
                        direction = (Directions)enums.GetValue(rnd.Next(enums.Length));
                        ship = Ship.New(i, Cell.New(Position.New(x, y)), direction);
                    }
                    BuildShip(i, Position.New(x, y), direction);
                }
            }
            return _board;
        }
    }
}
