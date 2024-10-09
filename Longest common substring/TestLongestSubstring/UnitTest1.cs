namespace TestLongestSubstring
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
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
            //Assert.AreEqual("hello", StringAlgorithm.CommonSubstring("hello", "hello"));
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