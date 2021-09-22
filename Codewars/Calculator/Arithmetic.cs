namespace Codewars.Three.Calculator
{
    public abstract class Arithmetic
    {
        protected string Expression;

        internal Arithmetic(string expression)
        {
            Expression = expression;
        }
        
        internal abstract string GetSimplifiedExpression(); 
    }
}