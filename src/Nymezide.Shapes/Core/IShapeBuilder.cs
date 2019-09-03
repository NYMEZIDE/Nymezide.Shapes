using System;

namespace Nymezide.Shapes.Core
{
    public interface IShapeBuilder
    {
        TShape Process<TShape>(IShapeOptions<TShape> shapeOptions) where TShape : Shape;

        TShape Process<TShape>(Func<IShapeOptions<TShape>> funcShapeOptions) where TShape : Shape;
    }
}
