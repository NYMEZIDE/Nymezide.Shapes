using Nymezide.Shapes.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nymezide.Shapes.Triangles
{
    public class TriangleShapeFactory : IShapeFactory<ThreeSidesOptions, Triangle>
    {
        /// <exception cref="ArgumentException">Triangle not possible</exception>
        public Task<Triangle> CreateAsync(ThreeSidesOptions triangleOptions, CancellationToken cancellationToken = default)
        {
            Check(triangleOptions.SideOne, triangleOptions.SideTwo, triangleOptions.SideThree);

            return Task.FromResult(new Triangle(triangleOptions));
        }

        private void Check(double a, double b, double c)
        {
            if ((a >= b + c) || (b >= a + c) || (c >= a + b))
                throw new ArgumentException("Triangle not possible");
        }
    }
}
