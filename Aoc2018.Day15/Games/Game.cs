using Aoc2018.Day15.Areas;
using Aoc2018.Day15.Common;
using Aoc2018.Day15.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day15.Games
{
    public class Game
    {
        public Area Area { get; }

        public IMoveStrategy MoveStrategy { get; }

        public IAttackStrategy AttackStrategy { get; }

        private readonly Unit[] _units;

        private int _round = 0;

        public Game(Area area, IMoveStrategy moveStrategy, IAttackStrategy attackStrategy)
        {
            Area = area ?? throw new ArgumentNullException(nameof(area));
            MoveStrategy = moveStrategy ?? throw new ArgumentNullException(nameof(moveStrategy));
            AttackStrategy = attackStrategy ?? throw new ArgumentNullException(nameof(attackStrategy));

            // copy units from area
            _units = area
                .GetUnits()
                .ToArray();
        }

        public IEnumerable<Unit> Units => _units;

        public int Score =>
            _round *
            _units
                .Where(u => u.IsAlive)
                .Sum(u => u.HitPoints);

        /// <summary>
        /// Returns false if the combat has ended (i.e. no targets remained for one of the units).
        /// </summary>
        /// <returns></returns>
        public bool Turn()
        {
            var units = _units
                .Where(u => u.IsAlive)
                .OrderBy(u => u.Location.Y)
                .ThenBy(u => u.Location.X)
                .ToArray();

            // save current locations as these could be changed during the turn
            var targetsForType = Enum
                .GetValues(typeof(UnitTypes))
                .Cast<UnitTypes>()
                .ToDictionary(
                    t => t,
                    t => units.Where(u => u.UnitType != t));

            for (var i = 0; i < units.Length; i++)
            {
                if (!units[i].IsAlive)
                {
                    // unit was killed during the turn
                    continue;
                }

                // get move targets
                var moveTargets = targetsForType[units[i].UnitType]
                    .Where(u => u.IsAlive)
                    .Select(u => u.Location);

                if (!moveTargets.Any())
                {
                    return false;
                }

                // unit moves
                var newLocation = MoveStrategy.Move(units[i], Area, moveTargets);

                if (newLocation.HasValue)
                {
                    Area.MoveUnit(units[i], newLocation.Value);
                }

                // get attack targets
                var attackTargets = units
                    .Where(u => u.IsAlive) // not killed in this turn
                    .Where(u => u.UnitType != units[i].UnitType) // enemy
                    .Where(u => IsInRange(units[i].Location, u.Location)); // in range

                if (attackTargets.Any())
                {
                    // unit attacks
                    AttackStrategy.Attack(units[i], attackTargets);
                }
            }

            _round++;

            return true;
        }

        private bool IsInRange(Location location, Location attackLocation)
        {
            return
                (location.X == attackLocation.X && MathUtil.Abs(location.Y - attackLocation.Y) == 1) ||
                (location.Y == attackLocation.Y && MathUtil.Abs(location.X - attackLocation.X) == 1);
        }
    }

    public interface IMoveStrategy
    {
        /// <summary>
        /// Returns the new location for the unit, or null if the unit should not move.
        /// </summary>
        Location? Move(Unit unit, Area area, IEnumerable<Location> targets);
    }

    public interface IAttackStrategy
    {
        void Attack(Unit unit, IEnumerable<Unit> targets);
    }

    #region Null Strategies
    public class NullMoveStrategy :
        IMoveStrategy
    {
        public Location? Move(Unit unit, Area area, IEnumerable<Location> targets)
        {
            // do nothing
            return null;
        }
    }

    public class NullAttackStrategy :
        IAttackStrategy
    {
        public void Attack(Unit unit, IEnumerable<Unit> targets)
        {
            // do nothing
        }
    }
    #endregion
}
