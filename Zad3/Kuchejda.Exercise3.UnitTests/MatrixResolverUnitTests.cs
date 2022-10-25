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

        [Test]
        public void Resolve_MainInputFromExercise_ValidOutPut()
        {
            var input = new int[,]
            {
                { 2,5,0,0,3,0,9,0,1},
                {0,1,0,0,0,4,0,0,0},
                {4,0,7,0,0,0,2,0,8},
                {0,0,5,2,0,0,0,0,0},
                {0,0,0,0,9,8,1,0,0},
                {0,4,0,0,0,3,0,0,0},
                {0,0,0,3,6,0,0,7,2},
                {0,7,0,0,0,0,0,0,3 },
                {9,0,3,0,0,0,6,0,4 }
            };
            var expectedInput = new int[,]
            {
                {2,5,8,7,3,6,9,4,1 },
                {6,1,9,8,2,4,3,5,7},
                {4,3,7,9,1,5,2,6,8},
                {3,9,5,2,7,1,4,8,6},
                {7,6,2,4,9,8,1,3,5},
                {8,4,1,6,5,3,7,2,9},
                {1,8,4,3,6,9,5,7,2},
                {5,7,6,1,4,2,8,9,3},
                {9,2,3,5,8,7,6,1,4}
            };

            _service.Resolve(input, 3);

            Verify(input, expectedInput);
        }

        private void Verify(int[,] input, int[,] expectedInput)
        {
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    var value = input[i, j];
                    var expectedValue = expectedInput[i, j];
                    Assert.AreEqual(expectedValue, value);
                }
            }
        }
    }
}