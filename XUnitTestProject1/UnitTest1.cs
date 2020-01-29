using System;
using ScrumPoker;
using System.Collections.Generic;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private readonly ConsoleProcessor consoleProcessor;  // test object
        private static Mock<IConsoleWrapper> _consoleWrapper;
        private static Mock<IConcoleProcesor> _consoleProcesor;

        public UnitTest1()
        {
            //setup
            _consoleWrapper = new Mock<IConsoleWrapper>();
            consoleProcessor = new ConsoleProcessor(_consoleWrapper.Object);
        }

        [Fact]
        public void PopulateDataTest()
        {
            //arrange
            _consoleWrapper.Setup(x => x.Write(It.IsAny<string>())).Verifiable();

            //act
            consoleProcessor.PopulateData();
            consoleProcessor.PrintAll();

            //assert
            _consoleWrapper.Verify(x => x.Write(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void VoitingTest()
        {
            //arrange
            _consoleWrapper.Setup(x => x.Write(It.IsAny<string>())).Verifiable();
            _consoleWrapper.Setup(x => x.Read()).Returns("Vasya");
            _consoleWrapper.Setup(x => x.ReadInt()).Returns(1);

            //act
            consoleProcessor.Voiting();
            consoleProcessor.PrintAll();

            //assert
            _consoleWrapper.Verify(x => x.Write(It.IsAny<string>()), Times.Exactly(3));
        }

        [Fact]
        public void CheckPointsTest()
        {
            //arrange
            var queueString = new Queue<string>();
            queueString.Enqueue("Vasya");
            queueString.Enqueue("Petya");
            _consoleWrapper.Setup(x => x.Write(It.IsAny<string>())).Verifiable();
            _consoleWrapper.Setup(x => x.Read()).Returns(queueString.Dequeue);
            _consoleWrapper.Setup(x => x.ReadInt()).Returns(2);

            //act
            consoleProcessor.PopulateData();
            consoleProcessor.CheckPoints();

            //assert
            _consoleWrapper.Verify(x => x.Write(It.IsAny<string>()), Times.Exactly(8));
        }

        [Fact]
        public void ScrumMasterPointSetTest()
        {
            //arrange
            _consoleWrapper.Setup(x => x.Write(It.IsAny<string>())).Verifiable();
            _consoleWrapper.Setup(x => x.ReadInt()).Returns(1);

            //act
            consoleProcessor.ScrumMasterPointSet();

            //assert
            _consoleWrapper.Verify(x => x.Write(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}