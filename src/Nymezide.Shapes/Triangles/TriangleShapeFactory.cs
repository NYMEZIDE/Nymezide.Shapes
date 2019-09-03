using Nymezide.Shapes.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nymezide.Shapes.Triangles
{
    public class TriangleShapeFactory : IShapeFactory<ThreeSidesOptions, Triangle>
    {
        /// <exception cref="ArgumentException">Triangle not possible</exception>
        public async Task<Triangle> CreateAsync(ThreeSidesOptions triangleOptions, CancellationToken cancellationToken = default)
        {
            await Check(triangleOptions.SideOne, triangleOptions.SideTwo, triangleOptions.SideThree);

            return new Triangle(triangleOptions);
        }

        private Task Check(double a, double b, double c)
        {
            if ((a >= b + c) || (b >= a + c) || (c >= a + b))
                throw new ArgumentException("Triangle not possible");

            return Task.CompletedTask;
        }
    }
}
