﻿using Microsoft.Extensions.DependencyInjection;
using Nymezide.Shapes.Circles;
using Nymezide.Shapes.Core;
using System;
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
        public void SuccessCreateCircle(double radius)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Circle cirle = builder.Process(new RadiusOptions(radius));

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
            Exception ex = Assert.Throws<ArgumentException>(() => new RadiusOptions(radius));
        }

        [Theory(DisplayName = "Success_Square_Circle")]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void SuccessSquareCircle(double radius)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Circle cirle = builder.Process(new RadiusOptions(radius));

            Assert.Equal(Math.PI * Math.Pow(radius, 2), cirle.Square);
        }

        [Theory(DisplayName = "Success_Perimetr_Circle")]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void SuccessPerimetrCircle(double radius)
        {
            var builder = serviceProvider.GetService<IShapeBuilder>();

            Circle cirle = builder.Process(new RadiusOptions(radius));

            Assert.Equal(2 * Math.PI * radius, cirle.Perimeter);
        }
    }
}
