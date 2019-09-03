using Nymezide.Shapes.CalcFeatures;
using Nymezide.Shapes.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nymezide.Shapes
{
    public static class ShapeExtensions
    {
        public static double GetSquare(this Shape shape)
        {
            if (shape is ISquareCalcFeature)
                return (shape as ISquareCalcFeature).Square;

            throw new NotSupportedException();
        }
    }
}
