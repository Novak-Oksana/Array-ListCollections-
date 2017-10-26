using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive_Coll
{
    public class Alist1 : Ilist
    {
        private int[] internal_mas = new int[10];
        private int size_real = 0;

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < size_real; i++)
            {
                yield return internal_mas[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       

        private void addmemory()
        {
            int[] new_mas = new int[internal_mas.Length * 13 / 10];
            for (int i = 0; i < internal_mas.Length; i++)
            {
                new_mas[i] = internal_mas[i];
            }
            internal_mas = new_mas;
        }

        public void Init(int[] init_mas)
        {
            if (init_mas == null)
                init_mas = new int[0];
            for (int i = 0; i < init_mas.Length; i++)
            {
                internal_mas[i] = init_mas[i];
            }
            size_real = init_mas.Length;
        }

        public int Size()
        {
            return size_real;
        }

        public void Clear()
        {
            size_real = 0;
        }

        public override String ToString()
        {
            String result = "";
            for (int i = 0; i < size_real; i++)
            {
                if (result.Length > 0)
                    result += ", ";
                result = result + internal_mas[i];
            }
            return result;
        }

        public int[] ToArray()
        {
            int[] result = new int[size_real];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = internal_mas[i];
            }
            return result;
        }

        public void AddStart(int val)
        {
            if (size_real == internal_mas.Length)
                addmemory();
            for (int i = size_real - 1; i >= 0; i--)
            {
                internal_mas[i + 1] = internal_mas[i];
            }
            internal_mas[0] = val;
            size_real++;
        }

        public void AddEnd(int val)
        {
            if (size_real == internal_mas.Length)
                addmemory();
            //throw new System.ArgumentOutOfRangeException();
            internal_mas[size_real] = val;
            size_real++;
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos >= size_real)
                throw new ArgumentOutOfRangeException();

            for (int i = size_real - 1; i >= pos; i--)
            {
                internal_mas[i + 1] = internal_mas[i];
            }
            internal_mas[pos] = val;
            size_real++;
        }

        public int DelStart()
        {/*
            if (internal_mas == null)
                throw new ArgumentOutOfRangeException();
            int del_result = internal_mas[0];
            for (int i = 0; i < size_real - 1; i++)
            {
                internal_mas[i] = internal_mas[i + 1];
            }
            size_real--;
            return del_result;*/
            return DelPos(0);
        }

        public int DelEnd()
        {
            // if(size_real == 0)
            //     throw new System.Reflection.TargetParameterCountException();
            int del_result = internal_mas[size_real - 1];
            size_real--;
            return del_result;
        }

        public int DelPos(int pos)
        {
            if (pos < 0 || pos >= size_real)
                throw new ArgumentOutOfRangeException();
            int del_result = internal_mas[pos];
            for (int i = pos; i < size_real; i++)
            {
                internal_mas[i] = internal_mas[i + 1];
            }
            size_real--;
            return del_result;
        }

        public int Min()
        {
            if (size_real == 0)
                throw new System.Reflection.TargetParameterCountException();
            int minEl = internal_mas[0];
            for (int i = 0; i < size_real; i++)
            {
                if (minEl > internal_mas[i])
                    minEl = internal_mas[i];
            }
            return minEl;
        }

        public int Max()
        {
            int maxEl = internal_mas[0];
            for (int i = 0; i < size_real; i++)
            {
                if (maxEl < internal_mas[i])
                    maxEl = internal_mas[i];
            }
            return maxEl;
        }

        public int MinPos()
        {
            int rez = 0;
            for (int i = 0; i < size_real; i++)
            {
                if (internal_mas[rez] > internal_mas[i])
                    rez = i;
            }
            return rez;
        }

        public int MaxPos()
        {
            int rez = 0;
            for (int i = 0; i < size_real; i++)
            {
                if (internal_mas[rez] < internal_mas[i])
                    rez = i;
            }
            return rez;
        }

        public void Set(int pos, int val)
        {
            if (pos < 0 || pos >= size_real)
                throw new ArgumentOutOfRangeException();
            internal_mas[pos] = val;
        }

        public int Get(int pos)
        {
            if (pos < 0 || pos >= size_real)
                throw new ArgumentOutOfRangeException();
            return internal_mas[pos];
        }

        public void Sort()//Сортирует массив пузырьком
        {
            for (int i = 0; i < size_real; i++)
            {
                for (int j = i + 1; j < size_real; j++)
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
            for (int i = 0; i < size_real / 2; i++)
            {
                int temp = internal_mas[i];
                internal_mas[i] = internal_mas[size_real - i - 1];
                internal_mas[size_real - i - 1] = temp;
            }
        }

        public void HalfReverse()
        {
            int delta = size_real % 2;
            int halfLength = size_real / 2;
            for (int i = 0; i < halfLength; i++)
            {
                int elLeft = internal_mas[i];
                int elRight = internal_mas[halfLength + i + delta];
                internal_mas[i] = elRight;
                internal_mas[halfLength + i + delta] = elLeft;
            }
        }

        
    }

}

