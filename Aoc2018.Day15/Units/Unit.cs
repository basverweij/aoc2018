using System;

namespace Aoc2018.Day15.Units
{
    public class Unit
    {
        public UnitTypes UnitType { get; }

        public Location Location { get; set; }

        public int HitPoints { get; private set; }

        public int AttackPower { get; }

        public Unit(UnitTypes unitType, Location location, int hitPoints, int attackPower)
        {
            UnitType = unitType;
            Location = location;
            HitPoints = hitPoints;
            AttackPower = attackPower;
        }

        public void TakeHit(int attackPower)
        {
            HitPoints -= attackPower;

            if (HitPoints < 0)
            {
                HitPoints = 0;
            }
        }

        public bool IsAlive => HitPoints > 0;

        public override string ToString()
        {
            return $"{UnitType} ^{HitPoints} !{AttackPower} @{Location}";
        }
    }

    public enum UnitTypes
    {
        Elf,
        Goblin,
    }

    public struct Location
    {
        public readonly int X;

        public readonly int Y;

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Location))
            {
                return false;
            }

            var location = (Location)obj;

            return X == location.X &&
                   Y == location.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
