namespace Aoc2018.Day02
{
    public static class CharacterCounter
    {
        public static int[] CountCharacters(string s)
        {
            var result = new int[26];

            foreach (var c in s)
            {
                result[c - 'a']++;
            }

            return result;
        }
    }
}
