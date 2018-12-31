using System;

namespace Aoc2018.Day15.Games
{
    public class NoTargetsReachableException :
        Exception
    {
        public NoTargetsReachableException(string message) :
            base(message)
        { }
    }
}
