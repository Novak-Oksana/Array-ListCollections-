using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive_Coll
{
    public class LlistR : Ilist
    {
        Node root = null;

        class Node
        {
            public int val;
            public Node next = null;
            public Node prev = null;

            public Node(int val)
            {
                this.val = val;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            if (root == null)
                yield break;

            Node tmp = root;
            do
            {
                yield return tmp.val;
                tmp = tmp.next;
            }
            while (tmp != root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Init(int[] ini)
        {
            if (ini == null)
                ini = new int[0];

            for (int i = 0; i < ini.Length; i++)
            {
                AddEnd(ini[i]);
            }
        }

        public int Size()
        {
            if (root == null)
                return 0;
            int size = 0;
            Node p = root;
            while (p.next != root)
            {
                size++;
                p = p.next;
            }
            return size + 1;
        }

        public int[] ToArray()
        {
            int[] mas = new int[Size()];
            for (int i = 0; i < Size(); i++)
            {
                mas[i] = Get(i);
            }
            return mas;
        }

        public override String ToString()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();
            String result = "";
            for (int i = 0; i < Size(); i++)
            {
                if (result.Length > 0)
                    result += ", ";
                result = result + Get(i);
            }
            return result;
        }

        public void AddEnd(int val)
        {
            if (Size() == 0)
            {
                AddStart(val);
            }
            else
            {
                AddPos(Size(), val);
            }
        }

        public void AddStart(int val)
        {
            if (Size() == 0)
            {
                Node temp = new Node(val);
                root = temp;
                root.next = root;
                root.prev = root;
            }
            else
            {
                Node newNode = new Node(val);
                root.prev.next = newNode;
                newNode.prev = root.prev;
                newNode.next = root;
                root.prev = newNode;
                root = newNode;
            }
        }

        public void Clear()
        {
            root = null;
        }

        public int DelStart()
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();

            int rez = root.val;

            if (Size() != 1)
            {
                if (Size() == 2)
                {
                    root = root.next;
                    root.next = root;
                    root.prev = root;
                }
                else
                {
                    root.prev.next = root.next;
                    root.next.prev = root.prev;
                    root = root.next;
                }
            }
            else
            {
                Clear();
            }

            return rez;
        }

        public int DelEnd()
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();

            int rez = 0;

            if (Size() == 1)
            {
                rez = DelStart();
                return rez;
            }
            else if (Size() == 2)
            {
                rez = root.prev.val;
                root.prev = root;
                root.next = root;
            }
            else
            {
                rez = root.prev.val;
                root.prev.prev.next = root;
                root.prev = root.prev.prev;
            }
            return rez;
        }

        public int DelPos(int pos)
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();
            if (pos < 0 || pos > Size() - 1)
                throw new IndexOutOfRangeException();

            int rez = 0;
            if (pos == 0)
            {
                rez = DelStart();
            }
            else if (pos == Size() - 1)
            {
                rez = DelEnd();
            }
            else
            {
                Node current = GetNode(pos - 1);
                rez = current.next.val;
                current.next.next.prev = current;
                current.next = current.next.next;
            }
            return rez;
        }

        private Node GetNode(int pos)
        {
            Node current = root;
            for (int i = 0; i < pos; i++)
            {
                current = current.next;
            }
            return current;
        }

        public void HalfReverse()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();

            // if (Size() == 1 || Size() == 0)
            //     return;
            int size = Size();
            Node left = GetNode(size / 2 - 1);
            if (size % 2 != 0)
            {
                Node mid = left.next;
                left.next.next.prev = left;
                left.next = left.next.next;
                mid.prev = root.prev;
                mid.next = root;
                root.prev.next = mid;
            }
            root = left.next;
        }

        public void Reverse()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();
            //  if (Size() == 1 || Size() == 0)
            //    return;
            Node current = root;
            do
            {
                Node temp = current.next;
                current.next = current.prev;
                current.prev = temp;
                current = current.prev;
            }
            while (current != root);
            root = root.next;
        }

        public void Sort()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();
            for (int i = 0; i < Size() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Size(); j++)
                {
                    if (Get(j) < Get(min))
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    int temp = Get(i);
                    Set(i, Get(min));
                    Set(min, temp);
                }
            }
        }
        
        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > Size())
                throw new ArgumentOutOfRangeException();

            if (pos == 0)
            {
                AddStart(val);
            }
            else
            {
                Node current = GetNode(pos - 1);
                Node newNode = new Node(val);
                current.next.prev = newNode;
                newNode.next = current.next;
                current.next = newNode;
                newNode.prev = current;
            }
            
        }

        public int Get(int pos)
        {
            if (root == null || pos > Size() - 1)
                throw new ArgumentOutOfRangeException();
            Node current = root;
            int i = 0;
            while (i < pos)
            {
                current = current.next;
                i++;
            }
            return current.val;
        }

        public int Max()
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();
            int maxEl = root.val;
            Node p = root;
            for (int i = 0; p.next != root; i++)
            {
                p = p.next;
                if (maxEl < p.val)
                    maxEl = p.val;
            }
            return maxEl;
        }

        public int MaxPos()
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();

            int maxEl = root.val;
            Node p = root;
            int rez = 0;
            while (p.next != root)
            {
                if (p.val == Max())
                    break;
                rez++;
                p = p.next;
            }
            return rez;
        }

        public int Min()
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();
            int minEl = root.val;
            Node p = root;
            for (int i = 0; p.next != root; i++)
            {
                p = p.next;
                if (minEl > p.val)
                    minEl = p.val;
            }
            return minEl;
        }

        public int MinPos()
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();
            int minEl = root.val;
            Node p = root;
            int rez = 0;
            while (p.next != root)
            {
                if (p.val == Min())
                    break;
                rez++;
                p = p.next;
            }
            return rez;
        }


        public void Set(int pos, int val)
        {
            if (root == null || pos > Size() - 1)
                throw new ArgumentOutOfRangeException();
            GetNode(pos).val = val;
        }


    }
}
