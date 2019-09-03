using System.Threading;
using System.Threading.Tasks;

namespace Nymezide.Shapes.Core
{
    public interface IShapeFactory
    { }

    public interface IShapeFactory<TOption, TShape> : IShapeFactory where TOption : IShapeOptions<TShape> where TShape : Shape
    {
        Task<TShape> CreateAsync(TOption query, CancellationToken cancellationToken = default);
    }
}
