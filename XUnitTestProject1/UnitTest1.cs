using ScrumPoker;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private readonly ConsoleProcessor consoleProcessor;  // test object

        public UnitTest1(ITestOutputHelper output)
        {
            FakeConsoleWrapper fakeWrapper = new FakeConsoleWrapper();
            fakeWrapper.Output = output;
            consoleProcessor = new ConsoleProcessor(fakeWrapper);
        }

        [Fact]
        public void PopulateDataTest()
        {
            consoleProcessor.PopulateData();
            consoleProcessor.PrintAll();
        }

        [Fact]
        public void VoitingTest()
        {
            consoleProcessor.Voiting();
            consoleProcessor.PrintAll();
        }

        [Fact]
        public void CheckPointsTest()
        {
            consoleProcessor.VoitingData.Add("vasya", 1);
            consoleProcessor.VoitingData.Add("oleg", 1);
            consoleProcessor.CheckPoints();
        }

        [Fact]
        public void ScrumMasterPointSetTest()
        {
            consoleProcessor.ScrumMasterPointSet();
        }
    }
}
