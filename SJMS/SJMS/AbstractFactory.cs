using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS
{

    //抽象工厂模式：提供一个创建一系列相关或相互依赖的接口，无需指定他们具体的类

    public class AbstractFactory  
    {
        
        public static void DoMain()
        {
            IComputer computer1 = new Computer1();
            computer1.print();

            IComputer computer2 = new Computer2();
            computer2.print();
        }
 
    }

    interface IComputer
    {
        ICPU getCpu();
        IMemory getMemory();

        void print();
    }

    class Computer1 : IComputer
    {
        public ICPU getCpu()
        {
            return new CPU1();
        }

        public IMemory getMemory()
        {
            return new Memory1();
        }

        public void print()
        {
            getCpu().printMsg();
            getMemory().printMsg();
        }
    }

    class Computer2 : IComputer
    {
        public ICPU getCpu()
        {
            return new CPU2();
        }

        public IMemory getMemory()
        {
            return new Memory2();
        }

        public void print()
        {
            getCpu().printMsg();
            getMemory().printMsg();
        }
    }

    interface ICPU
    {
        void printMsg();
    }

    interface IMemory
    {
        void printMsg();
    }

    class CPU1 : ICPU
    {
        public void printMsg()
        {
            Console.WriteLine("CPU1");
        }
    }

    class CPU2 : ICPU
    {
        public void printMsg()
        {
            Console.WriteLine("CPU2");
        }
    }

    class Memory1 : IMemory
    {
        public void printMsg()
        {
            Console.WriteLine("Memory1");
        }
    }

    class Memory2 : IMemory
    {
        public void printMsg()
        {
            Console.WriteLine("Memory2");
        }
    }
}
