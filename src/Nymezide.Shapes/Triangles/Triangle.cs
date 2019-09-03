using Nymezide.Shapes.CalcFeatures;
using Nymezide.Shapes.Core;
using System;
using System.Text;

namespace Nymezide.Shapes.Triangles
{
    public sealed class Triangle : Shape, ISquareCalcFeature, IPerimeterCalcFeature, IEquilateral, IRectangular, IIsosceles
    {
        private double _precision = 0.0000000000001;

        public double SideOne { get; }

        public double SideTwo { get; }

        public double SideThree { get; }

        internal Triangle(ThreeSidesOptions triangleOptions)
        {
            SideOne = triangleOptions.SideOne;
            SideTwo = triangleOptions.SideTwo;
            SideThree = triangleOptions.SideThree;

            Perimeter = SideOne + SideTwo + SideThree;

            var p = Perimeter / 2;
            Square = Math.Sqrt(p * (p - SideOne) * (p - SideTwo) * (p - SideThree));

            IsRectangular = CalcRectangularState(SideOne, SideTwo, SideThree);

            if (SideOne == SideTwo || SideTwo == SideThree || SideOne == SideThree)
            {
                IsIsosceles = true;

                if (SideOne == SideTwo && SideTwo == SideThree)
                {
                    IsRectangular = false;
                    IsEquilateral = true;
                }
            }
        }

        public bool IsEquilateral { get; }

        public bool IsIsosceles { get; }

        public double Perimeter { get; }

        public double Square { get; }

        public bool IsRectangular { get; }

        protected override void AddInfo(StringBuilder builder)
        {
            builder.AppendLine($"   Square = {Square}");
            builder.AppendLine($"   Perimeter = {Perimeter}");

            builder.AppendLine($"   Triangle is{(IsIsosceles ? "" : " not")} isosceles");
            builder.AppendLine($"   Triangle is{(IsEquilateral ? "" : " not")} equilateral");
            builder.AppendLine($"   Triangle is{(IsRectangular ? "" : " not")} rectangular");
        }

        private bool CalcRectangularState(double a, double b, double c)
        {
            double eq1 = Math.Pow(a, 2) - (Math.Pow(b, 2) + Math.Pow(c, 2));
            double eq2 = Math.Pow(b, 2) - (Math.Pow(a, 2) + Math.Pow(c, 2));
            double eq3 = Math.Pow(c, 2) - (Math.Pow(a, 2) + Math.Pow(b, 2));

            if ((eq1 >= 0 && eq1 <= _precision)
                || (eq2 >= 0 && eq2 <= _precision)
                || (eq3 >= 0 && eq3 <= _precision))
                return true;

            return false;
        }
    }
}
