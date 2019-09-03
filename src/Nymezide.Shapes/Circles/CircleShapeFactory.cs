using Nymezide.Shapes.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Nymezide.Shapes.Circles
{
    internal class CircleShapeFactory : IShapeFactory<RadiusOptions, Circle>
    {
        public Task<Circle> CreateAsync(RadiusOptions circleOption, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new Circle(circleOption.Radius));
        }
    }
}
