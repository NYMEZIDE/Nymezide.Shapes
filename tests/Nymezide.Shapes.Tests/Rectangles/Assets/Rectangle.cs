using Nymezide.Shapes.CalcFeatures;
using Nymezide.Shapes.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nymezide.Shapes.Tests.Rectangles.Assets
{
    public class Rectangle : Shape, ISquareCalcFeature, IPerimeterCalcFeature, ISquare
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;

            Perimeter = (Width * 2) + (Height * 2);
            Square = Width * Height;

            if (Width == Height)
                IsSquare = true;
        }

        public bool IsSquare { get; }

        public double Perimeter { get; }

        public double Square { get; }

        public double Width { get; }
        public double Height { get; }
    }
}
