using Microsoft.Extensions.DependencyInjection;
using Nymezide.Shapes.Core;
using Nymezide.Shapes.Tests.Rectangles.Assets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Nymezide.Shapes.Tests.Rectangles
{
    public class RectangleTests
    {
        ServiceCollection services;
        ServiceProvider serviceProvider;

        public RectangleTests()
        {
            services = new ServiceCollection();
            services.AddShapeBuilder(c => c.Register<RectangleShapeFactory>());

            serviceProvider = services.BuildServiceProvider();
        }

        [Theory(DisplayName = "Success_Create_Rectangle")]
        [InlineData(5, 10)]
        [InlineData(10, 20)]
        [InlineData(30, 7)]
        public async Task SuccessCreateRectangle(double width, double height)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Rectangle triangle = await builder.ProcessAsync(new WidthHeightOptions(width, height));

            Assert.Equal(width, triangle.Width);
            Assert.Equal(height, triangle.Height);
        }

        [Theory(DisplayName = "Fail_Create_Rectangle")]
        [InlineData(-5, 10)]
        [InlineData(10, -20)]
        [InlineData(-30, -7)]
        public void FailCreateRectangle(double width, double height)
        {
            Assert.Throws<ArgumentException>(() => new WidthHeightOptions(width, height));
        }

        [Theory(DisplayName = "Success_Square_Rectangle")]
        [InlineData(5, 10)]
        [InlineData(10, 20)]
        [InlineData(30, 7)]
        public async Task SuccessSquareRectangle(double width, double height)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Rectangle rectangle = await builder.ProcessAsync(new WidthHeightOptions(width, height));

            Assert.Equal(width * height, rectangle.Square);
        }

        [Theory(DisplayName = "Success_Perimeter_Rectangle")]
        [InlineData(5, 10)]
        [InlineData(10, 20)]
        [InlineData(30, 7)]
        public async Task SuccessPerimeterRectangle(double width, double height)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Rectangle rectangle = await builder.ProcessAsync(new WidthHeightOptions(width, height));

            Assert.Equal((width * 2) + (height * 2), rectangle.Perimeter);
        }

        [Theory(DisplayName = "Success_Square_Shape_by_Rectangle")]
        [InlineData(5, 10)]
        [InlineData(10, 20)]
        [InlineData(30, 7)]
        public async Task SuccessSquareShapeByRectangle(double width, double height)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Shape shape = await builder.ProcessAsync(new WidthHeightOptions(width, height));
            Exception ex = Record.Exception(() => shape.GetSquare());

            Assert.Null(ex);
            Assert.Equal(width * height, shape.GetSquare());
        }

        [Theory(DisplayName = "Is_Not_Square_Rectangle")]
        [InlineData(5, 10)]
        [InlineData(10, 20)]
        [InlineData(30, 7)]
        public async Task IsNotSquareRectangle(double width, double height)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Rectangle rectangle = await builder.ProcessAsync(new WidthHeightOptions(width, height));

            Assert.False(rectangle.IsSquare);
        }

        [Theory(DisplayName = "Is_Square_Rectangle")]
        [InlineData(5, 5)]
        [InlineData(10, 10)]
        [InlineData(30, 30)]
        public async Task IsSquareRectangle(double width, double height)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Rectangle rectangle = await builder.ProcessAsync(new WidthHeightOptions(width, height));

            Assert.True(rectangle.IsSquare);
        }
    }
}
