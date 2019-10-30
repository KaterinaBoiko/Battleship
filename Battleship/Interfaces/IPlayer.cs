using Battleship.Abstracts;

namespace Battleship.Interfaces
{
    public interface IPlayer
    {
        IStrikeStrategy Strategy { get; }
        IBoard Board { get; }
        void Strike(params ICell[] cells);
    }
}
