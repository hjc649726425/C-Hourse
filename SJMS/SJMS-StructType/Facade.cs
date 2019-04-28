using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_StructType
{
    //外观模式 : 简单说就是把多个子类的方法放到一个类中包装成一个方法
    //本质：封装调用，简化使用

    class Facade
    {
        public static void DoMain()
        {
            MyFacade facade = new MyFacade();
            facade.start();
            facade.shutdown();
        }
    }

    class MyFacade     //外观角色 
    {
        ICpu cpu;      //子系统角色
        IDisk disk;
        IMemory memory;

        public MyFacade()
        {
            this.cpu = new Cpu();
            this.disk = new Disk();
            this.memory = new Memory();
        }

        public void start()
        {
            cpu.start();
            disk.start();
            memory.start();
        }

        public void shutdown()
        {
            cpu.shutdown();
            disk.shutdown();
            memory.shutdown();
        }
    }

    interface ICpu
    {
        void start();
        void shutdown();
    }

    class Cpu : ICpu
    {
        public void start()
        {
            Console.WriteLine("Cpu start.....");
        }

        public void shutdown()
        {
            Console.WriteLine("Cpu shutdown.....");
        }
    }

    interface IDisk
    {
        void start();
        void shutdown();
    }

    class Disk : IDisk
    {
        public void start()
        {
            Console.WriteLine("Disk start.....");
        }

        public void shutdown()
        {
            Console.WriteLine("Disk shutdown.....");
        }
    }

    interface IMemory
    {
        void start();
        void shutdown();
    }

    class Memory : IMemory
    {
        public void start()
        {
            Console.WriteLine("Memory start.....");
        }

        public void shutdown()
        {
            Console.WriteLine("Memory shutdown.....");
        }
    }


}
