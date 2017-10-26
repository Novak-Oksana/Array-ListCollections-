using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive_Coll
{
    public class Llist2 : Ilist
    {
        Node root = null;
        Node end = null;

        class Node
        {
            public int val;
            public Node next;
            public Node prev;

            public Node(int val)
            {
                this.val = val;
                this.next = null;
                this.prev = null;
            }

        }

        public IEnumerator<int> GetEnumerator()
        {
            Node temp = root;
            while (temp != null)
            {
                yield return temp.val;
                temp = temp.next;
            }
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
            int size = 0;
            Node p = root;
            while (p != null)
            {
                size++;
                p = p.next;
            }
            return size;
        }

        public int[] ToArray()
        {
            int[] mas = new int[Size()];
            int i = 0;
            Node p = root;
            while (p != null)
            {
                mas[i++] = p.val;
                p = p.next;
            }
            return mas;
        }

        public override String ToString()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();
            String result = "";
            Node p = root;
            while (p != null)
            {
                if (result.Length > 0)
                    result += ", ";
                result = result + p.val;
                p = p.next;
            }
            return result;
        }

        public void AddEnd(int val)
        {
            Node node = new Node(val);
            if (root == null)
                root = node;

            node.prev = end;
            if (end != null)
                end.next = node;

            end = node;
        }

        public void AddStart(int val)
        {
            Node node = new Node(val);
            if (end == null)
                end = node;

            node.next = root;
            if (root != null)
                root.prev = node;

            root = node;
        }

        public void Clear()
        {
            root = null;
            end = null;
        }

        public int DelStart()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();
            int rez = root.val;
            root = root.next;
            if (root != null)
            {
                root.prev = null;

            }
            else
                end = null;

            return rez;
        }

        public int DelEnd()
        {
            if (end == null)
                throw new ArgumentOutOfRangeException();
            int rez = end.val;
            end = end.prev;
            if (end != null)
                end.next = null;
            else
                root = null;

            return rez;
        }
        /*
        public int DelPos(int pos)
        {
            if (root == null || pos > Size())
                throw new ArgumentOutOfRangeException();
            int res = 0;
            if (pos == 0)
            {
                res = DelStart();
            }
            else
            {
                Node current = root;
                for (int i = 0; i != pos - 1; i++)
                {
                    current = current.next;
                }
                res = current.next.val;
                current.next = current.next.next;
                current.next.prev = current;
            }
            return res;
        }*/
        public int DelPos(int pos)
        {
            if (root == null || pos > Size())
                throw new ArgumentOutOfRangeException();
            int res = 0;
            if (pos == 0)
                res = DelStart();
            else
            {
                int i = 1;
                Node p = root;
                while (true)
                {
                    if (i == pos)
                    {
                        res = p.next.val;
                        p.next = p.next.next;
                        break;
                    }
                    p = p.next;
                    i++;
                }
            }
            return res;
        }

        private Node GetNode(int i)
        {
            Node current = root;
            for (int j = 0; j < i; ++j)
            {
                current = current.next;
            }
            return current;
        }

        public void HalfReverse()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();
            int size = Size();
            if (size != 1)
            {
                Node left = GetNode(size / 2 - 1);
                Node right = GetNode(size - size / 2);
                Node end = GetNode(size - 1);
                if (left.next == right)//чётное 
                {
                    end.next = root;
                    root.prev = end;
                    root = right;
                    left.next = null;
                    right.prev = null;
                    end = left;
                }
                else//не чётное
                {
                    left.next.next = root;
                    left.next.prev = end;
                    root.prev = left.next;
                    root = right;
                    end.next = left.next;
                    end = left;
                    left.next = null;
                    right.prev = null;
                }
            }
        }

        public void Reverse()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();
            Node current = root;
            Node prev = null;
            while (current.next != null)
            {
                Node n = current.next;
                current.next = prev;
                prev = current;
                current = n;

            }
            current.next = prev;
            root = current;
        }

        public void Sort()
        {
            if (root == null)
                throw new ArgumentOutOfRangeException();
            bool found;
            do
            {
                found = false;
                Node p = root;
                while (p != null && p.next != null)
                {
                    if (p.val > p.next.val)
                    {
                        int temp = p.val;
                        p.val = p.next.val;
                        p.next.val = temp;
                        found = true;
                    }
                    p = p.next;

                }

            } while (found);
        }

        public void AddPos(int pos, int val)
        {
            if (pos > Size())
                throw new ArgumentOutOfRangeException();
            if (pos == 0)
            {
                Node tmp = new Node(val);
                tmp.next = root;
                root = tmp;
            }
            else
            {
                Node current = root;
                int i = 0;
                while (i < pos - 1)
                {
                    current = current.next;
                    i++;
                }
                Node tmp = new Node(val);
                tmp.next = current.next;
                current.next = tmp;
            }
        }

        public int Get(int pos)
        {
            if (root == null || pos > Size())
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
            int maxEl = root.val;
            Node p = root;
            while (p != null)
            {
                if (maxEl < p.val)
                    maxEl = p.val;
                p = p.next;
            }
            return maxEl;
        }

        public int MaxPos()
        {
            int maxEl = root.val;
            Node p = root;
            int index = 0;
            int i = 0;
            while (p != null)
            {
                if (maxEl < p.val)
                {
                    maxEl = p.val;
                    index = i;
                }
                i++;
                p = p.next;
            }
            return index;
        }

        public int Min()
        {
            int minEl = root.val;
            Node p = root;
            while (p != null)
            {
                if (minEl > p.val)
                    minEl = p.val;
                p = p.next;
            }
            return minEl;
        }

        public int MinPos()
        {
            int minEl = root.val;
            Node p = root;
            int index = 0;
            int i = 0;
            while (p != null)
            {
                if (minEl > p.val)
                {
                    minEl = p.val;
                    index = i;
                }
                i++;
                p = p.next;
            }
            return index;
        }


        public void Set(int pos, int val)
        {
            if (root == null || pos > Size())
                throw new ArgumentOutOfRangeException();
            int i = 0;
            Node p = root;
            while (p != null)
            {
                if (pos == i)
                    p.val = val;
                i++;
                p = p.next;
            }
        }

        
    }
}
