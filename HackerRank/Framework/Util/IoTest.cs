using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Framework.Util
{
    public abstract class IoTest
    {
        protected string Input;
        protected string ExpectedOutput;
        protected Action Proccess;

        [Fact]
        public void Test()
        {
            using (var sr = new StringReader(Input))
            using (var sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Proccess();

                Assert.Equal(ExpectedOutput, sw.ToString());
            }
        }
    }
    public abstract class IoTestSkip
    {
        private readonly ITestOutputHelper _output;
        protected string Input;
        protected string ExpectedOutput;
        protected Action Proccess;

        protected IoTestSkip(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(Skip = "Heavy test")]
        public void Test()
        {
            using (var sr = new StringReader(Input))
            using (var sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Proccess();

                Assert.Equal(sw.ToString(), ExpectedOutput);
                _output.WriteLine(ExpectedOutput);
            }
        }
    }
}

