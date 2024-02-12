using System;
using NUnit.Framework;

namespace LineAdjustment.Tests
{
    public class LineAdjustmentAlgorithmTests
    {
        [Test]
        [TestCase(null, 5, "")]
        [TestCase("", 5, "")]
        [TestCase("test", 5, "test ")]
        [TestCase("Lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", 12,
            "Lorem  ipsum\ndolor    sit\namet        \nconsectetur \nadipiscing  \nelit  sed do\neiusmod     \ntempor      \nincididunt  \nut labore et\ndolore magna\naliqua      ")]
        [TestCase("Lorem     ipsum    dolor", 17, "Lorem ipsum dolor")]
        public void Simple(string input, int lineWidth, string expected)
        {
            var algorithm = new LineAdjustmentAlgorithmStringBuilder(new AddSpacesAlgorithm());
            var output2 = algorithm.Transform(input, lineWidth);
            Assert.AreEqual(expected, output2);
        }
        
        [TestCase("Longsentence", 5)]
        public void SimpleLongWord(string input, int lineWidth)
        {
            var algorithm = new LineAdjustmentAlgorithmStringBuilder(new AddSpacesAlgorithm());
            Assert.Throws(Is.TypeOf<Exception>()
                    .And.Message.EqualTo("String Longsentence is too long"),
                () => algorithm.Transform(input, lineWidth));
        }
    }
}