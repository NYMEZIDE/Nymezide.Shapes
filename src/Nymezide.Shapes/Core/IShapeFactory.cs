namespace Nymezide.Shapes.Core
{
    public interface IShapeFactory
    { }

    public interface IShapeFactory<TOption, TShape> : IShapeFactory where TOption : IShapeOptions<TShape> where TShape : Shape
    {
        TShape Create(TOption query);
    }
}
