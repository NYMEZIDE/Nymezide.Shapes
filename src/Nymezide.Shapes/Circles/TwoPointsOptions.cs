using Nymezide.Shapes.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nymezide.Shapes.Circles
{
    public sealed class TwoPointsOptions : IShapeOptions<Circle>
    {
        public (double x, double y) CenterPoint { get; }

        public (double x, double y) PerimeterPoint { get; }

        public TwoPointsOptions((double x, double y) centerPoint, (double x, double y) perimeterPoint)
        {
            if (centerPoint.x == perimeterPoint.x && centerPoint.y == perimeterPoint.y)
                throw new ArgumentException($"Perimeter point equals Center point", nameof(perimeterPoint));

            CenterPoint = centerPoint;
            PerimeterPoint = perimeterPoint;
        }
    }
}
