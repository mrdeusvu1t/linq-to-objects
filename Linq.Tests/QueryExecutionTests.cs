using System.Collections.Generic;
using NUnit.Framework;
using static Linq.QueryExecution;

namespace Linq.Tests
{
    [TestFixture]
    public class QueryExecutionTests
    {
        [Test]
        public void LazyExecutionTest()
        {
            var expected = new List<int> {9, 8, 6, 7, 10};
            
            CollectionAssert.AreEqual(expected, LazyExecution());
        }
        
        [Test]
        public void EagerExecutionTest()
        {
            var expected = new List<int> {9, 8, 6, 7};
            
            CollectionAssert.AreEqual(expected, EagerExecution());
        }
    }
}