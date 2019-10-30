using Battleship.Values;
using SeaBattle.Enums;
using System;

namespace Battleship.Interfaces
{
    public interface ICell : IEquatable<ICell>
    {
        Position Position { get; }
        State State { get; }
        void SetState(State state);
    }
}
