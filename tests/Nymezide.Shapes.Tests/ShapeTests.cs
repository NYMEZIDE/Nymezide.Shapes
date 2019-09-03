using Microsoft.Extensions.DependencyInjection;
using Nymezide.Shapes.Circles;
using Nymezide.Shapes.Core;
using Nymezide.Shapes.Triangles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Nymezide.Shapes.Tests
{
    public class ShapeTests
    {
        ServiceCollection services;
        ServiceProvider serviceProvider;

        public ShapeTests()
        {
            services = new ServiceCollection();
            services.AddShapeBuilder();

            serviceProvider = services.BuildServiceProvider();
        }

        [Theory(DisplayName = "Success_Square_Shape_by_Triangle")]
        [InlineData(5, 5, 5)]
        [InlineData(10, 10, 10)]
        [InlineData(20, 20, 20)]
        public async Task SuccessSquareShapeByTriangle(double a, double b, double c)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Shape shape = await builder.ProcessAsync(new ThreeSidesOptions(a, b, c));
            Exception ex = Record.Exception(() => shape.GetSquare());

            Assert.Null(ex);
            Assert.NotEqual(0, shape.GetSquare());
        }

        [Theory(DisplayName = "Success_Square_Shape_by_Circle")]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public async Task SuccessSquareShapeByCircle(double radius)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Shape shape = await builder.ProcessAsync(new RadiusOptions(radius));
            Exception ex = Record.Exception(() => shape.GetSquare());

            Assert.Null(ex);
            Assert.NotEqual(0, shape.GetSquare());
        }

        [Theory(DisplayName = "Success_Square_Shape_via_Func")]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public async Task SuccessSquareShapeViaFunc(double radius)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Shape shape = await builder.ProcessAsync(() => new RadiusOptions(radius));

            Assert.NotNull(shape);
        }
    }
}
