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

        }

        /// <summary>
        /// 添加 N 个元素
        /// </summary>
        /// <param name="array"></param>
        public void AddRange(params T[] array)
        {

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


            T nextValue = this.array[index];
            this.array[index] = value;// 将调用者传入的值插入数组

            // 将数组元素依次向后挪动
            for (int i = index + 1; i < count; i++)
            {
                T temp = this.array[i];
                this.array[i] = nextValue;
                nextValue = temp;
            }
            count++;

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

        // 使用委托进行排序
        public void Sort(Func<T, T, int> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }
            
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
    }
}
