using Nymezide.Shapes.Core;
using System;

namespace Nymezide.Shapes.Circles
{
    public sealed class RadiusOptions : IShapeOptions<Circle>
    {
        public double Radius { get; }

        /// <exception cref="ArgumentException">Radius less or equal zero</exception>
        public RadiusOptions(double radius)
        {
            Radius = (radius <= 0) ? throw new ArgumentException("don't be a 0 or less", nameof(radius)) : radius;
        }
    }
}
