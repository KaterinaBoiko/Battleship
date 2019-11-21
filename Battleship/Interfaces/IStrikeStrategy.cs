namespace Battleship.Interfaces
{
    public interface IStrikeStrategy
    {
        void StrikeCell(IPlayer player, IBoard board, params ICell[] cells);
    }
}
