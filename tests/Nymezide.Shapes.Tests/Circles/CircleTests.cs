using Microsoft.Extensions.DependencyInjection;
using Nymezide.Shapes.Circles;
using Nymezide.Shapes.Core;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Nymezide.Shapes.Tests.Circles
{
    public class CircleTests
    {
        ServiceCollection services;
        ServiceProvider serviceProvider;

        public CircleTests()
        {
            services = new ServiceCollection();
            services.AddShapeBuilder();

            serviceProvider = services.BuildServiceProvider();
        }

        [Theory(DisplayName = "Success_Create_Circle")]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(double.MaxValue)]
        public async Task SuccessCreateCircle(double radius)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Circle cirle = await builder.ProcessAsync(new RadiusOptions(radius));

            Assert.Equal(radius, cirle.Radius);
        }

        [Theory(DisplayName = "Fail_Create_Circle")]
        [InlineData(0)]
        [InlineData(-5)]
        [InlineData(-10)]
        [InlineData(-20)]
        [InlineData(-double.MaxValue)]
        public void FailCreateCircle(double radius)
        {
            Assert.Throws<ArgumentException>(() => new RadiusOptions(radius));
        }

        [Theory(DisplayName = "Success_Square_Circle")]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public async Task SuccessSquareCircle(double radius)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Circle cirle = await builder.ProcessAsync(new RadiusOptions(radius));

            Assert.Equal(Math.PI * Math.Pow(radius, 2), cirle.Square);
        }

        [Theory(DisplayName = "Success_Perimetr_Circle")]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public async Task SuccessPerimetrCircle(double radius)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Circle cirle = await builder.ProcessAsync(new RadiusOptions(radius));

            Assert.Equal(2 * Math.PI * radius, cirle.Perimeter);
        }

        [Fact(DisplayName = "Success_Create_Circle_via_TwoPoints")]
        public async Task SuccessSquareCircleViaTwoPoints()
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Circle cirle = await builder.ProcessAsync(new TwoPointsOptions(new Tuple<double, double>(1,2), new Tuple<double, double>(1,7)));

            Assert.Equal(5, cirle.Radius);
        }

        [Fact(DisplayName = "Success_Equals_Squares_Circles")]
        public async Task SuccessEqualsSquaresCircles()
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Circle cirle1 = await builder.ProcessAsync(new RadiusOptions(5));
            Circle cirle2 = await builder.ProcessAsync(new TwoPointsOptions(new Tuple<double, double>(1, 2), new Tuple<double, double>(1, 7)));

            Assert.Equal(cirle1.Square, cirle2.Square);
        }

        [Fact(DisplayName = "Success_Equals_Perimeters_Circles")]
        public async Task SuccessEqualsPerimetersCircles()
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Circle cirle1 = await builder.ProcessAsync(new RadiusOptions(5));
            Circle cirle2 = await builder.ProcessAsync(new TwoPointsOptions(new Tuple<double, double>(1, 2), new Tuple<double, double>(1, 7)));

            Assert.Equal(cirle1.Perimeter, cirle2.Perimeter);
        }
    }
}
