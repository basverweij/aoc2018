using System.Collections.Generic;

namespace Aoc2018.Day13.Tracks
{
    public class Section
    {
        public SectionTypes SectionType { get; }

        public Section(SectionTypes sectionType)
        {
            SectionType = sectionType;
        }

        public void ExitSection(Cart cart)
        {
            UpdateCart(cart, xOffset: DIRECTION_X_OFFSET[cart.Direction], yOffset: DIRECTION_Y_OFFSET[cart.Direction]);
        }

        public void EnterSection(Cart cart)
        {
            switch (SectionType)
            {
                case SectionTypes.SlopeRight:   // "/"
                    UpdateCart(cart, direction: SLOPE_RIGHT_DIRECTION_CHANGE[cart.Direction]);
                    break;

                case SectionTypes.SlopeLeft:    // "\"
                    UpdateCart(cart, direction: SLOPE_LEFT_DIRECTION_CHANGE[cart.Direction]);
                    break;

                case SectionTypes.Intersection: // "+"
                    UpdateCart(cart, direction: INTERSECTION_DIRECTION_CHANGES[cart.IntersectionCount % 3][cart.Direction]);
                    cart.IntersectionCount++;
                    break;
            }
        }

        private void UpdateCart(Cart cart, int xOffset = 0, int yOffset = 0, Directions? direction = null)
        {
            cart.Location.X += xOffset;
            cart.Location.Y += yOffset;

            if (direction.HasValue)
            {
                cart.Direction = direction.Value;
            }
        }

        private static readonly IDictionary<Directions, int> DIRECTION_X_OFFSET = new Dictionary<Directions, int>()
        {
            {Directions.Down, 0 },
            {Directions.Left, -1 },
            {Directions.Up, 0 },
            {Directions.Right, 1 },
        };

        private static readonly IDictionary<Directions, int> DIRECTION_Y_OFFSET = new Dictionary<Directions, int>()
        {
            {Directions.Down, 1 },
            {Directions.Left, 0 },
            {Directions.Up, -1 },
            {Directions.Right, 0 },
        };

        private static readonly IDictionary<Directions, Directions> SLOPE_RIGHT_DIRECTION_CHANGE = new Dictionary<Directions, Directions>()
        {
            {Directions.Down, Directions.Left },
            {Directions.Left, Directions.Down },
            {Directions.Up, Directions.Right },
            {Directions.Right, Directions.Up },
        };

        private static readonly IDictionary<Directions, Directions> SLOPE_LEFT_DIRECTION_CHANGE = new Dictionary<Directions, Directions>()
        {
            {Directions.Down, Directions.Right },
            {Directions.Right, Directions.Down },
            {Directions.Up, Directions.Left },
            {Directions.Left, Directions.Up },
        };

        private static readonly IDictionary<Directions, Directions>[] INTERSECTION_DIRECTION_CHANGES = new Dictionary<Directions, Directions>[3]
        {
            new Dictionary<Directions, Directions>() // left
            {
                {Directions.Down, Directions.Right },
                {Directions.Right, Directions.Up },
                {Directions.Up, Directions.Left },
                {Directions.Left, Directions.Down },
            },
            new Dictionary<Directions, Directions>() // straight
            {
                {Directions.Down, Directions.Down },
                {Directions.Right, Directions.Right },
                {Directions.Up, Directions.Up },
                {Directions.Left, Directions.Left },
            },
            new Dictionary<Directions, Directions>() // right
            {
                {Directions.Down, Directions.Left },
                {Directions.Right, Directions.Down },
                {Directions.Up, Directions.Right },
                {Directions.Left, Directions.Up },
            },
        };
    }

    public enum SectionTypes
    {
        Vertical,     // "|"
        Horizontal,   // "-"
        SlopeRight,   // "/"
        SlopeLeft,    // "\"
        Intersection, // "+"
    }

    public static class SectionTypesUtil
    {
        public static readonly IDictionary<SectionTypes, char> ICONS = new Dictionary<SectionTypes, char>()
        {
            { SectionTypes.Vertical, '|' },
            { SectionTypes.Horizontal, '-' },
            { SectionTypes.SlopeRight, '/' },
            { SectionTypes.SlopeLeft, '\\' },
            { SectionTypes.Intersection, '+' },
        };
    }
}
