namespace Aoc2018.Day02
{
    public static class IdMatcher
    {
        public static string MatchIds(string[] ids)
        {
            var counts = new int[ids.Length][];

            for (var i = 0; i < ids.Length; i++)
            {
                counts[i] = CharacterCounter.CountCharacters(ids[i]);
            }

            for (var i = 0; i < ids.Length; i++)
            {
                for (var j = i + 1; j < ids.Length; j++)
                {
                    var index = SingleDifferentCharacterIndex(ids[i], ids[j]);

                    if (index >= 0)
                    {
                        return ids[i].Substring(0, index) + ids[i].Substring(index + 1, ids[i].Length - index - 1);
                    }
                }
            }

            return null;
        }

        static int SingleDifferentCharacterIndex(string id1, string id2)
        {
            var index = -1;

            for (var i = 0; i < id1.Length; i++)
            {
                if (id1[i] != id2[i])
                {
                    if (index >= 0)
                    {
                        // already found another character that differs
                        return -1;
                    }

                    index = i;
                }
            }

            return index;
        }
    }
}
