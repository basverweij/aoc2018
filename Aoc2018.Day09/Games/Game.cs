using System.Linq;

namespace Aoc2018.Day09.Games
{
    public static class Game
    {
        public static int HighestScore(int playerCount, int lastMarble)
        {
            var scores = new int[playerCount];

            var circle = new Circle();

            var player = 0;

            for (var marble = 1; marble <= lastMarble; marble++, player = (player + 1) % playerCount)
            {
                if (marble % 23 == 0)
                {
                    scores[player] += marble;

                    var remove = circle
                        .Current
                        .Previous.Previous.Previous.Previous.Previous.Previous.Previous; // 7 marbles counter clockwise

                    scores[player] += remove.Value;

                    remove.Previous.Next = remove.Next;
                    remove.Next.Previous = remove.Previous;

                    circle.Current = remove.Next;

                    continue;
                }

                var m = new Marble(marble);

                var insertAfter = circle.Current.Next; // 1 marble clockwise

                m.Previous = insertAfter;
                m.Next = insertAfter.Next;

                insertAfter.Next.Previous = m;
                insertAfter.Next = m;

                circle.Current = m;
            }

            return scores.Max();
        }
    }
}
