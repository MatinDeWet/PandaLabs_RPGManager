using System.Linq.Expressions;

namespace Application.Common.Tools
{
    public class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameterToReplace;
        private readonly Expression _replacement;

        public ParameterReplacer(ParameterExpression parameterToReplace, Expression replacement)
        {
            _parameterToReplace = parameterToReplace;
            _replacement = replacement;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == _parameterToReplace)
                return _replacement;

            return base.VisitParameter(node);
        }
    }
}
