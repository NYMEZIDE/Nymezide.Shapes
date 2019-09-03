using Nymezide.Shapes.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nymezide.Shapes.Circles
{
    internal class CircleShapeFactory : IShapeFactory<RadiusOptions, Circle>, IShapeFactory<TwoPointsOptions, Circle>
    {
        public Task<Circle> CreateAsync(RadiusOptions circleOption, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new Circle(circleOption.Radius));
        }

        public Task<Circle> CreateAsync(TwoPointsOptions circleOption, CancellationToken cancellationToken = default)
        {
            double radius = Math.Abs(Math.Sqrt(Math.Pow((circleOption.PerimeterPoint.Item1 - circleOption.CenterPoint.Item1), 2)
                                    + Math.Pow((circleOption.PerimeterPoint.Item2 - circleOption.CenterPoint.Item2), 2)));

            return Task.FromResult(new Circle(radius));
        }
    }
}
