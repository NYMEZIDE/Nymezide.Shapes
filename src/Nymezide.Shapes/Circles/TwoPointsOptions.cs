using Nymezide.Shapes.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nymezide.Shapes.Circles
{
    public sealed class TwoPointsOptions : IShapeOptions<Circle>
    {
        public Tuple<double,double> CenterPoint { get; }

        public Tuple<double, double> PerimeterPoint { get; }

        public TwoPointsOptions(Tuple<double, double> centerPoint, Tuple<double, double> perimeterPoint)
        {
            if (centerPoint.Item1 == perimeterPoint.Item1 && centerPoint.Item2 == perimeterPoint.Item2)
                throw new ArgumentException($"Perimeter point equals Center point", nameof(perimeterPoint));

            CenterPoint = centerPoint;
            PerimeterPoint = perimeterPoint;
        }
    }
}
