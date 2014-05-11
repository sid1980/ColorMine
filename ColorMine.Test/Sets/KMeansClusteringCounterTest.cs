﻿using ColorMine.ColorSpaces;
using ColorMine.Sets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ColorMine.Test.Sets
{
    [TestClass]
    public class KMeansClusteringCounterTest
    {
        [TestClass]
        public class CountColors
        {
            [TestMethod]
            public void EmptyInputGetsEmptyResponse()
            {
                var matrix = new Mock<IColorMatrix>();
                var target = new KMeansClusteringCounter<Rgb>(10, 10);
                var result = target.GetColorSet(matrix.Object);
                Assert.AreEqual(0, result.Count);
            }
        }
    }
}
