using Nymezide.Shapes.CalcFeatures;
using Nymezide.Shapes.Core;
using System;
using System.Text;

namespace Nymezide.Shapes.Triangles
{
    public sealed class Triangle : Shape, ISquareCalcFeature, IPerimeterCalcFeature, IEquilateral
    {
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

            if (SideOne == SideTwo || SideTwo == SideThree || SideOne == SideThree)
            {
                IsIsosceles = true;

                if (SideOne == SideTwo && SideTwo == SideThree)
                {
                    IsIsosceles = false;
                    IsEquilateral = true;
                }
            }
        }

        public bool IsEquilateral { get; }

        public bool IsIsosceles { get; }

        public double Perimeter { get; }

        public double Square { get; }

        protected override void AddInfo(StringBuilder builder)
        {
            builder.AppendLine($"   Square = {Square}");
            builder.AppendLine($"   Perimeter = {Perimeter}");

            builder.AppendLine($"   Triangle is{(IsIsosceles ? "" : " not")} isosceles");
            builder.AppendLine($"   Triangle is{(IsEquilateral ? "" : " not")} equilateral");
        }
    }
}
