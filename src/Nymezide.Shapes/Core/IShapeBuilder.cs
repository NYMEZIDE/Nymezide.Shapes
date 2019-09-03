using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nymezide.Shapes.Core
{
    public interface IShapeBuilder
    {
        Task<TShape> ProcessAsync<TShape>(IShapeOptions<TShape> shapeOptions, CancellationToken cancellationToken = default) where TShape : Shape;

        Task<TShape> ProcessAsync<TShape>(Func<IShapeOptions<TShape>> funcShapeOptions, CancellationToken cancellationToken = default) where TShape : Shape;
    }
}
