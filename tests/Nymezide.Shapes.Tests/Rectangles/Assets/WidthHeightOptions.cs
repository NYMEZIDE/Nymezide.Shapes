using Nymezide.Shapes.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nymezide.Shapes.Tests.Rectangles.Assets
{
    public class WidthHeightOptions : IShapeOptions<Rectangle>
    {
        public WidthHeightOptions(double width, double heigth)
        {
            Width = (width <= 0) ? throw new ArgumentException("don't be a 0 or less", nameof(width)) : width;
            Heigth = (heigth <= 0) ? throw new ArgumentException("don't be a 0 or less", nameof(heigth)) : heigth;
        }

        public double Width { get; }
        public double Heigth { get; }
    }
}
