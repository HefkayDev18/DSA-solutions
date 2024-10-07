//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace LongestSubstring.Test
//{
//    [TestFixture]
//    public class StringAlgorithmTest : StringAlgorithm
//    {
//        [Test]
//        public void TestNoCommonSubstring()
//        {
//            Assert.AreEqual("", CommonSubstring("abc", "def"));
//        }

//        [Test]
//        public void TestPartialMatch()
//        {
//            Assert.Equals("abc", CommonSubstring("abcdef", "defabc"));
//        }

//        [Test]
//        public void TestIdenticalStrings()
//        {
//            Assert.Equals("hello", CommonSubstring("hello", "hello"));
//        }

//        [Test]
//        public void TestEmptyStrings()
//        {
//            Assert.Equals(string.Empty, CommonSubstring("", "test"));
//            Assert.Equals(string.Empty, CommonSubstring("test", ""));
//            Assert.Equals(string.Empty, CommonSubstring("", ""));
//        }
//    }
//}



using NUnit.Framework;
using System;

namespace LongestSubstring.Test
{
    [TestFixture]
    public class StringAlgorithmTest
    {
        [Test]
        public void TestNoCommonSubstring()
        {
            Assert.That(StringAlgorithm.CommonSubstring("abc", "def"), Is.EqualTo(""));
        }

        [Test]
        public void TestPartialMatch()
        {
            Assert.That(StringAlgorithm.CommonSubstring("abcdef", "defabc"), Is.EqualTo("abc"));
        }

        [Test]
        public void TestIdenticalStrings()
        {
            Assert.That(StringAlgorithm.CommonSubstring("hello", "hello"), Is.EqualTo("hello"));
        }

        [Test]
        public void TestEmptyStrings()
        {
            Assert.That(StringAlgorithm.CommonSubstring("", "test"), Is.EqualTo(string.Empty));
            Assert.That(StringAlgorithm.CommonSubstring("test", ""), Is.EqualTo(string.Empty));
            Assert.That(StringAlgorithm.CommonSubstring("", ""), Is.EqualTo(string.Empty));
        }
    }
}
