using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

            Assert.AreEqual(new BigInteger(3), PathFinderResult.Results);
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

            Assert.AreEqual(new BigInteger(2), PathFinderResult.Results);
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

            Assert.AreEqual(new BigInteger(1), PathFinderResult.Results);
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

            Assert.AreEqual(new BigInteger(2), PathFinderResult.Results);
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

            Assert.AreEqual(new BigInteger(0), PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult6()
        {
            var @array = new char[,]
            {
                {'.','.','.','*' },
                {'.','.','.','.' },
                {'.','.','.','.' },
                {'*','.','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(new BigInteger(18), PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult7()
        {
            var @array = new char[,]
            {
                {'.','.','.','.','.','*' },
                {'.','*','*','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','.','.','*','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(new BigInteger(1), PathFinderResult.Results);
        }
        [Test]
        public void PathFinder_ValidArray_ValidResult8()
        {
            var @array = new char[,]
            {
                {'.','.','.','.','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','.','.','*','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(new BigInteger(1), PathFinderResult.Results);
        }
        [Test]
        public void PathFinder_ValidArray_ValidResult9()
        {
            var @array = new char[,]
            {
                {'.','.','.','.','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(new BigInteger(1), PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult10()
        {
            var @array = new char[,]
            {
                {'.','*','.','.','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','.','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(new BigInteger(0), PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult11()
        {
            var @array = new char[,]
            {
                {'.','.','.','.','.','*' },
                {'.','*','*','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','*','*','.','*' },
                {'.','.','.','.','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(new BigInteger(2), PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult12()
        {
            var @array = new char[,]
            {
                {'.','.','.','.','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','.','.','.','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(new BigInteger(3), PathFinderResult.Results);
        }

        [Test]
        public void PathFinder_ValidArray_ValidResult13()
        {
            var @array = new char[,]
            {
                {'.','.','.','.','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','.','*','.','*' },
                {'.','*','*','*','.','*' },
                {'.','.','.','.','.','.' }
            };

            _service.Resolve(@array);

            Assert.AreEqual(new BigInteger(2), PathFinderResult.Results);
        }
    }
}
