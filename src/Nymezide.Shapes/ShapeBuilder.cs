using Nymezide.Shapes.Core;
using System;

namespace Nymezide.Shapes
{
    public sealed class ShapeBuilder : IShapeBuilder
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ShapeFactoryRegistry _registry;

        public ShapeBuilder(IServiceProvider serviceProvider, ShapeFactoryRegistry registry)
        {
            _serviceProvider = serviceProvider;
            _registry = registry;
        }

        public TShape Process<TShape>(IShapeOptions<TShape> shapeOptions) where TShape : Shape
        {
            Type handlerType = _registry.MethodFor(shapeOptions.GetType());
            dynamic queryHandler = _serviceProvider.GetService(handlerType);

            return queryHandler?.Create((dynamic)shapeOptions) ?? throw new MissingMemberException($"Way from `{shapeOptions.GetType()}` to `{typeof(TShape).GetType()}` missing");
        }

        public TShape Process<TShape>(Func<IShapeOptions<TShape>> funcShapeOptions) where TShape : Shape
            => Process(funcShapeOptions.Invoke());
    }
}
