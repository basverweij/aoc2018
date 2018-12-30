using Aoc2018.Day15.Units;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day15.Games
{
    public class DefaultAttackStrategy :
        IAttackStrategy
    {
        public void Attack(Unit unit, IEnumerable<Unit> targets)
        {
            var target = targets
                .OrderBy(u => u.HitPoints) // lowest hit points
                .ThenBy(u => u.Location.Y) // resolve ties by reading order
                .ThenBy(u => u.Location.X) // resolve ties by reading order
                .First();

            target.TakeHit(unit.AttackPower);
        }
    }
}
