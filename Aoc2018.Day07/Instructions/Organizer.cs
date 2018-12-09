using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2018.Day07.Instructions
{
    public static class Organizer
    {
        public static string OrganizeInstructions(IEnumerable<Instruction> instructions)
        {
            // get the required steps for each step
            var requiredSteps = new Dictionary<char, HashSet<char>>();

            foreach (var i in instructions)
            {
                if (!requiredSteps.TryGetValue(i.ForStep, out var steps))
                {
                    steps = new HashSet<char>();
                    requiredSteps[i.ForStep] = steps;
                }

                steps.Add(i.RequiredStep);

                // also add the required step to lookup
                if (!requiredSteps.TryGetValue(i.RequiredStep, out steps))
                {
                    steps = new HashSet<char>();
                    requiredSteps[i.RequiredStep] = steps;
                }
            }

            // process steps in order
            var result = new StringBuilder();

            var completedSteps = new HashSet<char>();

            while (completedSteps.Count != requiredSteps.Count)
            {
                var nextStep = requiredSteps
                    .Where(kvp =>
                        !completedSteps.Contains(kvp.Key) &&
                        kvp.Value.All(completedSteps.Contains))
                    .OrderBy(kvp => kvp.Key)
                    .First()
                    .Key;

                result.Append(nextStep);

                completedSteps.Add(nextStep);
            }

            return result.ToString();
        }
    }
}
