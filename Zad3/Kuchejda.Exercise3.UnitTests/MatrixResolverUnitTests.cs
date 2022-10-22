using NUnit.Framework;

namespace Kuchejda.Exercise3.UnitTests
{
    [TestFixture]
    public class MatrixResolverUnitTests
    {
        private MatrixResolver _service;

        [SetUp]
        public void SetUp()
        {
            _service = new MatrixResolver();
        }

        [Test]
        public void Resolve_InvalidArray1_ShouldThrowException()
        {
            var input = new int[,]
            {
                {2,4,4,0},
                {3,0,2,0 },
                {1,0,0,4 },
                {0,0,1,2 },
            };

            var exception = Assert.Throws<Exception>(() => _service.Resolve(input, 2));

            Assert.IsNotNull(exception);
            Assert.AreEqual("Solution not found, input file is invalid", exception.Message);
        }

        [Test]
        public void Resolve_InvalidArray2_ShouldThrowException()
        {
            var input = new int[,]
            {
                {2,0,4,0},
                {3,3,2,0 },
                {1,0,0,4 },
                {0,0,1,2 },
            };

            var exception = Assert.Throws<Exception>(() => _service.Resolve(input, 2));

            Assert.IsNotNull(exception);
            Assert.AreEqual("Solution not found, input file is invalid", exception.Message);
        }
        [Test]
        public void Resolve_InvalidArray3_ShouldThrowException()
        {
            var input = new int[,]
            {
                {2,0,4,0},
                {3,0,2,0 },
                {3,0,0,4 },
                {0,0,1,2 },
            };

            var exception = Assert.Throws<Exception>(() => _service.Resolve(input, 2));

            Assert.IsNotNull(exception);
            Assert.AreEqual("Solution not found, input file is invalid", exception.Message);
        }

        [Test]
        public void Resolve_ValidArray_ValidOutPut()
        {
            var input = new int[,]
            {
                {2,0,4,0},
                {3,0,2,0 },
                {1,0,0,4 },
                {0,0,1,2 },
            };
            var expectedInput = new int[,]
            {
                {2,1,4,3},
                {3,4,2,1 },
                {1,2,3,4 },
                {4,3,1,2 },
            };

            _service.Resolve(input, 2);

            Verify(input, expectedInput);
        }

        [Test]
        public void Resolve_ValidArray1_ValidOutPut()
        {
            var input = new int[,]
            {
                {0,2,0,4},
                {3,0,0,0 },
                {4,1,2,3 },
                {0,3,4,0 },
            };
            var expectedInput = new int[,]
            {
                {1,2,3,4},
                {3,4,1,2 },
                {4,1,2,3 },
                {2,3,4,1 },
            };

            _service.Resolve(input, 2);

            Verify(input, expectedInput);
        }

        [Test]
        public void Resolve_ValidArray2_ValidOutPut()
        {
            var input = new int[,]
            {
                {0,0,4,0},
                {0,4,0,0 },
                {4,3,1,2 },
                {0,2,3,4 },
            };
            var expectedInput = new int[,]
            {
                {2,1,4,3},
                {3,4,2,1 },
                {4,3,1,2 },
                {1,2,3,4 },
            };

            _service.Resolve(input, 2);

            Verify(input, expectedInput);
        }

        private void Verify(int[,] input, int[,] expectedInput)
        {
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    var value = input[i,j];
                    var expectedValue = expectedInput[i,j];
                    Assert.AreEqual(expectedValue, value);
                }
            }
        }
    }
}