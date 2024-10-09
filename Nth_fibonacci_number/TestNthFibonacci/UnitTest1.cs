namespace TestNthFibonacci
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
        public void TestSmallNo()
        {
            Assert.That(FibonacciEquivalent.Fib(5), Is.EqualTo(5));
        }

        [Test]
        public void TestLargerNo()
        {
            Assert.That(FibonacciEquivalent.Fib(6), Is.EqualTo(8));
        }
    }
}