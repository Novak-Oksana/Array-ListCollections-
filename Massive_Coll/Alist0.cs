using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Massive_Coll
{
    public class Alist0 : Ilist
    {
        private int[] internal_mas = { };

        public void Init(int[] initial_mas)
        {
            if (initial_mas == null)
                initial_mas = new int[0];

            internal_mas = new int[initial_mas.Length];
            for (int i = 0; i < internal_mas.Length; i++)
            {
                internal_mas[i] = initial_mas[i];
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int item in internal_mas)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public int Size()
        {
            return internal_mas.Length;
        }

        public void Clear()
        {
            internal_mas = new int[0];
        }

        public override String ToString()
        {
            String result = "";
            for (int i = 0; i < internal_mas.Length; i++)
            {
                if (result.Length > 0)
                    result += ", ";
                result = result + internal_mas[i];
            }
            return result;
        }

        public int[] ToArray()
        {
            int[] result = new int[internal_mas.Length];
            for (int i = 0; i < internal_mas.Length; i++)
            {
                result[i] = internal_mas[i];
            }
            return result;
        }

       /* public void print()
        {
            foreach (int val in this)
            {
                System.Console.Write(val);
            }
        }
       */

        public void AddStart(int val)
        {
            int[] result = new int[internal_mas.Length + 1];
            result[0] = val;
            for (int i = 0; i < internal_mas.Length; i++)
            {
                result[i + 1] = internal_mas[i];
            }
            internal_mas = result;
        }

        public void AddEnd(int val)
        {

            int[] result = new int[internal_mas.Length + 1];
            result[internal_mas.Length] = val;
            for (int i = 0; i < internal_mas.Length; i++)
            {
                result[i] = internal_mas[i];
            }
            internal_mas = result;
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > internal_mas.Length)
                throw new ArgumentOutOfRangeException();
            int[] result = new int[internal_mas.Length + 1];
            int k = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (i == pos)
                    result[pos] = val;
                else
                {
                    result[i] = internal_mas[k];
                    k++;
                }
            }
            internal_mas = result;
        }

        public int DelStart()
        {/*
            if (internal_mas.Length == 0)
                throw new System.ArgumentOutOfRangeException();
            int[] result = new int[internal_mas.Length - 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = internal_mas[i + 1];
            }
            int del_result = internal_mas[0];
            internal_mas = result;
            return del_result;*/
            return DelPos(0);
        }

        public int DelEnd()
        {
            // if (internal_mas.Length == 0)
            //   throw new System.ArgumentOutOfRangeException();
            int[] result = new int[internal_mas.Length - 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = internal_mas[i];
            }
            int del_result = internal_mas[internal_mas.Length - 1];
            internal_mas = result;
            return del_result;
        }

        public int DelPos(int pos)
        {
            if (pos < 0 || pos >= internal_mas.Length)
                throw new ArgumentOutOfRangeException();

            int[] result = new int[internal_mas.Length - 1];
            int k = 0;
            for (int i = 0; i < internal_mas.Length; i++)
            {
                if (i != pos)
                {
                    result[k] = internal_mas[i];
                    k++;
                }
            }
            int del_result = internal_mas[pos];
            internal_mas = result;
            return del_result;

        }

        public int Min()
        {
            int minEl = internal_mas[0];
            for (int i = 0; i < internal_mas.Length; i++)
            {
                if (minEl > internal_mas[i])
                    minEl = internal_mas[i];
            }
            return minEl;
        }

        public int Max()
        {
            int maxEl = internal_mas[0];
            for (int i = 0; i < internal_mas.Length; i++)
            {
                if (maxEl < internal_mas[i])
                    maxEl = internal_mas[i];
            }
            return maxEl;
        }

        public int MinPos()
        {
            int rez = 0;
            for (int i = 0; i < internal_mas.Length; i++)
            {
                if (internal_mas[rez] > internal_mas[i])
                    rez = i;
            }
            return rez;
        }

        public int MaxPos()
        {
            int rez = 0;
            for (int i = 0; i < internal_mas.Length; i++)
            {
                if (internal_mas[rez] < internal_mas[i])
                    rez = i;
            }
            return rez;
        }

        public void Set(int pos, int val)
        {
            if (pos < 0 || pos >= internal_mas.Length)
                throw new ArgumentOutOfRangeException();
            internal_mas[pos] = val;
        }

        public int Get(int pos)
        {
            if (pos < 0 || pos >= internal_mas.Length)
                throw new ArgumentOutOfRangeException();
            return internal_mas[pos];
        }

        public void Sort()//Сортирует массив пузырьком
        {
            for (int i = 0; i < internal_mas.Length; i++)
            {
                for (int j = i + 1; j < internal_mas.Length; j++)
                {
                    if (internal_mas[i] > internal_mas[j])
                    {
                        int temp = internal_mas[i];
                        internal_mas[i] = internal_mas[j];
                        internal_mas[j] = temp;
                    }
                }
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < internal_mas.Length / 2; i++)
            {
                int temp = internal_mas[i];
                internal_mas[i] = internal_mas[internal_mas.Length - i - 1];
                internal_mas[internal_mas.Length - i - 1] = temp;
            }
        }

        public void HalfReverse()
        {
            int delta = internal_mas.Length % 2;
            int halfLength = internal_mas.Length / 2;
            for (int i = 0; i < halfLength; i++)
            {
                int elLeft = internal_mas[i];
                int elRight = internal_mas[halfLength + i + delta];
                internal_mas[i] = elRight;
                internal_mas[halfLength + i + delta] = elLeft;
            }
        }
        /*
        private class MyEnumerator : IEnumerator
        {
            private int currentIndex = 0;
            private int[] mas;

            public MyEnumerator(int[] current_mas)
            {
                mas = current_mas;
            }

            public object Current => mas[currentIndex];

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < mas.Length;
           
            }

            public void Reset()
            {
                currentIndex = 0;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(internal_mas);
        }*/
    }

}
