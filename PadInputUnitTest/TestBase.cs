using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace PadInputUnitTest
{
    public abstract class TestBase
    {

        public TestBase(ITestOutputHelper output)
        {
            _output = output;
        }

        private readonly ITestOutputHelper _output;

    }
}
