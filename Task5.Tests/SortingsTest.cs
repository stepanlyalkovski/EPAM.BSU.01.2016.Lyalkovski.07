using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task5.Tests
{
    [TestFixture]
    public class SortingsTest
    {
        [Test]
        public void Sorting()
        {
            int[] list =  {9, 4, 1, 15, 0, 10, 2, 19, 3, 5};
            List<int> expectedList = new List<int>(list);
            IStructuralEquatable se1 = list;

            expectedList.Sort();

            Sortings.Bubble(list);

            Assert.IsTrue(se1.Equals(expectedList.ToArray(), EqualityComparer<int>.Default));
        }
    }
}
