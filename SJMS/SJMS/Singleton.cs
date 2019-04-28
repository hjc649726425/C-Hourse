using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS
{
    //单例模式
    //保证一个类只有一个实例
    class Singleton
    {

    }

    class EH
    {   //饿汉模式  静态常量,避免同步问题，但没有实现懒加载，造成内存浪费
        private static EH eh = new EH();

        private EH()
        {

        }

        public static EH getInstance()
        {
            return eh;
        }
    }

    public class LH  //懒汉模式   双重检测，保证程序安全
    {
        private volatile static LH lh;
        private static readonly object padlock = new object();

        private LH()
        {

        }

        public static LH getInstance()
        {
            if (lh == null)
            {
                lock(padlock)
                {
                    if(lh == null)
                    {
                        lh = new LH();
                    }
                }
                
            }

            return lh;
        }
    }

}
