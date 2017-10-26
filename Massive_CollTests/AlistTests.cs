using Massive_Coll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Massive_Coll.Class1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Massive_Coll.Class1.Tests
{   
    [TestClass]
    public class Alist0_Test : IAList_Test
    {
        internal override Ilist MakeList()
        {
            return new Alist0();
        }
    }
    
    [TestClass]
    public class Alist1_Test : IAList_Test
    {
        internal override Ilist MakeList()
        {
            return new Alist1();
        }
    }
    
    [TestClass]
    public class Alist2_Test : IAList_Test
    {
        internal override Ilist MakeList()
        {
            return new Alist2();
        }
    }

    [TestClass]
    public class AlistR_Test : IAList_Test
    {
        internal override Ilist MakeList()
        {
            return new AlistR();
        }
    }

    [TestClass]
    public class Llist1_Test : IAList_Test
    {
        internal override Ilist MakeList()
        {
            return new Llist1();
        }
    }
   
   [TestClass]
   public class Llist2_Test : IAList_Test
   {
       internal override Ilist MakeList()
       {
           return new Llist2();
       }
   }
    
  [TestClass]
  public class LlistR_Test : IAList_Test
  {
      internal override Ilist MakeList()
      {
          return new LlistR();
      }
  }

    [TestClass]
    public class LlistF_Test : IAList_Test
    {
        internal override Ilist MakeList()
        {
            return new LlistF();
        }
    }

    [TestClass()]
    public abstract class IAList_Test
    {

        /*
        Ilist lst;
        [TestInitialize]
        public void SetUp()
        {
            lst = new Llist2();

        }*/
        internal abstract Ilist MakeList();

        Ilist lst;

        public IAList_Test()
        {
            lst = MakeList();
        }

        [TestInitialize]
        public void TestSetUp()
        {
            lst.Clear();
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow(new int[] { })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void ForeachTest(int[] input)
        {
            lst.Init(input);
            int i = 0;
            foreach (int item in lst)
            {
                Assert.AreEqual(input[i++], item);
            }
        }

        [DataTestMethod]
        [DataRow(null, new int[] { })]
        [DataRow(new int[] { }, new int[] { })]
        [DataRow(new int[] { 10 }, new int[] { 10 })]
        [DataRow(new int[] { 10, 20 }, new int[] { 10, 20 })]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 10, 20, 30, 40, 50, 60 })]
        [TestMethod()]
        public void InitTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }

        [DataTestMethod]
        [DataRow(null, 0)]
        [DataRow(new int[] { }, 0)]
        [DataRow(new int[] { 10 }, 1)]
        [DataRow(new int[] { 10, 20 }, 2)]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 60 }, 6)]
        [TestMethod()]
        public void SizeTest(int[] ini, int exp)
        {
            lst.Init(ini);
            int size = lst.Size();
            Assert.AreEqual(exp, size);

        }

        [DataTestMethod]
        [DataRow(null, 0)]
        [DataRow(new int[] { }, 0)]
        [DataRow(new int[] { 10 }, 0)]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 60 }, 0)]
        [TestMethod()]
        public void ClearTest(int[] ini, int exp)
        {
            lst.Init(ini);
            lst.Clear();
            int size = lst.Size();
            Assert.AreEqual(exp, size);
        }

        [DataTestMethod]
        //[DataRow(null, "")]
       // [DataRow(new int[] { }, "")]
        [DataRow(new int[] { 10 }, "10")]
        [DataRow(new int[] { 10, 20, 30 }, "10, 20, 30")]
        [TestMethod()]
        public void ToStringTest(int[] ini, String exp)
        {
            lst.Init(ini);
            Assert.AreEqual(exp, lst.ToString());
        }

        [DataTestMethod]
        [DataRow(new int[] { }, new int[] { })]
        [DataRow(new int[] { 10 }, new int[] { 10 })]
        [DataRow(new int[] { 10, 20 }, new int[] { 10, 20 })]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 10, 20, 30, 40, 50, 60 })]
        [TestMethod()]
        public void ToArrayTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
         [DataRow(1, new int[] { }, 500, new int[] { 500 })]
        [DataRow(2, new int[] { 10 }, 500, new int[] { 500, 10 })]
        [DataRow(3, new int[] { 10, 20 }, 500, new int[] { 500, 10, 20 })]
        [DataRow(7, new int[] { 10, 20, 30, 40, 50, 60 }, 500, new int[] { 500, 10, 20, 30, 40, 50, 60 })]
        [DataRow(11, new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 }, 500, new int[] { 500, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 })]
        [TestMethod()]
        public void AddStartTest(int size, int[] ini, int add, int[] exp)
        {
            lst.Init(ini);
            lst.AddStart(add);
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
        [DataRow(1, new int[] { }, 500, new int[] { 500 })]
        [DataRow(2, new int[] { 10 }, 500, new int[] { 10, 500 })]
        [DataRow(3, new int[] { 10, 20 }, 500, new int[] { 10, 20, 500 })]
        [DataRow(7, new int[] { 10, 20, 30, 40, 50, 60 }, 500, new int[] { 10, 20, 30, 40, 50, 60, 500 })]
        [DataRow(11, new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 }, 500, new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 500 })]
        [TestMethod()]
        public void AddEndTest(int size, int[] ini, int add, int[] exp)
        {
            lst.Init(ini);
            lst.AddEnd(add);
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
        [DataRow(new int[] { 10 }, 0, 500, 2, new int[] { 500, 10 })]
        [DataRow(new int[] { 10, 20 }, 1, 500, 3, new int[] { 10, 500, 20 })]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 60 }, 2, 500, 7, new int[] { 10, 20, 500, 30, 40, 50, 60 })]
        [TestMethod()]
        public void AddPosTest(int[] ini, int pos, int val, int size, int[] exp)
        {
            lst.Init(ini);
            lst.AddPos(pos, val);
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
        //[DataRow(new int[] { 1 }, -1)]
        [DataRow(new int[] { 1 }, 2)]
        [DataRow(new int[] { 1, 2 }, 3)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddPosTest_Ex(int[] init, int pos)
        {
            lst.Init(init);
            lst.AddPos(pos, 1);
        }

        [DataTestMethod]
        [DataRow(10, 0, new int[] { 10 }, new int[] { })]
        [DataRow(10, 1, new int[] { 10, 20 }, new int[] { 20 })]
        [DataRow(40, 2, new int[] { 40, 20, 30 }, new int[] { 20, 30 })]
        [DataRow(70, 5, new int[] { 70, 20, 30, 40, 50, 60 }, new int[] { 20, 30, 40, 50, 60 })]
        [TestMethod()]
        public void DelStartTest(int val, int size, int[] ini, int[] exp)
        {
            lst.Init(ini);
            Assert.AreEqual(val, lst.DelStart());
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }
        [TestMethod]
        [ExpectedException(typeof(Empty_array_Ex))]
        public void DelStartTest_Ex()
        {
            lst.Init(new int[] { });
            lst.DelStart();
        }

        [DataTestMethod]
       //  [DataRow(new int[] { }, new int[] { })]
        [DataRow(10, 0, new int[] { 10 }, new int[] { })]
        [DataRow(20, 1, new int[] { 10, 20 }, new int[] { 10 })]
        [DataRow(30, 2, new int[] { 10, 20, 30 }, new int[] { 10, 20 })]
        [DataRow(60, 5, new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 10, 20, 30, 40, 50 })]
        [TestMethod()]
        public void DelEndTest(int val, int size, int[] ini, int[] exp)
        {
            lst.Init(ini);
            Assert.AreEqual(val, lst.DelEnd());
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
        [DataRow(1, 0, 0, new int[] { 1 }, new int[] { })]
        [DataRow(1, 0, 1, new int[] { 1, 2 }, new int[] { 2 })]
        [DataRow(2, 1, 1, new int[] { 1, 2 }, new int[] { 1 })]
        [DataRow(1, 0, 5, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 2, 3, 4, 5, 6 })]

        [TestMethod()]
        public void DelPosTest(int val, int pos, int size, int[] ini, int[] exp)
        {
            lst.Init(ini);
            Assert.AreEqual(val, lst.DelPos(pos));
            Assert.AreEqual(size, lst.Size());
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }//дописать exception для pos
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DelPosTest_Ex()
        {
            lst.Init(new int[] { 1, 2, 3, 4, 5 });
            lst.AddPos(6, 1);
        }

        [DataTestMethod]
        [DataRow(new int[] { 10 }, 10)]
        [DataRow(new int[] { 10, 20 }, 10)]
        [DataRow(new int[] { 10, 20, 5 }, 5)]
        [DataRow(new int[] { 0, 20, 30, 40, 50, 60 }, 0)]
        [TestMethod()]
        public void MinTest(int[] ini, int exp)// продолж
        {
            lst.Init(ini);
            int min = lst.Min();
            Assert.AreEqual(exp, min);
        }

        [DataTestMethod]
        [DataRow(new int[] { 10 }, 10)]
        [DataRow(new int[] { 10, 20 }, 20)]
        [DataRow(new int[] { 10, 20, 35 }, 35)]
        [DataRow(new int[] { 0, 20, 30, 40, 50, 60 }, 60)]
        [TestMethod()]
        public void MaxTest(int[] ini, int exp)
        {
            lst.Init(ini);
            int max = lst.Max();
            Assert.AreEqual(exp, max);
        }

        [DataTestMethod]
        [DataRow(new int[] { 10 }, 0)]
        [DataRow(new int[] { 10, 20 }, 0)]
        [DataRow(new int[] { 10, 20, 5 }, 2)]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 3 }, 5)]
        [TestMethod()]
        public void MinPosTest(int[] ini, int exp)
        {
            lst.Init(ini);
            int minp = lst.MinPos();
            Assert.AreEqual(exp, minp);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10 }, 0)]
        [DataRow(new int[] { 10, 20 }, 1)]
        [DataRow(new int[] { 10, 20, 5 }, 1)]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 3 }, 4)]
        [TestMethod()]
        public void MaxPosTest(int[] ini, int exp)
        {
            lst.Init(ini);
            int maxp = lst.MaxPos();
            Assert.AreEqual(exp, maxp);
        }

        [DataTestMethod]
        [DataRow(new int[] { 10 }, 0, 500, new int[] { 500 })]
        [DataRow(new int[] { 10, 20 }, 1, 500, new int[] { 10, 500 })]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 60 }, 2, 500, new int[] { 10, 20, 500, 40, 50, 60 })]
        [TestMethod()]
        public void SetTest(int[] ini, int pos, int add, int[] exp)
        {
            lst.Init(ini);
            lst.Set(pos, add);
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
        [DataRow(null, 0, 1)]
        [DataRow(new int[] { }, 0, 1)]
        [ExpectedException(typeof(Empty_array_Ex))]
        public void SetTest_Ex(int[] init, int pos, int val)
        {
            lst.Init(init);
            lst.Set(pos, val);
        }

        [DataTestMethod]
        [DataRow(new int[] { 10 }, 0, 10)]
        [DataRow(new int[] { 10, 20 }, 1, 20)]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 60 }, 2, 30)]
        [TestMethod()]
        public void GetTest(int[] ini, int pos, int exp)
        {
            lst.Init(ini);
            int el = lst.Get(pos);
            Assert.AreEqual(exp, el);
        }

        [DataTestMethod]
        [DataRow(null, 0, 1)]
        [DataRow(new int[] { }, 0, 1)]
        [ExpectedException(typeof(Empty_array_Ex))]
        public void GetTest_Ex(int[] init, int pos, int val)
        {
            lst.Init(init);
            lst.Get(pos);
        }

        [DataTestMethod]
        // [DataRow(new int[] { }, new int[] { })]
        [DataRow(new int[] { 10 }, new int[] { 10 })]
        [DataRow(new int[] { 10, 20 }, new int[] { 10, 20 })]
        [DataRow(new int[] { 60, 10, 20, 30, 40, 50 }, new int[] { 10, 20, 30, 40, 50, 60 })]
        [TestMethod()]
        public void SortTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.Sort();
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
        // [DataRow(new int[] { }, new int[] { })]
        [DataRow(new int[] { 10 }, new int[] { 10 })]
        [DataRow(new int[] { 10, 20 }, new int[] { 20, 10 })]
        [DataRow(new int[] { 10, 20, 30, 40, 50 }, new int[] { 50, 40, 30, 20, 10 })]
        [TestMethod()]
        public void ReverseTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.Reverse();
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
        //[DataRow(new int[] { }, new int[] { })]
        [DataRow(new int[] { 10 }, new int[] { 10 })]
        [DataRow(new int[] { 10, 20 }, new int[] { 20, 10 })]
        [DataRow(new int[] { 10, 20, 30 }, new int[] { 30, 20, 10 })]
        [DataRow(new int[] { 10, 20, 30, 40, 50 }, new int[] { 40, 50, 30, 10, 20 })]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 40, 50, 60, 10, 20, 30 })]
        [TestMethod()]
        public void HalfReverseTest(int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.HalfReverse();
            CollectionAssert.AreEqual(exp, lst.ToArray());
        }
    }
}