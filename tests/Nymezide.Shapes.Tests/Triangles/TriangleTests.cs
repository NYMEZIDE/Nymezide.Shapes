using Microsoft.Extensions.DependencyInjection;
using Nymezide.Shapes.Core;
using Nymezide.Shapes.Triangles;
using System;
using Xunit;

namespace Nymezide.Shapes.Tests.Triangles
{
    public class TriangleTests
    {
        ServiceCollection services;
        ServiceProvider serviceProvider;

        public TriangleTests()
        {
            services = new ServiceCollection();
            services.AddShapeBuilder();

            serviceProvider = services.BuildServiceProvider();
        }

        [Theory(DisplayName = "Success_Create_Triangle")]
        [InlineData(5, 5, 5)]
        [InlineData(10, 10, 10)]
        [InlineData(20, 20, 20)]
        public void SuccessCreateTriangle(double a, double b, double c)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Triangle triangle = builder.Process(new ThreeSidesOptions(a, b, c));

            Assert.Equal(a, triangle.SideOne);
            Assert.Equal(b, triangle.SideTwo);
            Assert.Equal(c, triangle.SideThree);
        }

        [Theory(DisplayName = "Fail_Create_Triangle")]
        [InlineData(0, 2, 3)]
        [InlineData(1, -5, 3)]
        [InlineData(1, 2, -10)]
        [InlineData(1, -20, -20)]
        [InlineData(-15, 2, -20)]
        [InlineData(-15, -40, 3)]
        [InlineData(-double.MaxValue, -double.MaxValue, -double.MaxValue)]
        public void FailValidateCreateTriangle(double a, double b, double c)
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new ThreeSidesOptions(a, b, c));
        }

        [Theory(DisplayName = "Fail_Create_Triangle")]
        [InlineData(10, 2, 3)]
        [InlineData(1, 20, 3)]
        [InlineData(1, 20, 30)]
        [InlineData(5, 2, 3)]
        [InlineData(1, 4, 3)]
        [InlineData(10, 20, 30)]
        public void FailFactoryCreateTriangle(double a, double b, double c)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Exception ex = Assert.Throws<ArgumentException>(() => builder.Process(new ThreeSidesOptions(a, b, c)));
        }

        [Theory(DisplayName = "Success_Square_Triangle")]
        [InlineData(5, 5, 5)]
        [InlineData(10, 10, 10)]
        [InlineData(20, 20, 20)]
        public void SuccessSquareTriangle(double a, double b, double c)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Triangle triangle = builder.Process(new ThreeSidesOptions(a, b, c));

            var p = (a + b + c) / 2;
            Assert.Equal(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), triangle.Square);
        }

        [Theory(DisplayName = "Success_Perimeter_Triangle")]
        [InlineData(5, 5, 5)]
        [InlineData(10, 10, 10)]
        [InlineData(20, 20, 20)]
        public void SuccessPerimeterTriangle(double a, double b, double c)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Triangle triangle = builder.Process(new ThreeSidesOptions(a, b, c));

            Assert.Equal(a + b + c, triangle.Perimeter);
        }

        [Theory(DisplayName = "Is_Equilateral_Triangle")]
        [InlineData(5, 5, 5)]
        [InlineData(10, 10, 10)]
        [InlineData(20, 20, 20)]
        public void IsEquilateralTriangle(double a, double b, double c)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Triangle triangle = builder.Process(new ThreeSidesOptions(a, b, c));

            Assert.False(triangle.IsRectangular);
            Assert.True(triangle.IsIsosceles);
            Assert.True(triangle.IsEquilateral);
        }

        [Theory(DisplayName = "Is_Isosceles_Triangle")]
        [InlineData(4, 5, 5)]
        [InlineData(10, 5, 10)]
        [InlineData(20, 20, 10)]
        public void IsIsoscelesTriangle(double a, double b, double c)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Triangle triangle = builder.Process(new ThreeSidesOptions(a, b, c));

            Assert.False(triangle.IsEquilateral);
            Assert.False(triangle.IsRectangular);
            Assert.True(triangle.IsIsosceles);
        }

        [Theory(DisplayName = "Is_Rectangular_Triangle")]
        [InlineData(6, 8, 10)]
        [InlineData(9, 12, 15)]
        [InlineData(10, 24, 26)]
        [InlineData(15, 20, 25)]
        public void IsRectangularTriangle(double a, double b, double c)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Triangle triangle = builder.Process(new ThreeSidesOptions(a, b, c));

            Assert.False(triangle.IsEquilateral);
            Assert.False(triangle.IsIsosceles);
            Assert.True(triangle.IsRectangular);
        }

        [Theory(DisplayName = "Is_Rectangular_and_IsIsosceles_Triangle")]
        [InlineData(4)]
        [InlineData(9)]
        [InlineData(15)]
        public void IsRectangularAndIsIsoscelesTriangle(double a)
        {
            double b = a;
            double c = Math.Sqrt(2 * a * b);
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Triangle triangle = builder.Process(new ThreeSidesOptions(a, b, c));

            Assert.False(triangle.IsEquilateral);
            Assert.True(triangle.IsIsosceles);
            Assert.True(triangle.IsRectangular);
        }
    }
}
