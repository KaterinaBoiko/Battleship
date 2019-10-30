using System;

namespace Battleship.Values
{
    public class Position : IEquatable<Position>
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public bool Equals(Position other)
        {
            if (ReferenceEquals(other, null))
                return ReferenceEquals(this, null);

            return X.Equals(other.X)
            && Y.Equals(other.Y);
        }

        public override bool Equals(object obj) => Equals(obj as Position);

        public override int GetHashCode()
        {
            unchecked
            {
                var code = X.GetHashCode() + Y.GetHashCode() + base.GetHashCode();
                return code;
            }
        }

        public static Position New(int x, int y) => new Position() { X = x, Y = y };
    }
}
