using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day14.Recipes
{
    public class Kitchen
    {
        private int _elf1;

        private int _elf2;

        private readonly List<int> _recipes = new List<int>();

        public Kitchen()
        {
            _recipes.Add(3);
            _elf1 = 0;

            _recipes.Add(7);
            _elf2 = 1;
        }

        public int Cook()
        {
            var newRecipe = _recipes[_elf1] + _recipes[_elf2];

            if (newRecipe > 9)
            {
                _recipes.Add(1);
            }

            _recipes.Add(newRecipe % 10);

            var n = _recipes.Count;

            _elf1 = (_elf1 + 1 + _recipes[_elf1]) % n;

            _elf2 = (_elf2 + 1 + _recipes[_elf2]) % n;

            return n;
        }

        public string Recipes(int from, int count)
        {
            return string.Join("", _recipes.Skip(from).Take(count));
        }

        public int NumRecipesBeforeEndsWith(int[] scores)
        {
            var num = NumRecipesBeforeEndsWith(scores, 1);
            if (num >= 0)
            {
                return num;
            }

            return NumRecipesBeforeEndsWith(scores, 0);
        }

        private int NumRecipesBeforeEndsWith(int[] scores, int offset)
        {
            if (_recipes.Count - offset < scores.Length)
            {
                return -1;
            }

            for (int i = scores.Length - 1, j = _recipes.Count - offset - 1; i >= 0; i--, j--)
            {
                if (scores[i] != _recipes[j])
                {
                    return -1;
                }
            }

            return _recipes.Count - scores.Length - offset;
        }
    }
}
