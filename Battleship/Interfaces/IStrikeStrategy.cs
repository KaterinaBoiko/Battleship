namespace Battleship.Interfaces
{
    public interface IStrikeStrategy
    {
        void StrikeCell(IBoard board, params ICell[] cells);
    }
}
