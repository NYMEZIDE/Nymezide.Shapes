using System.Text;

namespace Nymezide.Shapes.Core
{
    public abstract class Shape
    {
        protected virtual void AddInfo(StringBuilder builder)
        { }

        public string GetSummary()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Shape `{this.GetType().Name}`");

            AddInfo(builder);

            return builder.ToString();
        }
    }
}
