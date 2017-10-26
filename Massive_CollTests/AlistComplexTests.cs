using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Massive_Coll;

namespace Massive_CollTests
{
    [TestClass]
    public class Alist0_ComplexTest : IAList_ComplexTest
    {
        internal override Ilist MakeList()
        {
            return new Alist0();
        }
    }

    [TestClass]
    public class Alist1_ComplexTest : IAList_ComplexTest
    {
        internal override Ilist MakeList()
        {
            return new Alist1();
        }
    }

    [TestClass]
    public class Alist2_ComplexTest : IAList_ComplexTest
    {
        internal override Ilist MakeList()
        {
            return new Alist2();
        }
    }

    [TestClass]
    public class Llist1_ComplexTest : IAList_ComplexTest
    {
        internal override Ilist MakeList()
        {
            return new Llist1();
        }
    }

    [TestClass]
    public class Llist2_ComplexTest : IAList_ComplexTest
    {
        internal override Ilist MakeList()
        {
            return new Llist2();
        }
    }


    [TestClass]
    public abstract class IAList_ComplexTest
    {
        internal abstract Ilist MakeList();

        Ilist lst;

        public IAList_ComplexTest()
        {
            lst = MakeList();
        }

        [TestInitialize]
        public void TestSetUp()
        {
            lst.Clear();
        }

        [DataTestMethod]//Get, Set
        [DataRow(0, 0, new int[] { 10 }, new int[] { 10 })]
        [DataRow(0, 1, new int[] { 10, 20 }, new int[] { 10, 10 })]
        [DataRow(2, 5, new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 10, 20, 30, 40, 50, 30 })]
        [TestMethod()]
        public void TestGetSet(int posGet, int posSet, int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.Set(posSet, lst.Get(posGet));
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }

        [DataTestMethod] //AddPos, Sort
        [DataRow(0, 40, new int[] { 10 }, new int[] { 10, 40 })]
        [DataRow(1, -1, new int[] { 10, 20 }, new int[] { -1, 10, 20 })]
        [DataRow(2, 15, new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 10, 15, 20, 30, 40, 50, 60 })]
        [TestMethod()]
        public void TestAddPosSort(int pos, int val, int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.AddPos(pos, val);
            lst.Sort();
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }

        [DataTestMethod] //AddStart, Reverse
        [DataRow(40, new int[] { 10 }, new int[] { 10, 40 })]
        [DataRow(1, new int[] { 10, 20 }, new int[] { 20, 10, 1 })]
        [DataRow(15, new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 60, 50, 40, 30, 20, 10, 15 })]
        [TestMethod()]
        public void TestAddStartReverse(int val, int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.AddStart(val);
            lst.Reverse();
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }

        [DataTestMethod] // AddEnd, HalfReverse
        [DataRow(40, new int[] { 10 }, new int[] { 40, 10 })]
        [DataRow(1, new int[] { 10, 20 }, new int[] { 1, 20, 10 })]
        [DataRow(15, new int[] { 10, 20, 30, 40, 50 }, new int[] { 40, 50, 15, 10, 20, 30 })]
        [TestMethod()]
        public void TestAddEndHalfReverse(int val, int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.AddEnd(val);
            lst.HalfReverse();
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }

        [DataTestMethod] //MinPos, DelPos, Sort
        [DataRow(new int[] { 10, 20 }, new int[] { 20 })]
        [DataRow(new int[] { 10, 20, -30, 40, 50, 60 }, new int[] { 10, 20, 40, 50, 60 })]
        [TestMethod()]
        public void TestMinPosDelPosSort(int[] ini, int[] exp)
        {
            lst.Init(ini);
            lst.DelPos(lst.MinPos());
            lst.Sort();
            int[] act = lst.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
    }
}
