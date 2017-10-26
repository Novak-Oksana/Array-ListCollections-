using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Massive_Coll;


namespace NUnitTests
{
    [TestFixture(typeof(Alist0))]
    [TestFixture(typeof(Alist1))]
    [TestFixture(typeof(Alist2))]
    [TestFixture(typeof(Llist1))]
    [TestFixture(typeof(Llist2))]
    [TestFixture(typeof(LlistR))]
    [TestFixture(typeof(LlistF))]

    public class AlistTests<TPage> where TPage : Ilist, new()
    {
        Ilist lst = new TPage();

        [SetUp]
        public void SetUp()
        {
            lst.Clear();
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void ForeachNUTest(int[] input)
        {
            lst.Init(input);
            int i = 0;
            foreach (int item in lst)
            {
                Assert.AreEqual(input[i++], item);
            }
        }

        [Test]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { 10 })]
        [TestCase(new int[] { 10, 20 }, new int[] { 10, 20 })]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 10, 20, 30, 40, 50, 60 })]
        public void InitNUTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 10 }, 1)]
        [TestCase(new int[] { 10, 20 }, 2)]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, 6)]
        public void SizeNUTest(int[] ini, int exp)
        {
            lst.Init(ini);
            int size = lst.Size();
            Assert.AreEqual(exp, size);
        }

        [Test]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 10 }, 0)]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, 0)]
        public void ClearTest(int[] ini, int exp)
        {
            lst.Init(ini);
            lst.Clear();
            int size = lst.Size();
            Assert.AreEqual(exp, size);
        }

        [Test]
        //  [TestCase(new int[] { }, "")]
        [TestCase(new int[] { 10 }, "10")]
        [TestCase(new int[] { 10, 20, 30 }, "10, 20, 30")]
        public void ToStringTest(int[] ini, String exp)
        {
            lst.Init(ini);
            Assert.AreEqual(exp, lst.ToString());
        }

        [Test]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { 10 })]
        [TestCase(new int[] { 10, 20 }, new int[] { 10, 20 })]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 10, 20, 30, 40, 50, 60 })]
        public void ToArrayTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        // [TestCase(1, new int[] { }, 500, new int[] { 500 })]
        [TestCase(2, new int[] { 10 }, 500, new int[] { 500, 10 })]
        [TestCase(3, new int[] { 10, 20 }, 500, new int[] { 500, 10, 20 })]
        [TestCase(7, new int[] { 10, 20, 30, 40, 50, 60 }, 500, new int[] { 500, 10, 20, 30, 40, 50, 60 })]
        public void AddStartTest(int size, int[] ini, int add, int[] exp)
        {
            lst.Init(ini);
            lst.AddStart(add);
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        [TestCase(1, new int[] { }, 500, new int[] { 500 })]
        [TestCase(2, new int[] { 10 }, 500, new int[] { 10, 500 })]
        [TestCase(3, new int[] { 10, 20 }, 500, new int[] { 10, 20, 500 })]
        [TestCase(7, new int[] { 10, 20, 30, 40, 50, 60 }, 500, new int[] { 10, 20, 30, 40, 50, 60, 500 })]
        public void AddEndTest(int size, int[] ini, int add, int[] exp)
        {
            lst.Init(ini);
            lst.AddEnd(add);
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        [TestCase(new int[] { 10 }, 0, 500, 2, new int[] { 500, 10 })]
        [TestCase(new int[] { 10, 20 }, 1, 500, 3, new int[] { 10, 500, 20 })]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, 2, 500, 7, new int[] { 10, 20, 500, 30, 40, 50, 60 })]
        public void AddPosTest(int[] ini, int pos, int val, int size, int[] exp)
        {
            lst.Init(ini);
            lst.AddPos(pos, val);
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }
        /*
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPosTest_Ex()
        {
            lst.Init(new int[] { 1, 2, 3, 4, 5 });
            lst.AddPos(6, 1);
        }*/

        [Test]
        // [TestCase(new int[] { }, new int[] { })]
        [TestCase(10, 0, new int[] { 10 }, new int[] { })]
        [TestCase(10, 1, new int[] { 10, 20 }, new int[] { 20 })]
        [TestCase(40, 2, new int[] { 40, 20, 30 }, new int[] { 20, 30 })]
        [TestCase(70, 5, new int[] { 70, 20, 30, 40, 50, 60 }, new int[] { 20, 30, 40, 50, 60 })]
        public void DelStartTest(int val, int size, int[] ini, int[] exp)
        {
            lst.Init(ini);
            Assert.AreEqual(val, lst.DelStart());
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        // [TestCase(new int[] { }, new int[] { })]
        [TestCase(10, 0, new int[] { 10 }, new int[] { })]
        [TestCase(20, 1, new int[] { 10, 20 }, new int[] { 10 })]
        [TestCase(30, 2, new int[] { 10, 20, 30 }, new int[] { 10, 20 })]
        [TestCase(60, 5, new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 10, 20, 30, 40, 50 })]
        public void DelEndTest(int val, int size, int[] ini, int[] exp)
        {
            lst.Init(ini);
            Assert.AreEqual(val, lst.DelEnd());
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        [TestCase(1, 0, 0, new int[] { 1 }, new int[] { })]
        [TestCase(1, 0, 1, new int[] { 1, 2 }, new int[] { 2 })]
        [TestCase(2, 1, 1, new int[] { 1, 2 }, new int[] { 1 })]
        [TestCase(1, 0, 5, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 2, 3, 4, 5, 6 })]
        public void DelPosTest(int val, int pos, int size, int[] ini, int[] exp)
        {
            lst.Init(ini);
            Assert.AreEqual(val, lst.DelPos(pos));
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }//дописать exception для pos
        /*
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DelPosTest_Ex()
        {
            lst.Init(new int[] { 1, 2, 3, 4, 5 });
            lst.AddPos(6, 1);
        }*/

        [Test]
        [TestCase(new int[] { 10 }, 10)]
        [TestCase(new int[] { 10, 20 }, 10)]
        [TestCase(new int[] { 10, 20, 5 }, 5)]
        [TestCase(new int[] { 0, 20, 30, 40, 50, 60 }, 0)]
        public void MinTest(int[] ini, int exp)
        {
            lst.Init(ini);
            int min = lst.Min();
            Assert.AreEqual(exp, min);
        }

        [Test]
        [TestCase(new int[] { 10 }, 10)]
        [TestCase(new int[] { 10, 20 }, 20)]
        [TestCase(new int[] { 10, 20, 35 }, 35)]
        [TestCase(new int[] { 0, 20, 30, 40, 50, 60 }, 60)]
        public void MaxTest(int[] ini, int exp)
        {
            lst.Init(ini);
            int max = lst.Max();
            Assert.AreEqual(exp, max);
        }

        [Test]
        [TestCase(new int[] { 10 }, 0)]
        [TestCase(new int[] { 10, 20 }, 0)]
        [TestCase(new int[] { 10, 20, 5 }, 2)]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 3 }, 5)]
        public void MinPosTest(int[] ini, int exp)
        {
            lst.Init(ini);
            int minp = lst.MinPos();
            Assert.AreEqual(exp, minp);
        }

        [Test]
        [TestCase(new int[] { 10 }, 0)]
        [TestCase(new int[] { 10, 20 }, 1)]
        [TestCase(new int[] { 10, 20, 5 }, 1)]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 3 }, 4)]
        public void MaxPosTest(int[] ini, int exp)
        {
            lst.Init(ini);
            int maxp = lst.MaxPos();
            Assert.AreEqual(exp, maxp);
        }

        [Test]
        //  [TestCase(new int[] { }, 0, 500, new int[] { 500 })]
        [TestCase(new int[] { 10 }, 0, 500, new int[] { 500 })]
        [TestCase(new int[] { 10, 20 }, 1, 500, new int[] { 10, 500 })]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, 2, 500, new int[] { 10, 20, 500, 40, 50, 60 })]
        public void SetTest(int[] ini, int pos, int add, int[] exp)
        {
            lst.Init(ini);
            lst.Set(pos, add);
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        //  [TestCase(new int[] { }, 0, 500, new int[] { 500 })]
        [TestCase(new int[] { 10 }, 0, 10)]
        [TestCase(new int[] { 10, 20 }, 1, 20)]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, 2, 30)]
        public void GetTest(int[] ini, int pos, int exp)
        {
            lst.Init(ini);
            int el = lst.Get(pos);
            Assert.AreEqual(exp, el);
        }

        [Test]
        // [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { 10 })]
        [TestCase(new int[] { 10, 20 }, new int[] { 10, 20 })]
        [TestCase(new int[] { 60, 10, 20, 30, 40, 50 }, new int[] { 10, 20, 30, 40, 50, 60 })]
        public void SortTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.Sort();
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        // [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { 10 })]
        [TestCase(new int[] { 10, 20 }, new int[] { 20, 10 })]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, new int[] { 50, 40, 30, 20, 10 })]
        public void ReverseTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.Reverse();
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        // [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { 10 })]
        [TestCase(new int[] { 10, 20 }, new int[] { 20, 10 })]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, new int[] { 40, 50, 30, 10, 20 })]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 40, 50, 60, 10, 20, 30 })]
        public void HalfReverseTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.HalfReverse();
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }
    }
}
