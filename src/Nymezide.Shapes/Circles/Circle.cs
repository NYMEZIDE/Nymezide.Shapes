using Nymezide.Shapes.CalcFeatures;
using Nymezide.Shapes.Core;
using System;
using System.Text;

namespace Nymezide.Shapes.Circles
{
    public sealed class Circle : Shape, ISquareCalcFeature
    {
        public double Radius { get; }

        public double Square { get; }

        internal Circle(double raduis)
        {
            Radius = raduis;

            Square = Math.PI * Math.Pow(raduis, 2);
        }
        protected override void AddInfo(StringBuilder builder)
        {
            builder.AppendLine($"   Square = {Square}");
        }
    }
}
