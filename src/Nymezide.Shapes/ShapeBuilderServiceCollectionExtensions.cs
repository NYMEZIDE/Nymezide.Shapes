using Microsoft.Extensions.DependencyInjection;
using Nymezide.Shapes.Circles;
using Nymezide.Shapes.Core;
using Nymezide.Shapes.Triangles;
using System;

namespace Nymezide.Shapes
{
    public static class ShapeBuilderServiceCollectionExtensions
    {
        public static void AddShapeBuilder(this IServiceCollection services, Action<ShapeFactoryRegistry> action = null)
        {
            var factoryRegistry = new ShapeFactoryRegistry();
            factoryRegistry.Register<CircleShapeFactory>();
            factoryRegistry.Register<TriangleShapeFactory>();

            action?.Invoke(factoryRegistry);

            foreach (var registeredHandler in factoryRegistry.RegisteredFactories)
                services.AddScoped(registeredHandler);

            services.AddSingleton(factoryRegistry);
            services.AddScoped<IShapeBuilder, ShapeBuilder>();
        }
    }
}
