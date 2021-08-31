using System;
using System.Linq;
using NUnit.Framework;

namespace Easy.SummaryRanges
{
    public class Tests
    {
        [Test]
        public void FirstLongArray()
        {
            var arr = new[] {0, 1, 2, 4, 5, 7};

            var list = Program.SummaryRanges(arr).ToList();
            
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("0->2", list.ElementAt(0));
            Assert.AreEqual("4->5", list.ElementAt(1));
            Assert.AreEqual("7", list.ElementAt(2));
        }
        
        [Test]
        public void SecondLongArray()
        {
            var arr = new[] {0, 2, 3, 4, 6, 8, 9};

            var list = Program.SummaryRanges(arr).ToList();
            
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual("0", list.ElementAt(0));
            Assert.AreEqual("2->4", list.ElementAt(1));
            Assert.AreEqual("6", list.ElementAt(2));
            Assert.AreEqual("8->9", list.ElementAt(3));
        }
        
        [Test]
        public void EmptyArray()
        {
            var arr = Array.Empty<int>();

            var list = Program.SummaryRanges(arr).ToList();
            
            Assert.Zero(list.Count);
        }
        
        [Test]
        public void OneValue()
        {
            var arr = new[]{-1};

            var list = Program.SummaryRanges(arr).ToList();
            
            Assert.AreEqual("-1", list.ElementAt(0));
        }
        
        [Test]
        public void OneValueIsZero()
        {
            var arr = new[] {0};

            var list = Program.SummaryRanges(arr).ToList();
            
            Assert.AreEqual("0", list.ElementAt(0));
        }
    }
}