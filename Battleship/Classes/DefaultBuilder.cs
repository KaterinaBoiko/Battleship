using Battleship.Abstracts;
using Battleship.Enums;
using Battleship.Interfaces;
using Battleship.Values;

namespace Battleship.Classes
{
    public class DefaultBuilder : BoardBuilder
    {
        public static readonly int defaultSize = 10;
        public DefaultBuilder()
           : base(defaultSize)
        { }
        //one method!!
        //public override void AddFourDeckShip(Position position, Directions shipDirection) => BuildShip(4, position, shipDirection);

        //public override void AddThreeDeckShip(Position position, Directions shipDirection) => BuildShip(3, position, shipDirection);

        //public override void AddTwoDeckShip(Position position, Directions shipDirection) => BuildShip(2, position, shipDirection);

        //public override void AddOneDeckShip(Position position, Directions shipDirection) => BuildShip(1, position, shipDirection);

        public override IBoard CreateBoard()
        {
            //creating board
            for(int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 5 - i; j++)
                    //BuildShip(i, position, shipDirection);
                    ;
            }
            return _board;
        }
    }
}
