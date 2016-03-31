using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        private class Item
        {
            public int Number { get; set; }
            public string Name { get; set; }

            public Item(int number, string name)
            {
                Number = number;
                Name = name;
            }
        }

        private class ItemComparer : Comparer<Item>
        {
            public override int Compare(Item x, Item y)
            {
                return x.Number.CompareTo(y.Number);
            }
        }
        private static Item item = new Item(5, "notebook");
        private List<Item> items = new List<Item>() { new Item(1, "box"), new Item(2, "table"), new Item(3, "window"), item, new Item(4, "door") };

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(11)]
        public void Search_SortedIntList_Number(int listIndex)
        {
            List<int> list = new List<int> {1, 2, 3, 4, 5, 6, 15, 23, 54, 96, 156, 234, 300, 550, 759, 810, 911, 1024};
            int value = list[listIndex];
            int position = BinarySearch.Search(list.ToArray(), value);

            Assert.AreEqual(listIndex, position);       
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(18)]
        public void Search_SortedDoubleList_Number(int listIndex)
        {
            List<double> list = new List<double> { 1, 2, 3, 4, 5, 6, 15, 23.45, 54, 96, 156.34, 234, 300.123, 550.312, 752, 810, 911, 1024.00099, 1024.001};
            double value = list[listIndex];
            int position = BinarySearch.Search(list.ToArray(), value);

            Assert.AreEqual(listIndex, position);
        }

        [Test]        
        public void Search_SortedIntList_NotFound()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6};
            int index = BinarySearch.Search(list.ToArray(), 99);
            Assert.AreEqual(-1, index);
        }

        [Test]
        public void Search_UnsupportedType_Exception()
        {
            Assert.Throws<ArgumentException>(() => BinarySearch.Search(items.ToArray(), item));
        }

        [Test]
        public void Search_UnsupportedTypeWithComparer_Index()
        {
            int index = BinarySearch.Search(items.ToArray(), item, new ItemComparer());
            int expectedIndex = items.IndexOf(item);
            Assert.AreEqual(expectedIndex, index);
        }

    }
}
