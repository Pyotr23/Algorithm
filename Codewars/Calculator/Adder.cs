namespace Codewars.Three.Calculator
{
    public class Adder : Arithmetic
    {
        public Adder(string expression) : base(expression)
        { }

        internal override string GetSimplifiedExpression()
        {
            var creator = new OperationCreator();
            foreach (var letter in Expression)
                creator.Push(letter);
            return creator.GetResult();
        }
    }
}