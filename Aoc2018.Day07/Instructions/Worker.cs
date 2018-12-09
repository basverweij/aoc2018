namespace Aoc2018.Day07.Instructions
{
    public class Worker
    {
        public char? WorkingOn { get; set; }

        public int FinishesAt { get; set; }

        public override string ToString()
        {
            return $"WorkingOn = {WorkingOn}, FinishesAt = {FinishesAt}";
        }
    }
}
