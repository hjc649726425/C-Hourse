using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{
    class Iterator
    {
        //迭代器模式
        // 提供一种方法顺序的访问一个聚合对象中各个元素，而又不暴露该对象的内部表示。

        public static void DoMain()
        {
            IList<object> list = new List<object>() { 1, 2, 3, 4, "A", "B", "C" };
            IMyIterator myiterator = new MyIterator(list,2);
            while (myiterator.hasNext())
            {
                Console.WriteLine(myiterator.next());
            }
        }
    }

    interface IMyIterator
    {
        object next();

        bool hasNext();

        object getCurrent();
    }

    class MyIterator : IMyIterator
    {
        private IList<object> list = new List<object>();
        private int index;                                  //游标
        private int point = 0;                              //遍历的次数
    
        public MyIterator(IList<object> list,int offset)  //offset  偏移量
        {
            this.list = list;

            if(offset >= list.Count || offset < 0)
            {
                offset = 0;
            }

            this.index = point + offset;
        }

        public MyIterator(IList<object> list)
        {
            this.list = list;
            index = 0;
        }

        public object getCurrent()
        {
            return this.list[index];
        }

        public bool hasNext()
        {
            if (point < list.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object next()
        {
            point++;
            return list[index++%list.Count];
        }
    }
}
