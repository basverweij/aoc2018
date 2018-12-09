namespace Aoc2018.Day09.Games
{
    public class Circle
    {
        public int Size { get; }

        public Marble Current { get; set; }

        public Circle()
        {
            Size = 1;

            Current = new Marble(0);
            Current.Next = Current;
            Current.Previous = Current;
        }
    }
}
