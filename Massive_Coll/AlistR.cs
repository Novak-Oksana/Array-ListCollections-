using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive_Coll
{
    public class AlistR : Ilist
    {

        int[] arr = new int[10];
        int start = 5;
        int end = 5;

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = start; i < end; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int get(int index)
        {
            if (index >= arr.Length)
                return arr[index - arr.Length];
            else if (index < 0)
                return arr[index + arr.Length];
            else
                return arr[index];
        }
        private void set(int index, int value)
        {
            if (index >= arr.Length)
                arr[index - arr.Length] = value;
            else if (index < 0)
                arr[index + arr.Length] = value;
            else
                arr[index] = value;
        }

        public void AddEnd(int val)
        {
            if (Size() == arr.Length)
                ExtendArray(arr.Length);

            set(end++, val);
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > Size())
                throw new IndexOutOfRangeException();

            else if (Size() == arr.Length)
                ExtendArray(arr.Length);

            for (int i = end++ - 1; i >= pos + start; i--)
            {
                set(i + 1, get(i));
            }
            set(start + pos, val);
        }

        public void AddStart(int val)
        {
            if (Size() == arr.Length)
                ExtendArray(arr.Length);

            set(--start, val);
        }

        public void Clear()
        {
            start = 5;
            end = 5;
            arr = new int[10];
        }

        public int DelEnd()
        {
            if (Size() == 0)
                throw new Empty_array_Ex();

            return get(--end);
        }

        public int DelPos(int pos)
        {
            if (Size() == 0)
                throw new Empty_array_Ex();
            if (pos < 0 || pos > Size() - 1)
                throw new IndexOutOfRangeException();

            int ret = get(start + pos);
            end--;
            for (int i = start + pos; i < end; i++)
            {
                set(i, get(i + 1));
            }

            return ret;
        }

        public int DelStart()
        {
            if (Size() == 0)
                throw new Empty_array_Ex();

            return get(start++);
        }

        private void ExtendArray(int size)
        {
            int new_size = (int)(size * 1.3);
            int[] temp = new int[new_size];
            if (start == end)
            {
                start = new_size / 2;
                end = new_size / 2;
            }
            else if (Size() == arr.Length)
            {
                int nStart = temp.Length / 2 - Size() / 2;
                int nEnd = nStart + Size();
                for (int i = start, j = nStart; i < end; i++, j++)
                {
                    temp[j] = arr[i];
                }
                start = nStart;
                end = nEnd;
            }
            arr = temp;
        }

        public int Get(int pos)
        {
            if (Size() == 0)
                throw new Empty_array_Ex();
            if (pos < 0 || pos > (end - start) - 1)
                throw new IndexOutOfRangeException();

            return get(pos + start);
        }

        public void HalfReverse()
        {
            int mid = (Size() % 2 == 0) ? Size() / 2 : Size() / 2 + 1;
            for (int i = start; i < start + Size() / 2; i++)
            {
                int temp = get(i);
                set(i, get(i + mid));
                set(i + mid, temp);
            }
        }

        public void Init(int[] ini)
        {
            if (ini == null)
            {
                start = 5;
                end = 5;
                return;
            }

            if (ini.Length > arr.Length)
                ExtendArray(ini.Length);

            start -= ini.Length / 2;
            end += ini.Length - (ini.Length / 2);
            for (int i = start; i < end; i++)
            {
                set(i, ini[i - start]);
            }
        }

        public int Max()
        {
            if (Size() == 0)
                throw new Empty_array_Ex();

            int max = get(start);
            for (int i = start + 1; i < end; i++)
            {
                if (get(i) > max)
                    max = get(i);
            }
            return max;
        }

        public int MaxPos()
        {
            if (Size() == 0)
                throw new Empty_array_Ex();

            int res = start;
            for (int i = start; i < end; i++)
            {
                if (get(i) > get(res))
                {
                    res = i;
                }
            }
            return res - start;
        }

        public int Min()
        {
            if (Size() == 0)
                throw new Empty_array_Ex();

            int min = get(start);
            for (int i = start + 1; i < end; i++)
            {
                if (get(i) < min)
                    min = get(i);
            }
            return min;
        }

        public int MinPos()
        {
            if (Size() == 0)
                throw new Empty_array_Ex();

            int res = start;
            for (int i = start; i < end; i++)
            {
                if (get(i) < get(res))
                {
                    res = i;
                }
            }
            return res - start;
        }

        public void Reverse()
        {
            for (int i = start; i < start + Size() / 2; i++)
            {
                int temp = get(i);
                set(i, get(end - 1 - (i - start)));
                set(end - 1 - (i - start), temp);
            }
        }

        public void Set(int pos, int val)
        {
            if (Size() == 0)
                throw new Empty_array_Ex();
            if (pos < 0 || pos > Size() - 1)
                throw new IndexOutOfRangeException();

            set(pos + start, val);
        }

        public int Size()
        {
            return end - start;
        }

        public void Sort()
        {
            for (int i = start; i < end - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < end; j++)
                {
                    if (get(j) < get(min))
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    int temp = get(i);
                    set(i, get(min));
                    set(min, temp);
                }
            }
        }

        public int[] ToArray()
        {
            int[] temp = new int[Size()];
            for (int i = start, j = 0; i < end; i++, j++)
            {
                temp[j] = get(i);
            }
            return temp;
        }

        public override String ToString()
        {
            string ret = "";
            for (int i = start; i < end; i++)
            {
                ret += get(i) + ((i != end - 1) ? ", " : "");
            }
            return ret;
        }
             

    }
}
