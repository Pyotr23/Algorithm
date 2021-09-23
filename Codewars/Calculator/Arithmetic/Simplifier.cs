namespace Codewars.Three.Calculator.Arithmetic
{
    public abstract class Simplifier
    {
        protected string Expression;

        internal Simplifier(string expression)
        {
            Expression = expression;
        }
        
        internal abstract string GetSimplifiedExpression(); 
    }
}