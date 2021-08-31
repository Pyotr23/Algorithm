using System.Linq;
using NUnit.Framework;

namespace Easy.SummaryRanges
{
    public class Tests
    {
        [Test]
        public void First()
        {
            var arr = new[] {0, 1, 2, 4, 5, 7};

            var list = Program.SummaryRanges(arr).ToList();
            
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("0->2", list.ElementAt(0));
            Assert.AreEqual("4->5", list.ElementAt(1));
            Assert.AreEqual("7", list.ElementAt(2));
        }
    }
}