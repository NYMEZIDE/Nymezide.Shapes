using Nymezide.Shapes.CalcFeatures;
using Nymezide.Shapes.Core;
using System;
using System.Text;

namespace Nymezide.Shapes.Circles
{
    public sealed class Circle : Shape, ISquareCalcFeature, IPerimeterCalcFeature
    {
        public double Radius { get; }

        public double Square { get; }

        public double Perimeter { get; }

        internal Circle(double radius)
        {
            Radius = radius;

            Square = Math.PI * Math.Pow(radius, 2);
            Perimeter = 2 * Math.PI * Radius;
        }
        protected override void AddInfo(StringBuilder builder)
        {
            builder.AppendLine($"   Square = {Square}");
            builder.AppendLine($"   Perimeter = {Perimeter}");
        }
    }
}
