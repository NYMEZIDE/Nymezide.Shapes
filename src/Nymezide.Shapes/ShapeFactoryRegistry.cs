using Nymezide.Shapes.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nymezide.Shapes
{
    public sealed class ShapeFactoryRegistry
    {
        private readonly Dictionary<Type, Type> _factories = new Dictionary<Type, Type>();

        public IEnumerable<Type> RegisteredFactories => _factories.Values;

        public ShapeFactoryRegistry Register<TShapeFactory>() where TShapeFactory : IShapeFactory
        {
            var supportedQueryTypes = FindGenericInterfaces(typeof(TShapeFactory), typeof(IShapeFactory<,>));

            if (_factories.Keys.Any(registeredType => supportedQueryTypes.Contains(registeredType)))
                throw new ArgumentException("The factory has already registered.");

            foreach (var queryType in supportedQueryTypes)
                _factories.Add(queryType, typeof(TShapeFactory));

            return this;
        }

        public Type MethodFor(Type keyType)
        {
            if (!_factories.TryGetValue(keyType, out Type method))
                throw new KeyNotFoundException("Method Not found");

            return method;
        }

        private static List<Type> FindGenericInterfaces(Type handler, Type genericHandler)
            => handler
                .GetTypeInfo().ImplementedInterfaces
                .Where(iface =>
                {
                    var itype = iface.GetTypeInfo();
                    return itype.IsInterface && itype.IsGenericType && itype.GetGenericTypeDefinition() == genericHandler;
                })
                .Select(iface => iface.GenericTypeArguments[0])
                .ToList();
    }
}
