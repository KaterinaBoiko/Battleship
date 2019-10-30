using Battleship.Interfaces;
using Battleship.Values;
using SeaBattle.Enums;
using System;

namespace Battleship.Classes
{
    public class Cell : ICell
    {
        public Position Position { get; }
        public State State { get; private set; }

        public Cell(Position position)
        {
            this.Position = position
                ?? throw new ArgumentNullException(nameof(position));
            this.State = State.Empty;
        }

        public void SetState(State state)
        {
            State = state;
        }

        public bool Equals(ICell other)
        {
            if (ReferenceEquals(other, null))
                return ReferenceEquals(this, null);

            return Position.Equals(other.Position);
        }

        public override bool Equals(object obj) => Equals(obj as ICell);

        public override int GetHashCode()
        {
            unchecked
            {
                var code = Position.GetHashCode() + State.GetHashCode() + base.GetHashCode();
                return code;
            }
        }

        public static ICell New(Position position) => new Cell(position);
    }
}
