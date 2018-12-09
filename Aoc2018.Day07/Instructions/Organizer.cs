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
            var requiredSteps = BuildRequiredSteps(instructions);

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

        public static int GetBuildTime(IEnumerable<Instruction> instructions, int workerCount, int baseLineSecondsPerStep)
        {
            // get the required steps for each step
            var requiredSteps = BuildRequiredSteps(instructions);

            // process steps in order
            var time = 0;

            var workers = Enumerable
                .Range(0, workerCount)
                .Select(i => new Worker())
                .ToArray();

            var completedSteps = new HashSet<char>();

            while (true)
            {
                // update time
                time = workers.Min(w => w.FinishesAt);

                // get workers finished at this time
                var finishedWorkers = workers
                    .Where(w => w.FinishesAt == time)
                    .ToArray();

                // add completed steps at this time
                foreach (var w in finishedWorkers.Where(w => w.WorkingOn.HasValue))
                {
                    completedSteps.Add(w.WorkingOn.Value);
                    w.WorkingOn = null;
                }

                if (completedSteps.Count == requiredSteps.Count)
                {
                    break;
                }

                var worker = finishedWorkers.First();

                var nextSteps = requiredSteps
                    .Where(kvp =>
                        !completedSteps.Contains(kvp.Key) &&
                        !workers.Any(w => w.WorkingOn == kvp.Key) &&
                        kvp.Value.All(completedSteps.Contains))
                    .OrderBy(kvp => kvp.Key);

                if (nextSteps.Any())
                {
                    var nextStep = nextSteps.First().Key;

                    worker.WorkingOn = nextStep;

                    worker.FinishesAt = time + baseLineSecondsPerStep + (nextStep - 'A' + 1);
                }
                else
                {
                    // no steps available -> worker is idle until first other worker finishes
                    worker.WorkingOn = null;

                    worker.FinishesAt = workers
                        .Where(w => w != worker && w.WorkingOn.HasValue)
                        .Min(w => w.FinishesAt);
                }
            }

            return time;
        }

        private static Dictionary<char, HashSet<char>> BuildRequiredSteps(IEnumerable<Instruction> instructions)
        {
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

            return requiredSteps;
        }
    }
}
