using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3.Tests
{
    [TestFixture]
    public class CustomQueueTests
    {
        [Test]
        public void Queueforeach_IntQueue_EqualInitialList()
        {
            List<int> expectedList = new List<int>{1, 2, 3, 4, 5, 6, 7};
            List<int> queueList = new List<int>(expectedList.Capacity);

            CustomQueue<int> queue = new CustomQueue<int>(expectedList);

            using (var enumerator = queue.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    queueList.Add(enumerator.Current);
                }
            }

            Assert.AreEqual(true, expectedList.SequenceEqual(queueList));           
        }

        [Test]
        [ExpectedException]
        public void Peek_EmptyQueue_ThrownedException()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Peek();
        }
        [Test]
        public void Peek_DoubleQueue_ReturnedRightNumber()
        {
            CustomQueue<double> queue = new CustomQueue<double>(10);
            queue.Enqueue(10.95);
            queue.Enqueue(11.95);
            queue.Enqueue(12.95);
            Debug.WriteLine(queue.Dequeue());
            Debug.WriteLine(queue.Dequeue());
            Debug.WriteLine(queue.Peek());
            Assert.AreEqual(12.95, queue.Dequeue());
        }
    }
}
