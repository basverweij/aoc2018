namespace Aoc2018.Day09.Games
{
    public class Marble
    {
        public int Value { get; set; }

        public Marble Next { get; set; }

        public Marble Previous { get; set; }

        public Marble(int value)
        {
            Value = value;
        }
    }
}