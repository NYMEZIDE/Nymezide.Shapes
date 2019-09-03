using Nymezide.Shapes.Core;

namespace Nymezide.Shapes.Circles
{
    internal class CircleShapeFactory : IShapeFactory<RadiusOptions, Circle>
    {
        public Circle Create(RadiusOptions circleOption)
        {
            return new Circle(circleOption.Radius);
        }
    }
}
