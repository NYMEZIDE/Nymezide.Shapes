using Nymezide.Shapes.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<TShape> ProcessAsync<TShape>(IShapeOptions<TShape> shapeOptions, CancellationToken cancellationToken = default) where TShape : Shape
        {
            Type handlerType = _registry.MethodFor(shapeOptions.GetType());
            dynamic queryHandler = _serviceProvider.GetService(handlerType);

            return await queryHandler?.CreateAsync((dynamic)shapeOptions) ?? throw new MissingMemberException($"Way from `{shapeOptions.GetType()}` to `{typeof(TShape).GetType()}` missing");
        }

        public async Task<TShape> ProcessAsync<TShape>(Func<IShapeOptions<TShape>> funcShapeOptions, CancellationToken cancellationToken = default) where TShape : Shape
            => await ProcessAsync(funcShapeOptions.Invoke());
    }
}
