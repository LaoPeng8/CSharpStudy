using System;
using System.Collections.Generic;
using System.Text;

namespace secondSeason
{

    public class MyList<T>
    {

        private int size = 8;// 内部维护数组的长度
        private int count = 0;// 元素个数

        private T[] array;

        /// <summary>
        /// 无参构造 默认长度 8
        /// </summary>
        public MyList()
        {
            array = new T[size];
        }

        /// <summary>
        /// 有参构造 指定长度
        /// </summary>
        /// <param name="size"></param>
        public MyList(int size)
        {
            this.size = size;
            array = new T[size];
        }

        /// <summary>
        /// 有参构造, 传入数组
        /// 如果 数组长度小于 内部维护数组默认长度, 则直接new出默认长度
        /// 如果 数组长度大于 内部维护数组默认长度, 则内部数组长度等于原数组的2的倍数的 2倍长度
        ///     如果是非2的倍数则 +1, 变为2的倍数
        ///     
        /// Tips: 记得HashMap是因为哈希冲突计算下标数组长度-1可以得到2进制的下标(不会下标越界), 这里就也用 2 的倍数了
        ///       记得ArrayList扩容就是 2 倍长度扩容的
        ///       这里也实现了记忆中ArrayList的几个常用构造函数 (其实array参数 应该是 List接口的几个父接口的 Collection(这样就既可以传入数组也可以传入List), 这里就直接用数组了)
        /// 
        /// </summary>
        /// <param name="array"></param>
        public MyList(T[] array)
        {
            if(array == null)
            {
                array = new T[size];
            }

            int arrayLength = array.Length;
            if(arrayLength % 2 == 1)
            {
                arrayLength += 1;
            }

            this.size = arrayLength < size ? size : arrayLength * 2;

            this.array = new T[size];
            for (int i = 0; i < array.Length; i++)
            {
                this.array[i] = array[i];
            }

        }

        /// <summary>
        /// 索引器, 像操作数组一样操作 MyList
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return this.Get(index);
            }

            set
            {
                this.Add(value);
            }
        }

        /// <summary>
        /// 获取List目前的容量大小
        /// </summary>
        /// <returns></returns>
        public int GetCapacity()
        {
            return size;
        }

        public int GetCount()
        {
            return count;
        }

        /// <summary>
        /// 数组扩容的方法
        /// </summary>
        public void Resize()
        {
            if(this.count + 1 < this.size)
            {
                return;// 不是真的需要扩容
            }

            int size = this.size * 2;
            T[] targetArray = new T[size];

            this.CopyArray(this.array, targetArray);
            this.array = targetArray;
            this.size = size;
        }

        /// <summary>
        /// 数组扩容的方法
        /// </summary>
        public void Resize(int length)
        {
            if (this.count + length < this.size)
            {
                return;// 不是真的需要扩容
            }

            int size = ((this.size + length) * 2);
            size = size % 2 == 1 ? size + 1 : size;

            T[] targetArray = new T[size];
            this.CopyArray(this.array, targetArray);
            this.array = targetArray;
            this.size = size;
        }

        /// <summary>
        /// 扩容后拷贝数组内容
        /// </summary>
        /// <param name="sourceArray">原数组</param>
        /// <param name="targetArray">新数组</param>
        public void CopyArray(T[] sourceArray, T[] targetArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                targetArray[i] = sourceArray[i];
            }
        }

        /// <summary>
        /// 获取指定下标处的元素
        /// </summary>
        /// <param name="index"></param>
        public T Get(int index)
        {
            if(index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException($"数组下标越界: 最大可获取元素下标({count - 1}), 传入下标({index})");
            }

            return this.array[index];
        }

        /// <summary>
        /// 添加一个元素
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            // 允许为 null
            // if (value == null)
            // {
            // }

            // 判断是否需要扩容
            if(count + 1 == size)
            {
                Resize();
            }

            this.array[count++] = value;
        }

        /// <summary>
        /// 添加 N 个元素
        /// </summary>
        /// <param name="array"></param>
        public void AddArray(T[] array)
        {

            if(count + array.Length >= size)
            {
                Resize(array.Length);
            }

            for(int i = 0; i < array.Length; i++)
            {
                this.array[count++] = array[i];
            }

        }

        /// <summary>
        /// 添加 N 个元素
        /// </summary>
        /// <param name="array"></param>
        public void AddRange(params T[] array)
        {
            if (count + array.Length >= size)
            {
                Resize(array.Length);
            }

            for (int i = 0; i < array.Length; i++)
            {
                this.array[count++] = array[i];
            }
        }

        /// <summary>
        /// 指定下标处插入元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, T value)
        {
            if(index > count)
            {
                throw new ArgumentOutOfRangeException($"数组下标越界: 最大实际可插入下标({count - 1}), 传入下标({index})");
            }

            
            // 判断是否需要扩容
            if (count + 1 == size)
            {
                Resize();
            }
            count++;// 从for循环结束后提前到,for循环前++, 保证最后一个元素可以正确遍历, 否则最后一个元素无法正确向后挪动, 因为数组到底了 (而且已经判断了 count + 1 == size 就扩容, 也不会越界)

            T nextValue = this.array[index];
            this.array[index] = value;// 将调用者传入的值插入数组

            // 将数组元素依次向后挪动
            for (int i = index + 1; i < count; i++)
            {
                T temp = this.array[i];
                this.array[i] = nextValue;
                nextValue = temp;
            }
        }

        /// <summary>
        /// 删除指定下标处的元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index > count)
            {
                throw new ArgumentOutOfRangeException($"数组下标越界: 最大实际可删除下标({count - 1}), 传入下标({index})");
            }


            // 将数组元素依次向前挪动
            for (int i = index; i < count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            count--;
        }

        /// <summary>
        /// 获取 value 第一次出现的下标, 从前向后找
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(T value)
        {
            int index = -1;
            for(int i = 0; i < this.count; i++)
            {
                if (this.array[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// 获取 value 最后一次出现的下标, 从后向前找
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int LastIndexOf(T value)
        {
            int index = -1;
            for(int i = this.count - 1; i >= 0; i--)
            {
                if (this.array[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }


        /// <summary>
        /// 使用委托进行排序
        /// </summary>
        /// <param name="comparer"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T[] Sort(Func<T, T, int> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            // 排序方法不改变原有List结构, 返回排序后的新数组
            T[] array = new T[this.count];
            for(int i = 0; i < this.count; i++)
            {
                array[i] = this.array[i];
            }

            quickSort(array, 0, array.Length - 1, comparer);
            return array;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private static void quickSort(T[] array, int start, int end, Func<T, T, int> comparer)
        {
            // 递归退出条件, 左右指针重叠了, 或左指针大于右指针
            if(start < end)
            {
                // 获取本次排序的第一个元素 array[start], 保存本次排序的范围左右指针的值
                T pivot = array[start];
                int low = start;
                int high = end;

                // 本次排序结束条件
                while(low < high)
                {

                    // 如果 右边的值(高处的值) >= 中间值, 说明这个值本身就应该在右边(高处)
                    // high--; 后继续找, 找到一个右边的值(高处的值) 不>= 中间值, 说明这个值不该带在右边(高处), 就将其移至左边(低处)
                    while(low < high && comparer(array[high], pivot) >= 0)
                    {
                        high--;
                    }
                    array[low] = array[high];//将高处的值移至低处, 原array[low]的值保存在 pivot中间值里, 当左右指针重叠后, 赋中间值

                    // 如果 低处的值本身就小于 中间值pivot, 那就low++; 直到找到一个值, 这个值大于中间值却在低处, 就把它移动到高处
                    while(low < high && comparer(array[low], pivot) <= 0)
                    {
                        low++;
                    }
                    array[high] = array[low];

                }
                array[low] = pivot;// 本次循环结束后, low与high重叠了, 此处为中间值pivot, 中间值以左(低)的值全部小于中间值, 中间值以右亦然

                // 虽然, 中间值以左全部小于中间值, 中间值以右全部大于中间值, 但是这个区间却仍然是无序的, 所以需要递归处理 中间值左右两个区域, 直到 start >= end 即, 左右各只有一个元素, 已经是有序的
                quickSort(array, start, low, comparer);
                quickSort(array, low + 1, end, comparer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(count <= 0)
            {
                return "[]";
            }

            sb.Append("[");
            for(int i = 0; i < count; i++)
            {
                sb.Append(this.array[i]);
                if(i + 1 < count)
                {
                    sb.Append(',');
                }
            }
            sb.Append(']');

            return sb.ToString();
        }


    }

    public class Demo09
    {
        public static void Test01()
        {
            List<int> list = new List<int>() { 0,1,2,3};

            Console.WriteLine(list.Capacity);
            Console.WriteLine(list.Count);

            list.Insert(5, 5);
        }

        public static void Test02()
        {
            MyList<int> list = new MyList<int>();

            list.Add(100);
            list.Add(200);
            list.Add(300);
            list.Add(400);

            Console.WriteLine(list.GetCapacity());// 8
            Console.WriteLine(list.GetCount());// 4
            Console.WriteLine(list.ToString());// [100,200,300,400]
            Console.WriteLine("\n==================================\n");

            for (int i = 5; i <= 10; i++)
            {
                int value = 100 * i;
                list.Add(value);
            }

            Console.WriteLine(list.GetCapacity());// 16
            Console.WriteLine(list.GetCount());// 10
            Console.WriteLine(list.ToString());// [100,200,300,400,500,600,700,800,900,1000]
            Console.WriteLine("\n==================================\n");

            int[] ints = new int[] { 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000 };
            list.AddArray(ints);
            Console.WriteLine(list.GetCapacity());// 52 (16 + 10 = 26, 26 > 16, 26 * 2 = 52)
            Console.WriteLine(list.GetCount());// 20
            Console.WriteLine(list.ToString());// [100,200,300,400,500,600,700,800,900,1000,1100,1200,1300,1400,1500,1600,1700,1800,1900,2000]
            Console.WriteLine("\n==================================\n");

            list.Insert(15, 1550);
            list.Insert(7, 88888888);
            list.Insert(18, 88888888);
            list.RemoveAt(14);
            Console.WriteLine(list.GetCapacity());// 52
            Console.WriteLine(list.GetCount());// 22
            Console.WriteLine(list.ToString());// [100,200,300,400,500,600,700,88888888,800,900,1000,1100,1200,1300,1500,1550,1600,88888888,1700,1800,1900,0]
            Console.WriteLine("\n==================================\n");

            Console.WriteLine(list.IndexOf(88888888));// 7
            Console.WriteLine(list.LastIndexOf(88888888));// 17
            Console.WriteLine("\n==================================\n");

            int[] ints1 = list.Sort((a, b) => a.CompareTo(b));
            Console.WriteLine("[" + string.Join(",", ints1) + "]");// [100,200,300,400,500,600,700,800,900,1000,1100,1200,1300,1500,1550,1600,1700,1800,1900,2000,88888888,88888888]


            int[] ints2 = list.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine("[" + string.Join(",", ints2) + "]");// [88888888,88888888,2000,1900,1800,1700,1600,1550,1500,1300,1200,1100,1000,900,800,700,600,500,400,300,200,100]
        }
    }
}
