namespace Codewars.Three.Calculator.Arithmetic
{
    public class Adder : Simplifier
    {
        public Adder(string expression) : base(expression)
        { }

        internal override string GetSimplifiedExpression()
        {
            var creator = new AddingMachine();
            foreach (var letter in Expression)
                creator.Push(letter);
            return creator.GetResult();
        }
    }
}