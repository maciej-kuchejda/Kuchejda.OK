using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuchejda.Exercise4.UnitTests
{
    [TestFixture]
    public class PathFinderTests
    {
        private PathFinder _service;

        [SetUp]
        public void SetUp()
        {
            _service = new PathFinder();
            PathFinderResult.InitializeWithDefault();
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult1()
        {
            var @array = new char[,]
            {
                {'.','.','.','.' },
                {'.','*','.','.' },
                {'.','.','.','*' },
                {'*','.','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(7, PathFinderResult.ShortestPathReequiredSteps);
            Assert.AreEqual(3, PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult2()
        {
            var @array = new char[,]
            {
                {'.','.','.','.' },
                {'.','*','*','.' },
                {'.','.','.','*' },
                {'*','.','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(7, PathFinderResult.ShortestPathReequiredSteps);
            Assert.AreEqual(2, PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult3()
        {
            var @array = new char[,]
            {
                {'.','.','.','.' },
                {'*','.','*','*' },
                {'*','.','*','*' },
                {'*','.','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(7, PathFinderResult.ShortestPathReequiredSteps);
            Assert.AreEqual(1, PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult4()
        {
            var @array = new char[,]
            {
                {'.','.','.','.' },
                {'.','*','*','.' },
                {'.','.','.','.' },
                {'*','.','*','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(7, PathFinderResult.ShortestPathReequiredSteps);
            Assert.AreEqual(2, PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult5()
        {
            var @array = new char[,]
            {
                {'.','*','.','.','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','.','.','*','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(21, PathFinderResult.ShortestPathReequiredSteps);
            Assert.AreEqual(1, PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult6()
        {

        }
    }
}
