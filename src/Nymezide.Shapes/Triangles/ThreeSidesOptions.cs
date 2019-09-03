using Nymezide.Shapes.Core;
using System;
using System.Text;

namespace Nymezide.Shapes.Triangles
{
    public sealed class ThreeSidesOptions : IShapeOptions<Triangle>
    {
        public double SideOne { get; }

        public double SideTwo { get; }

        public double SideThree { get; }

        /// <exception cref="ArgumentException">One or more sides less or equal zero</exception>
        public ThreeSidesOptions(double sideOne, double sideTwo, double sideThree)
        {
            StringBuilder validate = new StringBuilder();

            if (sideOne <= 0)
                validate.AppendLine($"{nameof(sideOne)} must be greater 0");
            if (sideTwo <= 0)
                validate.AppendLine($"{nameof(sideTwo)} must be greater 0");
            if (sideThree <= 0)
                validate.AppendLine($"{nameof(sideThree)} must be greater 0");

            if (validate.Length > 0)
                throw new ArgumentException(validate.ToString());

            SideOne = sideOne;
            SideTwo = sideTwo;
            SideThree = sideThree;
        }
    }
}
