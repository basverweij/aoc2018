namespace Aoc2018.Day05.Common
{
    public class Unit
    {
        public char Char { get; set; }

        public Unit Previous { get; set; }

        public Unit Next { get; set; }

        public Unit(char @char, Unit previous)
        {
            Char = @char;

            if (previous != null)
            {
                Previous = previous;
                previous.Next = this;
            }
        }
    }
}
