using Nymezide.Shapes.Core;
using System;

namespace Nymezide.Shapes.Triangles
{
    public class TriangleShapeFactory : IShapeFactory<ThreeSidesOptions, Triangle>
    {
        /// <exception cref="ArgumentException">Triangle not possible</exception>
        public Triangle Create(ThreeSidesOptions triangleOptions)
        {
            Check(triangleOptions.SideOne, triangleOptions.SideTwo, triangleOptions.SideThree);

            return new Triangle(triangleOptions);
        }

        private void Check(double a, double b, double c)
        {
            if ((a >= b + c) || (b >= a + c) || (c >= a + b))
                throw new ArgumentException("Triangle not possible");
        }
    }
}
