﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2018.Day13.Tracks
{
    public class Track
    {
        private readonly int _width;

        private readonly int _height;

        private readonly Section[,] _sections;

        private readonly IDictionary<Location, Cart> _carts = new Dictionary<Location, Cart>();

        public Track(int width, int height)
        {
            _width = width;
            _height = height;

            _sections = new Section[width, height];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var row = new char[_width];

            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    var section = _sections[x, y];

                    row[x] = section == null ? ' ' : SectionTypesUtil.ICONS[section.SectionType];
                }

                foreach (var cart in _carts.Values.Where(c => c.Location.Y == y))
                {
                    row[cart.Location.X] = DirectionsUtil.ICONS[cart.Direction];
                }

                sb.AppendLine(new string(row));
            }

            return sb.ToString();
        }

        public void AddSection(int x, int y, SectionTypes sectionType)
        {
            _sections[x, y] = new Section(sectionType);
        }

        public void AddCart(int x, int y, Directions direction)
        {
            var location = new Location(x, y);

            var cart = new Cart(location, direction);

            _carts.Add(location, cart);
        }

        public void Tick()
        {
            var carts = _carts
                .Values
                .OrderBy(c => c.Location.Y)
                .ThenBy(c => c.Location.X)
                .ToArray();

            foreach (var cart in carts)
            {
                _carts.Remove(cart.Location);

                _sections[cart.Location.X, cart.Location.Y].ExitSection(cart);

                if (_carts.ContainsKey(cart.Location))
                {
                    throw new CartCollisionException(cart.Location);
                }

                _sections[cart.Location.X, cart.Location.Y].EnterSection(cart);

                _carts.Add(cart.Location, cart);
            }
        }
    }
}
