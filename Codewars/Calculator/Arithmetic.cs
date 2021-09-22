namespace Codewars.Three.Calculator
{
    public abstract class Arithmetic
    {
        protected string _expression;

        internal Arithmetic(string expression)
        {
            _expression = expression;
        }
        
        internal abstract string GetSimplifiedExpression(); 
    }
}