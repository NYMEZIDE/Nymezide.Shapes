using Nymezide.Shapes.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nymezide.Shapes.Tests.Rectangles.Assets
{
    public class RectangleShapeFactory : IShapeFactory<WidthHeightOptions, Rectangle>
    {
        public async Task<Rectangle> CreateAsync(WidthHeightOptions rectangleOptions, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new Rectangle(rectangleOptions.Width, rectangleOptions.Heigth)); 
        }
    }
}
